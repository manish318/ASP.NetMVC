using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ASP.NetMVC.Models;

namespace ASP.NetMVC.Controllers
{
    public class EmployeeController : Controller
    {
        string connectionString = @"Data Source=STPL-INTERN-MAN;Initial Catalog=CrudDB;Persist Security Info=True;User ID=sa;Password=swift@123";
        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlcon= new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * from employee", sqlcon);
                da.Fill(dt);
            }
            return View(dt);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View(new EmployeeModel());
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                string sql = "insert into Employee values(@Name,@Address,@PhoneNo)";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.AddWithValue("@Name", employeeModel.Name);
                cmd.Parameters.AddWithValue("@Address", employeeModel.Address);
                cmd.Parameters.AddWithValue("@PhoneNo", employeeModel.PhoneNo);
                cmd.ExecuteNonQuery();
                
            } 

           return RedirectToAction("Index");
            
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeModel empModel = new EmployeeModel();
            DataTable dt = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                string sql = "Select * from Employee where id=@id";
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                da.Fill(dt);
            }
            if(dt.Rows.Count == 1)
            {
                empModel.id= Convert.ToInt32(dt.Rows[0][0].ToString());
                empModel.Name = dt.Rows[0][1].ToString();
                empModel.Address = dt.Rows[0][2].ToString();
                empModel.PhoneNo = dt.Rows[0][3].ToString();
                return View(empModel);
            }
           else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployeeModel empmodel)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                string sql = "update Employee SET Name=@name, Address=@Address, PhoneNo=@PhoneNo where id=@id";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.AddWithValue("@id", empmodel.id);
                cmd.Parameters.AddWithValue("@Name", empmodel.Name);
                cmd.Parameters.AddWithValue("@Address", empmodel.Address);
                cmd.Parameters.AddWithValue("@PhoneNo", empmodel.PhoneNo);
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("index");
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                string sql = "delete from Employee where id=@id";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
