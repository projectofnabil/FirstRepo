using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project_Portfolio.Models
{


    public class ManageDatabase
    {



        public void AddOrEditPerson(PersonInfoModel model,string operation)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSetPersonalData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (operation.Equals("Add"))
                {
                    cmd.Parameters.AddWithValue("@SaveOption", 1);
                }
                else if (operation.Equals("Edit"))
                {
                    cmd.Parameters.AddWithValue("@SaveOption", 2);
                }
                cmd.Parameters.AddWithValue("@Id", model.ID);
                cmd.Parameters.AddWithValue("@Name",model.Name);
                cmd.Parameters.AddWithValue("@Phone",model.Phone);
                cmd.Parameters.AddWithValue("@Nid",model.Nid);
                cmd.Parameters.AddWithValue("@Gender",model.Gender);
                cmd.Parameters.AddWithValue("@DOB",model.DOB);
                cmd.Parameters.AddWithValue("@Password",model.Password);
                cmd.Parameters.AddWithValue("@Email",model.Email);
                cmd.Parameters.AddWithValue("@Photo",model.Photo);
                cmd.Parameters.AddWithValue("@Role",model.Role);
               
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }



    }
}