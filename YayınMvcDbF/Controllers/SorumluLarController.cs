using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YayınMvcDbF.Models.EntityFramework;

namespace YayınMvcDbF.Controllers
{
    public class SorumluLarController : Controller
    {
        // GET: SorumluLar
        YayınEntities db = new YayınEntities();

        public ActionResult Index()
        {
            var degerler = db.sorumluSet.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YenıSorumlu()
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
        public ActionResult YenıSorumlu(sorumluSet p)
        {
            var yyn = db.yayinSet.Where(m => m.Id == p.yayinSet.Id).FirstOrDefault();
            p.yayinSet = yyn;
            db.sorumluSet.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var srmlu = db.sorumluSet.Find(id);
            db.sorumluSet.Remove(srmlu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GuncellemekicinGetır(int id)
        {
            var srmlg = db.sorumluSet.Find(id);
            return View("GuncellemekicinGetır", srmlg);
        }

       
        public ActionResult Guncellesorumlu(sorumluSet k)
        {
            var srgu = db.sorumluSet.Find(k);
            srgu.asoyad = k.asoyad;
            srgu.gorevi = k.gorevi;
            srgu.maas = k.maas;
            srgu.gorevsayisi = k.gorevsayisi;
            srgu.yayınıdSorumlu = k.yayınıdSorumlu;
            db.SaveChanges();
            return RedirectToAction("Index","SorumluLar");
        }

        public ActionResult Guncelle(sorumluSet s)
        {
            var knlgu = db.sorumluSet.Find(s.sorumluno);
            knlgu.asoyad = s.asoyad;
            knlgu.gorevi = s.gorevi;
            knlgu.maas = s.maas;
            knlgu.gorevsayisi = s.gorevsayisi;
            knlgu.yayınıdSorumlu = s.yayınıdSorumlu;
            db.SaveChanges();
            return RedirectToAction("Index", "Sorumlular");
        }
    }
}