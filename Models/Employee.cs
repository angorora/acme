using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace acme_employees.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        public int SystemUserId { get; set; }
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(16)]
        public string EmployeeNum { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EmployedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TerminatedDate { get; set; }

        [ForeignKey(nameof(SystemUserId))]
        [InverseProperty("Employee")]
        public virtual SystemUser SystemUser { get; set; }
    }
}
