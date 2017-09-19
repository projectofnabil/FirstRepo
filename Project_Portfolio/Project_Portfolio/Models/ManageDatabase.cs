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
        string connectionString="";
        SqlConnection con = null; 

        private void ConnectingToDatabase() {
          connectionString =
                               ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            con = new SqlConnection(connectionString);

        }
        private void Close() {

            con.Close();
        }


        //Operation= "Add" to Insert  or "Edit"  to Edit
     
        public void AddOrEditPerson(PersonInfoModel model,string operation)
        {

            ConnectingToDatabase();
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
                Close();
            
        }

        //operationToDo=All to get all data
        //operationToDo=ById to get  data for specific id

        public IEnumerable<PersonInfoModel> Persons(int id,string operationToDo) {
            ConnectingToDatabase();
            List<PersonInfoModel> li = new List<PersonInfoModel>();
            SqlCommand cmd = new SqlCommand("spGetPersonalData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (operationToDo.Equals("All"))
            {
                cmd.Parameters.AddWithValue("@QryOption", 1);
            }
            else if(operationToDo.Equals("ById")) {
                cmd.Parameters.AddWithValue("@QryOption", 2);
            }
            cmd.Parameters.AddWithValue("@ID", id);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                PersonInfoModel person = new PersonInfoModel();
                person.ID = Convert.ToInt32(rdr["ID"]);
                person.Name = rdr["Name"].ToString();
                person.Phone = rdr["Phone"].ToString();
                person.Nid = rdr["Nid"].ToString();
                person.Gender = rdr["Gender"].ToString();
                person.DOB = Convert.ToDateTime(rdr["DOB"]);
                person.Password = rdr["Password"].ToString();
                person.Email = rdr["Email"].ToString();
                person.Photo = rdr["Photo"].ToString();
                person.Role = rdr["Role"].ToString();
                li.Add(person);
            }

            Close();
            return li;
           
        }


    }
}