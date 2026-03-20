using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APBD_TASK2.Interfaces;
using APBD_TASK2.models;

namespace APBD_TASK2.Services
{
    public class RentalManager : IRentalManager
    {
        private readonly IRentalRepository _repository;

        public RentalManager(IRentalRepository repository)
        {
            _repository = repository;
        }

        public OperationResult AddEquipment(Equipment equipment)
        {
            if (equipment == null) return OperationResult.Fail("Equipment is null");
            _repository.AddEquipment(equipment);
            return OperationResult.Ok("Equipment added");
        }

        public OperationResult AddUser(User user)
        {
            if (user == null) return OperationResult.Fail("User is null");
            _repository.AddUser(user);
            return OperationResult.Ok("User added");
        }

        public OperationResult RentEquipment(int userId, int equipmentId, int days)
        {
            var user = _repository.GetAllUsers().FirstOrDefault(u => u.IdUser == userId);
            if (user == null) return OperationResult.Fail("User not found");

            var equipment = _repository.GetAllEquipment().FirstOrDefault(e => e.IdEquipment == equipmentId);
            if (equipment == null) return OperationResult.Fail("Equipment not found");

            if (!equipment.IsAvailable || equipment.Status == EquipmentStatus.unavailable)
                return OperationResult.Fail("Equipment is not available for rent");

            var limitCheck = CheckLimit(userId);
            if (!limitCheck.Success)
                Console.WriteLine($"Error");
                return OperationResult.Fail(limitCheck.Message);

            var now = DateTime.Now;
            var due = now.AddDays(days);
            var record = new RentalRecord(userId, equipmentId, now, due);
            _repository.AddRentalRecord(record);

            equipment.Status = EquipmentStatus.rented;

            return OperationResult.Ok("Equipment rented");
        }

        public OperationResult CheckLimit(int userId){
            var user = _repository.GetAllUsers().FirstOrDefault(u => u.IdUser == userId);
            if (user == null) return OperationResult.Fail("User not found");

            if (user.Type == UserType.student)
            {
                int activeCount = _repository.GetAllRentalRecords().Count(r => r.IdUser == userId && !r.IsReturned);
                if (activeCount >= 2)
                    return OperationResult.Fail("Student user reached active rental limit (2)");
            }
            else if (user.Type == UserType.employee)
            {
                int activeCount = _repository.GetAllRentalRecords().Count(r => r.IdUser == userId && !r.IsReturned);
                if (activeCount >= 5)
                    return OperationResult.Fail("Staff user reached active rental limit (5)");
            }
            return OperationResult.Ok("User rented a gadget");
        }
        public OperationResult ReturnEquipment(int equipmentId)
        {
            var equipment = _repository.GetAllEquipment().FirstOrDefault(e => e.IdEquipment == equipmentId);
            if (equipment == null) return OperationResult.Fail("Equipment not found");

            var record = _repository.GetAllRentalRecords().FirstOrDefault(r => r.IdEquipment == equipmentId && !r.IsReturned);
            if (record == null) return OperationResult.Fail("No active rental found for this equipment");

            record.MarkReturned(DateTime.Now);
            equipment.Status = EquipmentStatus.available;

            return OperationResult.Ok($"Equipment returned. Penalty: {record.Penalty:C}");
        }

        public List<Equipment> GetAvailableEquipment()
        {
            return _repository.GetAllEquipment().Where(e => e.IsAvailable).ToList();
        }

        public string GenerateReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Rental Report:");
            sb.AppendLine("Users:");
            foreach (var user in _repository.GetAllUsers())
            {
                sb.AppendLine($"- {user.FirstName} {user.LastName}.\n User type: {user.Type}");
            }
            sb.AppendLine("Equipment:");

            foreach (var equipment in _repository.GetAllEquipment())
            {
                if (equipment.IsAvailable)
                {
                    sb.AppendLine($"- {equipment.Name} Available");
                }
                else
                {
                    sb.AppendLine($"- {equipment.Name} Not available");
                }
            }

            sb.AppendLine("Rental Records:");
            foreach (var record in _repository.GetAllRentalRecords())
            {
                var returned = record.IsReturned ? record.ReturnDate.Value.ToString("yyyy-MM-dd") : "Not returned";
                string status;
                if (!record.IsReturned)
                {
                    status = "Not yet returned.";
                }
                else if (record.ReturnDate.Value.Date <= record.DueDate.Date)
                {
                    status = "Was returned on time.";
                }
                else
                {
                    status = "Was returned late.";
                }

                sb.AppendLine($"- UserId: {record.IdUser}, {record.RentalDate:yyyy-MM-dd} to {record.DueDate:yyyy-MM-dd}, Returned: {status} Penalty: {record.Penalty:C}");
            }

            return sb.ToString();
        }
    }
}
