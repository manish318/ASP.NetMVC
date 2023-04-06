using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ASP.NetMVC.Models;

namespace ASP.NetMVC.Services
{
    public class EmployeeService
    {
        public string connect = ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
        private SqlDataAdapter _adapter;
        private DataSet _ds;

        public List<EmployeeModel> GetEmployeeList()
        {
            List<EmployeeModel> GetEmpList = new List<EmployeeModel>();
            _ds = new DataSet();
            using (SqlConnection con = new SqlConnection(connect) )
            {

                con.Open();
                
            }
            return GetEmpList;
        }

    }
}