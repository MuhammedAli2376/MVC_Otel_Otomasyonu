using MVC_Otel_Agac.App_Classes;
using Otel_Otomasyonu_Agac;
using Otel_Otomasyonu_Agac.ORM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Web;
using System.Web.Mvc;
namespace MVC_Otel_Agac.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Oteller()
        {
            return View(Context.Baglanti.Otel.ToList());
        }
        public ActionResult OtelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OtelEkle(Otel otel)
        {
            Context.Baglanti.Otel.Add(otel);
            Context.Baglanti.SaveChanges();
            return RedirectToAction("Oteller");
        }
        public ActionResult PersonelEkle(int id)
        {
            Otel otel = Context.Baglanti.Otel.FirstOrDefault(x => x.id == id);
            return View(otel);
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            Otel otel = Context.Baglanti.Otel.FirstOrDefault(x => x.id == personel.Otelid);
            Departman departman = Context.Baglanti.Departman.FirstOrDefault(x => x.id == personel.Departmanid);
            Pozisyon pozisyon = Context.Baglanti.Pozisyon.FirstOrDefault(x => x.id == personel.Pozisyonid);
            personel.Otel = otel;
            personel.Departman = departman;
            personel.Pozisyon = pozisyon;
            Context.Baglanti.Personel.Add(personel);
            Context.Baglanti.SaveChanges();
            return RedirectToAction("Personeller");
        }
        public ActionResult Personeller()
        {
            return View(Context.Baglanti.Personel.ToList());
        }
        public ActionResult OtelDuzenle(int id)
        {
            Otel otel = Context.Baglanti.Otel.FirstOrDefault(x => x.id == id);
            return View(otel);
        }
        [HttpPost]
        public ActionResult OtelDuzenle(Otel otel)
        {  
            Otel eskiotel = Context.Baglanti.Otel.FirstOrDefault(x => x.id == otel.id);
            PropertyInfo[] proplar = typeof(Otel).GetProperties();
            foreach (PropertyInfo item in proplar)
                item.SetValue(eskiotel, item.GetValue(otel));
            Context.Baglanti.SaveChanges();
            return RedirectToAction("Oteller");
        }
        
        public ActionResult OtelSil(int id)
        {
            Otel sil = Context.Baglanti.Otel.FirstOrDefault(x => x.id == id);
            Context.Baglanti.Otel.Remove(sil);
            Context.Baglanti.SaveChanges();
            return RedirectToAction("Oteller");
        }
        public ActionResult PersonelSil(int id)
        {
            Personel personel = Context.Baglanti.Personel.FirstOrDefault(x => x.id == id);
            Context.Baglanti.Personel.Remove(personel);
            Context.Baglanti.SaveChanges();
            return RedirectToAction("Personeller");
        }
        public ActionResult PersonelGuncelle(int id)
        {
            Personel p = Context.Baglanti.Personel.FirstOrDefault(x => x.id == id);
            return View(p);
        }
        [HttpPost]
        public ActionResult PersonelGuncelle(Personel personel)
        {
            Personel eskipersonel = Context.Baglanti.Personel.FirstOrDefault(x => x.id == personel.id);
            PropertyInfo[] proplar = typeof(Personel).GetProperties();
            foreach (PropertyInfo item in proplar)
                item.SetValue(eskipersonel, item.GetValue(personel));
            Context.Baglanti.SaveChanges();
            return RedirectToAction("Personeller");
        }
        public ActionResult PersonelPuanSirala()
        {
            Personel[] personeller = Context.Baglanti.Personel.ToArray();
            int i, j;
            Personel moved;
            for (i = 1; i < personeller.Length; i++)
            {
                moved = personeller[i];
                j = i;
                while (j > 0 && personeller[j - 1].Puan > moved.Puan)
                {
                    personeller[j] = personeller[j - 1];
                    j--;
                }
                personeller[j] = moved;
            }
            return RedirectToAction("Personeller");
        }
        public void PuanVer(int id,int puan)
        {
            Personel personel = Context.Baglanti.Personel.FirstOrDefault(x => x.id == id);
            personel.Puan = puan;
            Context.Baglanti.SaveChanges();
        }
        [HttpPost]
        public ActionResult OtelResimEkle(int oid, HttpPostedFileBase fileUpload)
        {
            if (fileUpload != null)
            {
                Image img = Image.FromStream(fileUpload.InputStream);
                Bitmap OrtaResim = new Bitmap(img,Settings.OtelOrtaBoyut);
                Bitmap BuyukResim = new Bitmap(img, Settings.OtelBuyukBoyut);
                string Ortayol = "/Content/OtelResim/Orta/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                string Buyukyol = "/Content/OtelResim/Buyuk/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                OrtaResim.Save(Server.MapPath(Ortayol));
                BuyukResim.Save(Server.MapPath(Buyukyol));
                Resim rsm = new Resim();
                rsm.BuyukYol = Buyukyol;
                rsm.OrtaYol = Ortayol;
                rsm.Otelid= oid;
                Context.Baglanti.Resim.Add(rsm);
                Context.Baglanti.SaveChanges();
            }
            return RedirectToAction("Oteller");
        }

    }
}