namespace EmployeeApplication.Models{
    public class Employee{
        public Guid id{get; set;}
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string email {get; set;}
    }
}