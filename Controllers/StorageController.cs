using AzureData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureData.Controllers
{
    public class StorageController : Controller
    {
        [HttpGet]
        public ActionResult Calculate()
        {
            ViewBag.RedundancyType= new SelectList(DataStorage.RedundancyTypes);
            return View(new DataStorage { RedundancyType ="Geographically"});
        }
        [HttpPost]
        public ActionResult Calculate(DataStorage ds)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirm", ds);
            }
            else
            {
                return View("Calculate");
            }
        }

        public ActionResult Confirm(DataStorage ds)
        {
            return View(ds);
        }
    }
}
