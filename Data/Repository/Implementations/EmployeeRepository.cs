using System;
using System.Collections.Generic;
using System.Linq;
using acme_employees.Data.Repository.Interfaces;
using acme_employees.DTO;
using acme_employees.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace acme_employees.Data.Repository.Implementations
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly AcmeContext _db;
        private IMapper _mapper;

        public EmployeeRepository(AcmeContext db,IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public EmployeeCrudDTO Create(EmployeeCrudDTO crudDTO)
        {
            var systemUser =  this._mapper.Map<SystemUser>(crudDTO.systemUserDTO);
            var employee = this._mapper.Map<Employee>(crudDTO.employeeDTO);
            //systemUser.Employee = employee;
            this._db.SystemUsers.Add(systemUser);
            employee.SystemUserId = systemUser.SystemUserId;
            this._db.Employees.Add(employee);
            if (!this.SaveChanges())
                return null;
            else {
              
                var employeefromDb = systemUser.Employee;
                return new EmployeeCrudDTO
                {
                    systemUserDTO = this._mapper.Map<SystemUserDTO>(systemUser),
                    employeeDTO = this._mapper.Map<EmployeeDTO>(employeefromDb)
                };
            }
        }

        public IEnumerable<EmployeeCrudDTO> GetAll()
        {
            var res = this._db.SystemUsers.ToList().Select(x => new EmployeeCrudDTO
             {
                 systemUserDTO = this._mapper.Map<SystemUserDTO>(x),
                 employeeDTO = this._mapper.Map<EmployeeDTO>(x.Employee)
             }).ToList();

            return res;
           
        }

        public EmployeeCrudDTO GetOne(int id)
        {
            var systemUser = this._db.SystemUsers.FirstOrDefault(x => x.SystemUserId == id);
            return new EmployeeCrudDTO
            {
                systemUserDTO = this._mapper.Map<SystemUserDTO>(systemUser),
                employeeDTO = this._mapper.Map<EmployeeDTO>(systemUser.Employee)
            };
        }

        public bool Remove(int id)
        {
            var systemUser = this._db.SystemUsers.Find(id);
            if (systemUser == null)
            {
                throw new ArgumentNullException();
            }
            this._db.SystemUsers.Remove(systemUser);
            return this.SaveChanges();
        }

        public bool SaveChanges()
        {
            return (this._db.SaveChanges() >= 0);
        }

        public EmployeeCrudDTO Update(EmployeeCrudDTO crudDTO)
        {
            var systemUser = this._mapper.Map<SystemUser>(crudDTO.systemUserDTO);
            var employee = this._mapper.Map<Employee>(crudDTO.employeeDTO);
            systemUser.Employee = employee;
            this._db.Update(systemUser);
            if (!this.SaveChanges())
                return null;
            else
            {
                var employeefromDb = systemUser.Employee;
                return new EmployeeCrudDTO
                {
                    systemUserDTO = this._mapper.Map<SystemUserDTO>(systemUser),
                    employeeDTO = this._mapper.Map<EmployeeDTO>(employeefromDb)
                };
            }
        }

    }
}
