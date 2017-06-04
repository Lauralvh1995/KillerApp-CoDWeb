using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoDWebBuilder.Models;

namespace WoDWebBuilder.Controllers
{
    public class DieController : Controller
    {
        Die die = new Die(10);

        // GET: Die
        public ActionResult Index()
        {
            return View(die);
        }

        [HttpPost]
        public ActionResult Roll(int i)
        {
            foreach (int roll in die.Rolls.ToList())
            {
                die.Rolls.Remove(roll);
            }
            die.Roll(i);
            RedirectToAction("Index");
            return View("Index");
        }
    }
}