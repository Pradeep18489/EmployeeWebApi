using EmployeeWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using EmployeeWebApi.Services;

namespace EmployeeWebApi.Controllers
{
    [EnableCors(origins: "*", headers:"*", methods:"*")]
    public class EmployeeController : ApiController
    {
        private IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        // GET api/<controller>
        public IEnumerable<Employee> Get()
        {
            return _service.GetEmployees();
        }

        // GET api/<controller>/5
        public Employee Get(int id)
        {
            return _service.GetSingleEmployee(id);
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]Employee employee)
        {
            try
            {
                _service.AddEmployee(employee);
                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + employee.EmployeeId.ToString());
                    return message;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody]Employee employee)
        {
            try
            {
                Employee entity;
                bool isUpdated = _service.UpdateEmployee(id, employee, out entity);
                    if (!isUpdated)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with ID " + id.ToString() + "not found to update");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isDeleted = _service.Remove(id);
                    if (!isDeleted)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with ID " + id.ToString() + "not found to delete");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}