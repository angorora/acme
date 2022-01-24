using System;
using System.Collections.Generic;
using System.Linq;
using acme_employees.DTO;
using acme_employees.Models;

namespace acme_employees.Data.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        public IEnumerable<EmployeeCrudDTO> GetAll();
        public EmployeeCrudDTO GetOne(int id);
        public EmployeeCrudDTO Create(EmployeeCrudDTO crudDTO);
        public EmployeeCrudDTO Update(EmployeeCrudDTO crudDTO);
        public bool Remove(int id);
        public bool SaveChanges();
    }
}
