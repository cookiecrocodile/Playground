using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlaygroundProject.Models;

namespace PlaygroundProject.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api
        public ActionResult GetPawns()
        {
            using (GameContext gc = new GameContext())
            {
                var pawns = (from p in gc.Pawns
                            select p).ToList();
                
                return Json(pawns, JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult GetRanks()
        {
            using (GameContext gc = new GameContext())
            {
                var ranks = (from r in gc.Ranks
                             select r).ToList();

                return Json(ranks, JsonRequestBehavior.AllowGet);
            }

        }
    }
}