using MVC_Otel_Agac.App_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Otel_Agac.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult OtellerWidget()
        {
            return PartialView(Context.Baglanti.Otel.ToList());
        }
        public ActionResult OtelDetay(int id)
        {
            return View(Context.Baglanti.Otel.FirstOrDefault(x=>x.id==id));
        }
        [HttpPost]
        public ActionResult YorumYap(string Yorum,int Otelid,int Musterid)
        {
            Yorum yorum = new Yorum();
            yorum.Musterid = Musterid;
            yorum.yorum1 = Yorum;
            yorum.Otelid = Otelid;
            int id = Otelid;
            Context.Baglanti.Yorum.Add(yorum);
            Context.Baglanti.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
