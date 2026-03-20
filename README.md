Clone the project using git. Then run it via Visual Studio

Description of desing desisions:
1. Each model has a separate class to ensure clearence of dependencies. Same parameters are stated in the interface 
2. IRentalService and IRentalRepository are interfaces used to implement Inversion of Dependency Principle
3. Database implemented in separate class
4. RentalManager implements main logic of a rent
5. OperationResult implements errors during rental operations
6. SingletonRentalRepository implements main operations with DataBase 
