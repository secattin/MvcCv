using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositories;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        GenericRepository<Tbl_yetenekler> repo = new GenericRepository<Tbl_yetenekler>();


        public ActionResult Index()
        {
            var yetenekler = repo.list();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();


        }
        [HttpPost]
        public ActionResult YeniYetenek(Tbl_yetenekler p)
        {
            repo.TAdd(p);

            return RedirectToAction("Index");


        }

        public ActionResult YetenekSıl(int id)
        {
            var yetenekler=repo.Find(x =>x.ID==id);
            repo.TDelete(yetenekler);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenekler = repo.Find(x => x.ID == id);
            return View(yetenekler);
        }
        [HttpPost]
        public ActionResult YetenekDuzenle(Tbl_yetenekler p)
        {
            var y = repo.Find(x => x.ID == p.ID);
            y.Yetenek=p.Yetenek;
            y.Oran=p.Oran;
            repo.TUpdate(y);
            return RedirectToAction("Index");



        }

    }
}
