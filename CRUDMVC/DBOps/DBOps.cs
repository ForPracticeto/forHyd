using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CRUDMVC.Models;
using System.Linq;

namespace CRUDMVC.DBOps
{
    public class DBOps
    {

        private SqlConnection con;
       /// <summary>
       /// Get the connetion string from the Database
       /// </summary>
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnect"].ToString();
            con = new SqlConnection(constr);

        }

        /// <summary>
        /// To Add Employee details
        /// </summary>
        /// <param name="obj">Object of Employee</param>
        /// <returns>boolean value</returns>
        public bool AddEmployee(EmpModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddNewEmpDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Address", obj.Address);
          
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
     
        /// <summary>
        /// To view employee details with generic list 
        /// </summary>
        /// <returns>List of All Employee</returns>
      
        public List<EmpModel> GetAllEmployees()
        {
            // uncommented the portion if we have database connected.

            connection();
            List<EmpModel> EmpList =new List<EmpModel>();
            //SqlCommand com = new SqlCommand("GetEmployees", con);
            //com.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter da = new SqlDataAdapter(com);
            //DataTable dt = new DataTable();
            //con.Open();
            DataTable dt = DummyData();
            //da.Fill(dt);
            //con.Close();
           
            //  Bind EmpModel generic list using dataRow
            foreach (DataRow dr in dt.Rows)
                {

                    EmpList.Add(

                        new EmpModel
                        {

                            Empid = Convert.ToInt32(dr["Id"]),
                            Name = Convert.ToString(dr["Name"]),
                            City = Convert.ToString(dr["City"]),
                            Address = Convert.ToString(dr["Address"])

                        }


                        );


                }

            return EmpList;


        }

        /// <summary>
        /// To Update Employee details
        /// </summary>
        /// <param name="obj">Employee object</param>
        /// <returns>Return true/false based on update </returns>
        public bool UpdateEmployee(EmpModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateEmpDetails", con);
           
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", obj.Empid);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Address", obj.Address);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                
                return true;

            }
            else
            {

                return false;
            }


        }

        /// <summary>
        /// To delete Employee details
        /// </summary>
        /// <param name="Id">employee id</param>
        /// <returns></returns>
        public bool DeleteEmployee(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteEmpById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", Id);
           
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
               
                return true;

            }
            else
            {

                return false;
            }


        }

        /// <summary>
        /// This is dummy datatable to show the list of employee
        /// </summary>
        /// <returns></returns>
        private DataTable DummyData()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("City");
            dt.Columns.Add("Address");
            dt.Rows.Add("1", "emp1", "City1", "address1");
            dt.Rows.Add("2", "emp1", "City1", "address1");
            dt.Rows.Add("3", "emp1", "City1", "address1");
            dt.Rows.Add("4", "emp1", "City1", "address1");
            dt.Rows.Add("5", "emp1", "City1", "address1");
            dt.Rows.Add("6", "emp1", "City1", "address1");
            return dt;

        }
    }
}