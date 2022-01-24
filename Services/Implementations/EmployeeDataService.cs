
using System;
using System.Collections.Generic;
using acme_employees.Data.Repository.Interfaces;
using acme_employees.DTO;
using acme_employees.Services.Interfaces;

namespace acme_employees.Services.Implementations
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private IEmployeeRepository employeeRepository;

        public EmployeeDataService(IEmployeeRepository repo)
        {
            this.employeeRepository = repo;

        }

        public EmployeeCrudDTO Create(EmployeeCrudDTO crudDTO)
        {
            if (crudDTO == null)
            {
                throw new ArgumentNullException("Please provide the EMPLOYEE data");
            }
           return this.employeeRepository.Create(crudDTO);
        }

        public IEnumerable<EmployeeCrudDTO> GetAll()
        {
            return this.employeeRepository.GetAll();
        }

        public EmployeeCrudDTO GetOne(int systemUserId)
        {
            return this.employeeRepository.GetOne(systemUserId);
        }

        public bool Remove(int systemUserId)
        {
            return this.employeeRepository.Remove(systemUserId);
        }

        public EmployeeCrudDTO Update(EmployeeCrudDTO systemUserDTO)
        {
            return this.employeeRepository.Update(systemUserDTO);
        }
    }
}
