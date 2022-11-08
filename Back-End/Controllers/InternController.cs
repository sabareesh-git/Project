using Microsoft.AspNetCore.Mvc;
using Project2.Data;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class employeeController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly CRUDContext _CRUDContext;

        public employeeController(CRUDContext CRUDContext)
        {
            _CRUDContext = CRUDContext;
        }
        // GET: api/<employeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            log.Info("employees are displaying succesfully");
            return _CRUDContext.Employees;
        }

        // GET api/<employeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _CRUDContext.Employees.SingleOrDefault(x => x.EmployeeId == id);
        }

        // POST api/<employeeController>
        [HttpPost]
        public void Post([FromBody] Employee employees)
        {
            log.Info("employees are Adding succesfully");
            _CRUDContext.Employees.Add(employees);
            _CRUDContext.SaveChanges();
        }

        // PUT api/<employeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employees)
        {
            _CRUDContext.Employees.Update(employees);
            _CRUDContext.SaveChanges();
        }

        [HttpPost("{uname}/{pwd}")]
        public bool Login(string uname, string pwd)
        {
            var ValidUser = _CRUDContext.Employees.FirstOrDefault(p => p.EmailId == uname && p.Password == pwd);
            if (ValidUser != null)
            {
                return true;
            }

            return false;

        }
        // DELETE api/<employeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _CRUDContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            if (item != null)
            {
                log.Info("employees are deleting succesfully");
                _CRUDContext.Employees.Remove(item);
                _CRUDContext.SaveChanges();
            }
        }
    }
}
