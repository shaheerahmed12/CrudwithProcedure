using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Drawing;

namespace crud2.Models
{
    public class DBHandler
    {
        Connection conn = new Connection();
        public List<Employee> GetAll()
        {
            List<Employee> list = new List<Employee>();
            using (conn.con)
            {

                SqlCommand cmd = new SqlCommand("GetAll", conn.con);
                cmd.CommandType = CommandType.StoredProcedure;
              
              
                    
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.con.Open(); 
                    sd.Fill(dt);


                    conn.con.Close();

                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(
                            new Employee
                            {
                                Id = Convert.ToInt32(dr["e_id"]),
                                Name = Convert.ToString(dr["e_Name"]),
                                LastName = Convert.ToString(dr["e_LastName"]),
                            });
                    }
                    return list;
            }
        }

        public int Added(Employee employee)
        {



            int i;
            using (conn.con)
            {
                conn.con.Open();
                SqlCommand cmd = new SqlCommand("Addupdate", conn.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);



                i = cmd.ExecuteNonQuery();
                conn.con.Close();

                return i;
            }













        }
        public int Update(Employee employee)
        {
            int i;
            SqlCommand cmd = new SqlCommand("Addupdate", conn.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Update");
            cmd.Parameters.AddWithValue("@id", employee.Id);
            cmd.Parameters.AddWithValue("@Name", employee.Name);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            conn.con.Open();
            i = cmd.ExecuteNonQuery();
            conn.con.Close();



            return i;
        }
        public int Delete(int id)
        {
            int i;
            SqlCommand cmd = new SqlCommand("DeleteAll", conn.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            conn.con.Open();
            i = cmd.ExecuteNonQuery();
            conn.con.Close();
            return i;
        }
    }
}
    
