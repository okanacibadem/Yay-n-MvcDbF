using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YayınMvcDbF.Models.EntityFramework;

namespace YayınMvcDbF.Controllers
{
    public class KanalController : Controller
    {
        // GET: Kanal
        YayınEntities db = new YayınEntities();
        public ActionResult Index()
        {
            var kanallar = db.kanalSet.ToList();
            return View(kanallar);
        }

        [HttpGet]
        public ActionResult YenıKanal()
        {
            List<SelectListItem> degerler = (from i in db.yayinSet.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.yayinadi,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }
        [HttpPost]
        public ActionResult YenıKanal(kanalSet p)
        {
            var yyn = db.yayinSet.Where(m => m.Id == p.yayinSet.Id).FirstOrDefault();
            p.yayinSet = yyn;
            db.kanalSet.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var kannl = db.kanalSet.Find(id);
            db.kanalSet.Remove(kannl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    
        public ActionResult GuncellemekicinGetır(int id)
        {
            var knlg = db.kanalSet.Find(id);
            return View("GuncellemekicinGetır", knlg);
        }

        [HttpPost]
        public ActionResult Guncelle(kanalSet s)
        {
            var knlgu = db.kanalSet.Find(s.KanaIno);
            knlgu.kanaladi = s.kanaladi;
            knlgu.ciro = s.ciro;
            knlgu.adres = s.adres;
            knlgu.reyting = s.reyting;
            db.SaveChanges();
            return RedirectToAction("Index", "Kanal");
        }
    }
}