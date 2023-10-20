using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class İletisimController : Controller
    {
        // GET: İletisim
        GenericRepository<Tbl_iletişim> repo = new GenericRepository<Tbl_iletişim>() ;    
        public ActionResult Index()
        {
            var mesajlar = repo.list();
            return View(mesajlar);
        }
    }
}