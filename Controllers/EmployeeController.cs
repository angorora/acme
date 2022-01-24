using System;
using System.Collections.Generic;
using acme_employees.DTO;
using acme_employees.Services.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace acme_employees.Controllers
{
    //TODO proper error Handling
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController(IEmployeeDataService employeeDataService)
        {
            this._employeeDataService = employeeDataService;
        }
        IEmployeeDataService _employeeDataService;


        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment(
       [FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message);
        }

        [Route("/error")]
        public IActionResult HandleError() => Problem();
           

        [HttpPost]
        public ActionResult<EmployeeCrudDTO> Create(EmployeeCrudDTO crudDTO)
        {

           return this._employeeDataService.Create(crudDTO);

        }

        [HttpGet]
        public IEnumerable<EmployeeCrudDTO> GetAll()
        {
            var res = this._employeeDataService.GetAll();
            return res;
        }


        [HttpGet("{id}")]
        public ActionResult<EmployeeCrudDTO> GetOne(int id)
        {
                var res  = this._employeeDataService.GetOne(id);
                return res;
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Remove(int systemUserId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult<EmployeeCrudDTO> Update(EmployeeCrudDTO crudDTO)
        {
            try
            {
                return this._employeeDataService.Update(crudDTO);
            }
            catch (ArgumentNullException e)
            {
                return null;
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return Ok(e.Data);
            }
        }
    }
}