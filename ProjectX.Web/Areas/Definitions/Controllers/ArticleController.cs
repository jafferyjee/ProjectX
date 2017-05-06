using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectX.Web.Areas.Definitions.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Definitions/Article
        public ActionResult Index()
        {
            return View();
        }
    }
}