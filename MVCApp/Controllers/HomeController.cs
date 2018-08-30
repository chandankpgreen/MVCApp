using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        List<PersonalInfo> personalInforCollection = new List<Models.PersonalInfo>();
        SelectList lastNames;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult PersonalInfo(int personId)
        {
            personalInforCollection.Add(new PersonalInfo() { PersonId = 1, Date = new DateTime(2015, 4, 12), FirstName = "Hari", LastName = "Sadu" });
            personalInforCollection.Add(new PersonalInfo() { PersonId = 2, Date = new DateTime(2015, 4, 12), FirstName = "Hari2", LastName = "Sadu2" });
            personalInforCollection.Add(new PersonalInfo() { PersonId = 3, Date = new DateTime(2015, 4, 12), FirstName = "Hari3", LastName = "Sadu3" });


            var p = new List<SelectListItem>();
            p.Add(new SelectListItem() { Text = "1", Value = "Sadu" });
            p.Add(new SelectListItem() { Text = "2", Value = "Sadu2", Selected = true });
            p.Add(new SelectListItem() { Text = "3", Value = "Sadu3" });

            lastNames = new SelectList(p,"Value", "Text");

            ViewBag.LastNames = lastNames;

          

            var person = personalInforCollection.FirstOrDefault(x => x.PersonId == personId);

            return View(person);
        }


        [HttpPost]
        public ActionResult PersonalInfo(PersonalInfo personalInfo)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("LastName", "FirstName cannot be null or empty");
                return View(personalInfo);
            }
            
            personalInforCollection.Add(new PersonalInfo() { PersonId = 1, Date = new DateTime(2015, 4, 12), FirstName = "Hari", LastName = "Sadu" });
            personalInforCollection.Add(new PersonalInfo() { PersonId = 2, Date = new DateTime(2015, 4, 12), FirstName = "Hari2", LastName = "Sadu2" });
            personalInforCollection.Add(new PersonalInfo() { PersonId = 3, Date = new DateTime(2015, 4, 12), FirstName = "Hari3", LastName = "Sadu3" });

            if (personalInforCollection.Any(p=>p.PersonId == personalInfo.PersonId))
            {
               var person = personalInforCollection.FirstOrDefault(x => x.PersonId == personalInfo.PersonId);
                personalInforCollection.Remove(person);
                personalInforCollection.Add(personalInfo);
            }

            return View("personalInfoList",personalInforCollection);
        }
    }
}