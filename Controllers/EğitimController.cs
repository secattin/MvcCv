using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EğitimController : Controller
    {
        // GET: Eğitim
        GenericRepository<Tbl_egitimlerim> repo = new GenericRepository<Tbl_egitimlerim>();
      
        public ActionResult Index()
        {
            var egitim=repo.list();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EğitimEkle()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult EğitimEkle(Tbl_egitimlerim p)
        {
           
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EğitimSil(int id)
        {
           var egitim= repo.Find(x =>x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public ActionResult EğitimDuzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);

            return View(egitim);
        }
        [HttpPost]
        public ActionResult EğitimDuzenle(Tbl_egitimlerim t)
        {
            var egitim = repo.Find(x => x.ID == t.ID);
            egitim.Baslik=t.Baslik;
            egitim.AltBaslik1 = t.AltBaslik1;
            egitim.AltBaslik2=t.AltBaslik2;
            egitim.Tarih=t.Tarih;
            egitim.GNO=t.GNO;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }




    }
}