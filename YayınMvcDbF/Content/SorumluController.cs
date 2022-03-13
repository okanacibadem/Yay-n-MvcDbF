using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YayınMvcDbF.Models.EntityFramework;

namespace YayınMvcDbF.Content
{
    public class SorumluController : Controller
    {
        // GET: Sorumlu
        YayınEntities db = new YayınEntities();
        public ActionResult Index()
        {
            var sorumlular = db.yayinSet.ToList();
            return View(sorumlular);
        }
    }
}