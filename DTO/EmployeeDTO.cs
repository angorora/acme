using System;
namespace acme_employees.DTO
{
    public class EmployeeDTO
    {
        public EmployeeDTO()
        {
        }

        public int SystemUserId { get; set; }
        public int EmployeeId { get; set; }

        public string EmployeeNum { get; set; }

        public DateTime? EmployedDate { get; set; }

        public DateTime? TerminatedDate { get; set; }
    }
}
