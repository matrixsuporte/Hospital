using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class LoginController : Controller
    {
        MyDbContext db = new MyDbContext();
        public IActionResult Login()
        {
            return View();
        }
        public ActionResult Validate(Admins admin)
        {
            var _admin = db.Admins.Where(s => s.Email == admin.Email);
            if (_admin.Any()) {
                if (_admin.Where(s => s.Password == admin.Password).Any()) {
                    return Json(new { status = true, message = "Login com Sucesso!"});
                }
                else
                {
                    return Json(new { status = false, message = "Senha Inválida!"});
                }
            }
            else
            {
                return Json(new { status = false, message = "E-mail Inválido!"});
            }
        }
    }
}