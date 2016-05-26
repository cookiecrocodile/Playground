using PlaygroundProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlaygroundProject.Controllers
{
    public class HomeController : Controller
    {
        

        // GET: Home
        public ActionResult Index()
        {
            //TempData["Pawns"] = new List<Pawn>();
            //TempData["Pawns"] = new List<Rank>();

            using (GameContext db = new GameContext())
            {
                try
                {
                    ViewBag.Ranks = (from r in db.Ranks
                                     select new SelectListItem { Text = r.RankName, Value = r.Id.ToString() });
                    /*
                    ViewBag.Months = (from Months m in Enum.GetValues(typeof(Months))
                select new SelectListItem { Text = m.ToString(), Value = Convert.ToUInt16(m).ToString() });
                    */
                    //För att kunna testa att göra en dropdown med pawnsen i player-vyn.
                    TempData["Pawns"] = db.Pawns.ToList();
                    TempData["Pawns"] = db.Ranks.ToList();

                    ViewBag.NumPlayers = db.Players.Count();
                    ViewBag.NumPawns = db.Pawns.Count();
                    ViewBag.NumRanks = db.Ranks.Count();
                }
                catch (Exception ex)
                {
                    var message = ex.Message + "\n" + ex.StackTrace;
                    ViewBag.Error = message;
                }
                
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddPawn(Pawn pawn)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (GameContext db = new GameContext())
                    {
                        db.Pawns.Add(pawn);
                        db.SaveChanges();
                       
                    }
                    return Redirect("Index");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("pf", "Failed to save pawn. Try again.");
            }

            return View("Index");
        }
    
        [HttpPost]
        public ActionResult AddRank(Rank rank)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    using (GameContext db = new GameContext())
                    {
                        db.Ranks.Add(rank);
                        db.SaveChanges();
                    }

                    return Redirect("Index");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("rf", "Failed to save rank. Try again.");
            }

            return View("Index");
        }


        [HttpPost]
        public ActionResult AddPlayer(Player player)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    using (GameContext db = new GameContext())
                    {
                        db.Players.Add(player);
                        db.SaveChanges();
                    }

                    return Redirect("Index");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("plf", "Failed to save rank. Try again.");
            }

            return View("Index");
        }

        public ActionResult Pawns()
        {
            string btn = Request.Form.Get("pawnRequest");
            string choice = Request.Form.Get("pawnlist");

            if (btn != null)
            {
                ViewBag.Choice = choice;
            }

            return View();
        }

        public ActionResult Test()
        {

            return View();
        }

    }
}