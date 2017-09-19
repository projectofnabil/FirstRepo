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



        public void AddPerson(PersonInfoModel model)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddPerson", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName",model.UserName);
                cmd.Parameters.AddWithValue("@FirstName",model.FirstName);
                cmd.Parameters.AddWithValue("@LastName",model.LastName);
                cmd.Parameters.AddWithValue("@Email",model.Email);
                cmd.Parameters.AddWithValue("@Country",model.Country);
                cmd.Parameters.AddWithValue("@MobileCountryCode",model.MobileCountryCode);
                cmd.Parameters.AddWithValue("@MobileNumberPortion",model.MobileNumberPortion);
                cmd.Parameters.AddWithValue("@Photo",model.Photo);
                cmd.Parameters.AddWithValue("@Gender",model.Gender);
                cmd.Parameters.AddWithValue("@BirthDay",model.BirthDay);
                cmd.Parameters.AddWithValue("@BirthMonth",model.BirthMonth);
                cmd.Parameters.AddWithValue("@BirthYear",model.BirthYear);
                cmd.Parameters.AddWithValue("@PersonID",model.PersonID);
                cmd.Parameters.AddWithValue("@LogInPassword",model.LogInPassword);
                cmd.Parameters.AddWithValue("@Operation","I");
                cmd.Parameters.AddWithValue("@PersonRole",model.PersonRole);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }



    }
}