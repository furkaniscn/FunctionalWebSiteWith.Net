using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    //[Authorize]
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        public ActionResult Index()
        {
            return View();
        }
    }
}