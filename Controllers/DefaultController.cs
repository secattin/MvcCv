using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCVEntities2 db= new DbCVEntities2();
        public ActionResult Index()
        {
            var degerler= db.Tbl_hakkımda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Projelerim()
        {
            var deneyimler= db.Tbldeneyimler.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitim()
        {
            var egitimler = db.Tbl_egitimlerim.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yetenekeler = db.Tbl_yetenekler.ToList();
            return PartialView(yetenekeler);
        }
        public PartialViewResult Hobilerim()
        {
            var hobiler = db.Tbl_hobilerim.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifikalarım()
        {
            var sertifika = db.Tbl_serfikalarım.ToList();
            return PartialView(sertifika);
        }
        [HttpGet]
        public PartialViewResult İletişim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult İletişim(Tbl_iletişim t)
        {
            t.Tarih= DateTime.Parse(DateTime.Now.ToShortDateString());   
            db.Tbl_iletişim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}