using System;
using System.Collections.Generic;
using acme_employees.DTO;
using acme_employees.Models;

namespace acme_employees.Services.Interfaces
{
    public interface IEmployeeDataService
    {
        public IEnumerable<EmployeeCrudDTO> GetAll();
        public EmployeeCrudDTO GetOne(int id);
        public EmployeeCrudDTO Create(EmployeeCrudDTO crudDTO);
        public EmployeeCrudDTO Update(EmployeeCrudDTO crudDTO);
        public bool Remove(int systemUserId);
    }
}
