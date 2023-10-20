using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;
namespace MvcCv.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Tbl_admin> repo=new GenericRepository<Tbl_admin>();
        public ActionResult Index()
        {
            var liste = repo.list();
            return View(liste);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(Tbl_admin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");

        }
        public ActionResult AdminSil(int id)
        {
            Tbl_admin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminDuzenle(int id)
        {
            Tbl_admin t = repo.Find(x => x.ID == id);
            return View(t);

        }
        [HttpPost]
        public ActionResult AdminDuzenle(Tbl_admin p)
        {
            Tbl_admin t = repo.Find(x => x.ID == p.ID);
            t.Kullaniciad = p.Kullaniciad;
            t.Sifre=p.Sifre;
            repo.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}
