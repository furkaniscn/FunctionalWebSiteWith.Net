using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        // GET: Egitim

        GenericRepository<TblEgitim> repo = new GenericRepository<TblEgitim>();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitim p)
        {
            if (!ModelState.IsValid)// Eğer validasyonlardaki değeri ezecek bir hamle yapıldıysa EgitimEkle sayfasına döner
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x=>x.ID == id);
            repo.TRemove(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x=> x.ID == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitim t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDuzenle");
            }
            var egitim = repo.Find(x => x.ID == t.ID);
            egitim.Baslik = t.Baslik; 
            egitim.AltBaslik = t.AltBaslik; 
            egitim.AltBaslik2 = t.AltBaslik2; 
            egitim.Tarih = t.Tarih; 
            egitim.GNO = t.GNO; 
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}