using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Portfolio.Models
{

    public class PersonInfoModel
    {


        public int ID { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [StringLength(20)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        [StringLength(20)]
        [Display(Name = "National Id")]
        public string Nid { get; set; }
        [Required]
        public string Gender { get; set; }
        [StringLength(20)]
        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Remote("CheckForDuplication", "Account")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Photo { get; set; }
        [Required]
        public string Role { get; set; }



    }

    public class LogInViewModel
        {





        }



}