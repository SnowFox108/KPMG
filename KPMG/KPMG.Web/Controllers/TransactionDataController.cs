using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPMG.Web.Controllers
{
    public class TransactionDataController : Controller
    {
        // GET: TransactionData
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }
    }
}