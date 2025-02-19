using FS0924_S14_L3.Models;
using Microsoft.AspNetCore.Mvc;

namespace FS0924_S14_L3.Controllers
{
    public class TicketController : Controller
    {
        public static List<Ticket> northHall = new List<Ticket>();
        public static List<Ticket> eastHall = new List<Ticket>();
        public static List<Ticket> southHall = new List<Ticket>();

        public static Gestional gestional = new Gestional()
        {
            NorthHall = northHall,
            EastHall = eastHall,
            SouthHall = southHall,
        };

        public IActionResult Index()
        {
            return View(gestional);
        }

        public IActionResult Sell()
        {
            return View();
        }

        [HttpPost()]
        public IActionResult SellTicket(SellTicketModel sellTicketModel)
        {
            if (!ModelState.IsValid)
            {
                //return RedirectToAction("Sell");
            }

            var reduced = sellTicketModel.IsReducedStr == "true" ? true : false;

            var newTicket = new Ticket()
            {
                Id = Guid.NewGuid(),
                Name = sellTicketModel.Name,
                Surname = sellTicketModel.Surname,
                Hall = sellTicketModel.Hall,
                IsReduced = reduced,
            };

            switch (sellTicketModel.Hall)
            {
                case "North Hall":
                    if (northHall.Count < 120)
                    {
                        northHall.Add(newTicket);
                    }
                    break;

                case "East Hall":
                    if (eastHall.Count < 120)
                    {
                        eastHall.Add(newTicket);
                    }
                    break;

                case "South Hall":
                    if (southHall.Count < 120)
                    {
                        southHall.Add(newTicket);
                    }
                    break;

                default:
                    break;
            }

            return RedirectToAction("Index");
        }
    }
}
