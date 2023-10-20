using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tbl_admin p)
        {
            DbCVEntities2 db=new DbCVEntities2();
            var bilgi=db.Tbl_admin.FirstOrDefault(x=>x.Kullaniciad==p.Kullaniciad && x.Sifre==p.Sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.Kullaniciad,false);
                Session["KullaniciAdi"]=bilgi.Kullaniciad.ToString();
                return RedirectToAction("Index","Proje");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}