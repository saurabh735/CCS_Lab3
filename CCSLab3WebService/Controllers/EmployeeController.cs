using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CCSLab3WebService.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Employee> Get()
        {
            var employees = new List<Employee>();
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                var cmd = new MySqlCommand("Select * from Employees", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee { 
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name"),
                        Position = reader.GetString("position")
                        } );
                    }
                }
            }

            return employees;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }


    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
    }
}