using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TblSertifikalarim> repo = new GenericRepository<TblSertifikalarim>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(sertifika);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarim t)
        {
            var p = repo.Find(x => x.ID == t.ID);
            p.ID = t.ID;
            p.Aciklama = t.Aciklama;
            p.Tarih = t.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSertifika(TblSertifikalarim t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            //DbCvEntities dbCvEntities = new DbCvEntities();
            //var deger = dbCvEntities.TblSertifikalarim.Where(x => x.ID == id)
            //    .Select(y =>y.ID).FirstOrDefault();
            //ViewBag.d = deger;
            repo.TRemove(sertifika);
            return RedirectToAction("Index");
        }
    }
}