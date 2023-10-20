using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<Tbl_hakkımda> repo = new GenericRepository<Tbl_hakkımda>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkımda = repo.list();
            return View(hakkımda);
        }
        [HttpPost]
        public ActionResult Index(Tbl_hakkımda p)
        {
            var h = repo.Find(x => x.ID == 1);
            h.Ad = p.Ad;
            h.Soyad = p.Soyad;
            h.Adres = p.Adres;
            h.Mail = p.Mail;
            h.Telefon = p.Telefon;
            h.Açıklama = p.Açıklama;
            h.Resim = p.Resim;
            repo.TUpdate(h);
            return RedirectToAction("Index");
        }
    }
}