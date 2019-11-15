using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class PatientsController : Controller
    {
        MyDbContext db = new MyDbContext();
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePatient(Patients patient)
        {
            db.Patients.Add(patient);
            db.SaveChanges();
            return RedirectToAction("Index", "Patients");
        }

        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                Patients patient = db.Patients.Where(s => s.Id == id).First();
                db.Patients.Remove(patient);
                db.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }

        }

        public ActionResult Update(int id)
        {
            return View(db.Patients.Where(s => s.Id == id).First());
        }

        [HttpPost]
        public ActionResult UpdatePatient(Patients patient)
        {
            Patients d = db.Patients.Where(s => s.Id == patient.Id).First();
            d.Name = patient.Name;
            d.Phone = patient.Phone;
            d.Gender = patient.Gender;
            d.HealthCondition = patient.HealthCondition;
            d.DoctorId = patient.DoctorId;
            d.NurseId = patient.NurseId;
            db.SaveChanges();
            return RedirectToAction("Index", "Patients");
        }
    }
}