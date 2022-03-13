using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YayınMvcDbF.Models.EntityFramework;

namespace YayınMvcDbF.Controllers
{
    public class YayinController : Controller
    {
        // GET: Default
        YayınEntities db = new YayınEntities();
        public ActionResult Index()//listeleme
        {
            var yayınlar = db.yayinSet.ToList();
            return View(yayınlar);
        }
        [HttpGet]
        public ActionResult Eklemesayfa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Eklemesayfa(yayinSet p)
        {
            db.yayinSet.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var yayın = db.yayinSet.Find(id);
            db.yayinSet.Remove(yayın);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GuncellemekicinGetır(int id)
        {
            var yyng = db.yayinSet.Find(id);       

            return View("GuncellemekicinGetır", yyng);
        }
        public ActionResult Guncelle(yayinSet s)
        {
            var knlgu = db.yayinSet.Find(s.Id);
            knlgu.yayinadi = s.yayinadi;
            knlgu.yayıntarih = s.yayıntarih;
            knlgu.reyting = s.reyting;       
            db.SaveChanges();
            return RedirectToAction("Index", "Yayin");
        }


    }
}