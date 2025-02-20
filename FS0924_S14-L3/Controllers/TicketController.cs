using System;
using System.Net.Sockets;
using FS0924_S14_L3.Models;
using Microsoft.AspNetCore.Mvc;

namespace FS0924_S14_L3.Controllers
{
    public class TicketController : Controller
    {
        public static Gestional gestional = new Gestional()
        {
            NorthHall = new Hall()
            {
                Name = "North Hall",
                TicketsList = [],
                ReducedTicketsCount = 0,
            },
            EastHall = new Hall()
            {
                Name = "East Hall",
                TicketsList = [],
                ReducedTicketsCount = 0,
            },
            SouthHall = new Hall()
            {
                Name = "South Hall",
                TicketsList = [],
                ReducedTicketsCount = 0,
            },
        };

        public IActionResult Index()
        {
            int counter = 0;
            foreach (var tic in gestional.NorthHall.TicketsList)
            {
                if (tic.IsReduced)
                {
                    counter++;
                }
            }
            gestional.NorthHall.ReducedTicketsCount = counter;

            counter = 0;
            foreach (var tic in gestional.EastHall.TicketsList)
            {
                if (tic.IsReduced)
                {
                    counter++;
                }
            }
            gestional.EastHall.ReducedTicketsCount = counter;

            counter = 0;
            foreach (var tic in gestional.SouthHall.TicketsList)
            {
                if (tic.IsReduced)
                {
                    counter++;
                }
            }
            gestional.SouthHall.ReducedTicketsCount = counter;

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
                TempData["ModelError"] = "Something went wrong, check your data!";
                return RedirectToAction("Sell");
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
                    if (gestional.NorthHall?.TicketsList?.Count < 120)
                    {
                        gestional.NorthHall?.TicketsList?.Add(newTicket);
                    }
                    else
                    {
                        TempData["Error"] = "Hall is full!";
                        return RedirectToAction("Sell");
                    }
                    break;

                case "East Hall":
                    if (gestional.EastHall?.TicketsList?.Count < 120)
                    {
                        gestional.EastHall?.TicketsList?.Add(newTicket);
                    }
                    else
                    {
                        TempData["Error"] = "Hall is full!";
                        return RedirectToAction("Sell");
                    }
                    break;

                case "South Hall":
                    if (gestional.SouthHall?.TicketsList?.Count < 120)
                    {
                        gestional.SouthHall?.TicketsList?.Add(newTicket);
                    }
                    else
                    {
                        TempData["Error"] = "Hall is full!";
                        return RedirectToAction("Sell");
                    }
                    break;

                default:
                    break;
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Ticket/Edit/{hall}/{id:guid}")]
        public IActionResult Edit(string hall, Guid id)
        {
            Ticket? selectedTicket;
            switch (hall)
            {
                case "NorthHall":
                    selectedTicket = gestional?.NorthHall?.TicketsList?.FirstOrDefault(t =>
                        t.Id == id
                    );

                    if (selectedTicket != null)
                    {
                        var ticket = new EditTicketModel()
                        {
                            Id = id,
                            Name = selectedTicket.Name,
                            Surname = selectedTicket.Surname,
                            Hall = selectedTicket.Hall,
                            IsReducedStr = null,
                            IsReduced = selectedTicket.IsReduced,
                        };

                        gestional?.NorthHall?.TicketsList?.Remove(selectedTicket);

                        return View(ticket);
                    }
                    break;

                case "EastHall":
                    selectedTicket = gestional?.EastHall?.TicketsList?.FirstOrDefault(t =>
                        t.Id == id
                    );

                    if (selectedTicket != null)
                    {
                        var ticket = new EditTicketModel()
                        {
                            Id = id,
                            Name = selectedTicket.Name,
                            Surname = selectedTicket.Surname,
                            Hall = selectedTicket.Hall,
                            IsReducedStr = null,
                            IsReduced = selectedTicket.IsReduced,
                        };

                        gestional?.EastHall?.TicketsList?.Remove(selectedTicket);

                        return View(ticket);
                    }
                    break;

                case "SouthHall":
                    selectedTicket = gestional?.SouthHall?.TicketsList?.FirstOrDefault(t =>
                        t.Id == id
                    );

                    if (selectedTicket != null)
                    {
                        var ticket = new EditTicketModel()
                        {
                            Id = id,
                            Name = selectedTicket.Name,
                            Surname = selectedTicket.Surname,
                            Hall = selectedTicket.Hall,
                            IsReducedStr = null,
                            IsReduced = selectedTicket.IsReduced,
                        };

                        gestional?.SouthHall?.TicketsList?.Remove(selectedTicket);

                        return View(ticket);
                    }
                    break;

                default:
                    break;
            }

            return RedirectToAction("Index");
        }

        [HttpPost("/Ticket/Edit/Save/{id:guid}")]
        public IActionResult EditTicket(EditTicketModel editTicketModel, Guid id)
        {
            // TODO implementare modifica biglietto
            if (!ModelState.IsValid)
            {
                TempData["ModelError"] = "Something went wrong, check your data!";
                return RedirectToAction("Sell");
            }

            var reduced = editTicketModel.IsReducedStr == "true" ? true : false;

            var newTicket = new Ticket()
            {
                Id = id,
                Name = editTicketModel.Name,
                Surname = editTicketModel.Surname,
                Hall = editTicketModel.Hall,
                IsReduced = reduced,
            };

            switch (editTicketModel.Hall)
            {
                case "North Hall":
                    if (gestional.NorthHall?.TicketsList?.Count < 120)
                    {
                        gestional?.NorthHall?.TicketsList?.Add(newTicket);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Error"] = "Hall is full!";
                        return RedirectToAction("Edit");
                    }

                case "East Hall":
                    if (gestional.EastHall?.TicketsList?.Count < 120)
                    {
                        gestional?.EastHall?.TicketsList?.Add(newTicket);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Error"] = "Hall is full!";
                        return RedirectToAction("Edit");
                    }

                case "South Hall":
                    if (gestional.SouthHall?.TicketsList?.Count < 120)
                    {
                        gestional?.SouthHall?.TicketsList?.Add(newTicket);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Error"] = "Hall is full!";
                        return RedirectToAction("Edit");
                    }

                default:
                    break;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string hall, Guid id)
        {
            return RedirectToAction("Index");
        }
    }
}
