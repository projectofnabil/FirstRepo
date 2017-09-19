using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_Portfolio.Models
{

        public class PersonInfoModel
        {


        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Nid { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }        
            public string Photo { get; set; }       
            public string Role { get; set; }



    }
}