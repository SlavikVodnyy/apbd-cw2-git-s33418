using System;

namespace APBD_TASK2.models
{
    public class RentalRecord
    {
        private static int _nextId = 1;

        public int Id { get; set; }
        public int IdUser { get; set; }

        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime DueDate { get; set; }

        public bool IsReturned => ReturnDate.HasValue;

        public decimal Fee { get; set; }

        public decimal Penalty => CalculatePenalty();


        public decimal Total => Fee + Penalty;

        public RentalRecord(int idUser, DateTime rentalDate, DateTime dueDate, decimal fee = 0m)
        {
            Id = _nextId++;
            IdUser = idUser;
            RentalDate = rentalDate;
            DueDate = dueDate;
            Fee = fee;
        }

        private decimal CalculatePenalty()
        {
            if (!IsReturned) return 0m;

            var daysLate = (ReturnDate.Value.Date - DueDate.Date).Days;
            if (daysLate <= 0) return 0m;

          
            return daysLate * 5.0m;
        }

        public bool MarkReturned(DateTime? returnDate = null)
        {
            if (IsReturned) return false;
            ReturnDate = returnDate ?? DateTime.Now;
            return true;
        }
    } 
}
