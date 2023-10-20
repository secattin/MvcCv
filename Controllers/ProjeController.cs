using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ProjeController : Controller
    {
        // GET: Proje
        ProjeRepository repo = new ProjeRepository();
        public ActionResult Index()
        {
            var degerler=repo.list();
            return View(degerler);
        }
        [HttpGet]
         public ActionResult ProjeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProjeEkle(Tbldeneyimler p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");

        }
        public ActionResult ProjeSil(int id)
        {
            Tbldeneyimler t= repo.Find(x=>x.ID==id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ProjeDuzenle(int id)
        {
            Tbldeneyimler t = repo.Find(x => x.ID == id);
            return View(t); 

        }
        [HttpPost]
        public ActionResult ProjeDuzenle(Tbldeneyimler p)
        {
            Tbldeneyimler t = repo.Find(x => x.ID == p.ID);
            t.Baslik=p.Baslik;
            t.Altbaslik=p.Altbaslik;
            t.Tarih=p.Tarih;
            t.Aciklama=p.Aciklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}