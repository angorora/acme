using System;
namespace acme_employees.DTO
{
    public class SystemUserDTO
    {
        public SystemUserDTO()
        { }
        public int SystemUserId { get; set; }
        public string Firstname { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

    }
}
