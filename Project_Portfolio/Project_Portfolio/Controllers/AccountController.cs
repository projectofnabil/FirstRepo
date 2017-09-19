using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Portfolio.Models;
namespace Project_Portfolio.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(PersonInfoModel pn)
        {

            if (ModelState.IsValid)
            {
                ManageDatabase mn = new ManageDatabase();
                mn.AddOrEditPerson(pn,"Add");
                return RedirectToAction("Success");

            }
            return View();
        }

        public ActionResult LogIn(LogInViewModel model) {



            return View();

        }





        public ActionResult Success() {

            return View();
        }




        //public JsonResult CheckForDuplication(string Work_Email)
        //{
            //            ManageData mn = new ManageData();
            //            var data = mn.Persons.Where(p => p.Work_Email.Equals(Work_Email,
            //StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            //            if (data != null)
            //            {
            //                return Json("Sorry, this Email already exists",
            //JsonRequestBehavior.AllowGet);
            //            }
            //            else
            //            {
            //                return Json(true, JsonRequestBehavior.AllowGet);
            //            }


        //}







    }
}