using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<Tbl_hobilerim> repo = new GenericRepository<Tbl_hobilerim>();
        [HttpGet]
        public ActionResult Index()
        {
            var mesajlar = repo.list();
            return View(mesajlar);
        }
        [HttpPost]
        public ActionResult Index(Tbl_hobilerim p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Aciklama1 = p.Aciklama1;
            t.aciklama2 = p.aciklama2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}