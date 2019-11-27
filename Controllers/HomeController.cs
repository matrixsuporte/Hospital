using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using TemplateAdminLTE2.Models;

namespace TemplateAdminLTE2.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext db = new MyDbContext();

        public IActionResult Index()
        {
            DashboardViewModel dashboard = new DashboardViewModel();
            dashboard.nurses_count = db.Nurses.Count();
            dashboard.doctors_count = db.Doctors.Count();
            dashboard.patients_count = db.Patients.Count();

            return View(dashboard);
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
