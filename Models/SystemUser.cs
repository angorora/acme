using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace acme_employees.Models
{
    [Table("SystemUser")]
    public partial class SystemUser
    {
        public SystemUser()
        {
           
        }

        [Key]
        public int SystemUserId { get; set; }
        [Required]
        [StringLength(128)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(128)]
        public string LastName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }

        
        public virtual Employee Employee { get; set; }
    }
}
