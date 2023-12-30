using System.ComponentModel.DataAnnotations;

namespace PabloStaffApp.Models
{
    public class EmployeeEntity
    {
        [Key] // This attribute indicates that EmpId is the primary key
        public int EmpId { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
    }
}
