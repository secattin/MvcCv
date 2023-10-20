using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;
using MvcCv.Controllers;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<Tbl_serfikalarım> repo = new GenericRepository<Tbl_serfikalarım>();
        public ActionResult Index()
        {
            var serfika = repo.list();
            return View(serfika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika=repo.Find(x=>x.ID==id);
            return View(sertifika);
        }
        public ActionResult SertifikaGetir(Tbl_serfikalarım t)
        {
            var sertifika = repo.Find(x => x.ID ==t.ID);
            sertifika.Aciklama=t.Aciklama;
            sertifika.Tarih=t.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(Tbl_serfikalarım p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }

    }
}