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
            personalInforCollection.Add(new PersonalInfo() { PersonId = 2, Date = new DateTime(2015, 4, 12), FirstName = "Hari2", LastName = "Sadu" });
            personalInforCollection.Add(new PersonalInfo() { PersonId = 3, Date = new DateTime(2015, 4, 12), FirstName = "Hari3", LastName = "Sadu3" });

            var person = personalInforCollection.FirstOrDefault(x => x.PersonId == personId);

            return View(person);
        }


        [HttpPost]
        public ActionResult PersonalInfo(PersonalInfo personalInfo)
        {
            personalInforCollection.Add(new PersonalInfo() { PersonId = 1, Date = new DateTime(2015, 4, 12), FirstName = "Hari", LastName = "Sadu" });
            personalInforCollection.Add(new PersonalInfo() { PersonId = 2, Date = new DateTime(2015, 4, 12), FirstName = "Hari2", LastName = "Sadu" });
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