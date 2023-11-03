using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IConfiguration _configuration;
        public DepartmentController (IConfiguration configuration)
        {
            //To read the connection string from the appsettings file, we need to use dependency injection
           _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select DepartmentId, DepartmentName from
                dbo.Department
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            MySqlDataReader myReader;
            using(MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);

        }

        [HttpPost]
        public JsonResult Post(Department dept)
        {
            string query = @"
                insert into dbo.Department (DepartmentNames) values
                                            (@DepartmentName)
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentName", dept.DepartmentName);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");

        }

        [HttpPut]
        public JsonResult Put(Department dept)
        {
            string query = @"
                    update dbo.Department 
                    set DepartmentName = @DepartmentName
                    where DepartmentId = @DepartmentId;
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentId", dept.DepartmentId);
                    myCommand.Parameters.AddWithValue("@DepartmentName", dept.DepartmentName);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
       
            [HttpDelete("id")]
            public JsonResult Delete(int id)
            {
                string query = @"
                    delete from dbo.Department 
                    where DepartmentId = @DepartmentId;
            ";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
                MySqlDataReader myReader;
                using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@DepartmentId", id);

                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

                        myReader.Close();
                        myCon.Close();
                    }
                }
                return new JsonResult("Deleted Successfully");

            }
        }
}
