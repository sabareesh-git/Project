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
    public class DesignationController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly CRUDContext _CRUDContext;

        public DesignationController(CRUDContext CRUDContext)
        {
            _CRUDContext = CRUDContext;
        }

        // GET: api/<DesignationController>
        [HttpGet]
        public IEnumerable<Designation> Get()
        {
            log.Info("Department are displaying succesfully");
            return _CRUDContext.Designations;
        }

        // GET api/<DesignationController>/5
        [HttpGet("{id}")]
        public Designation Get(int id)
        {
            return _CRUDContext.Designations.SingleOrDefault(x => x.DesignationID == id);
        }

        // POST api/<DesignationController>
        [HttpPost]
        public void Post([FromBody] Designation designations)
        {
            log.Info("Department are Adding succesfully");
            _CRUDContext.Designations.Add(designations);
            _CRUDContext.SaveChanges();
        }

        // PUT api/<DesignationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Designation designations)
        {
            log.Info("Department are modifying succesfully");
            _CRUDContext.Designations.Update(designations);
            _CRUDContext.SaveChanges();
        }

        // DELETE api/<DesignationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _CRUDContext.Designations.FirstOrDefault(x => x.DesignationID == id);
            if (item != null)
            {
                log.Info("Department are deleting succesfully");
                _CRUDContext.Designations.Remove(item);
                _CRUDContext.SaveChanges();
            }
        }
    }
}
