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
                mn.AddPerson(pn);
                return RedirectToAction("Success");

            }
            return View();
        }
        public ActionResult Success() {

            return View();
        }



    }
}