using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EShop.Web.Data;
using System.Security.Claims;
using EShop.Repository;
using EShop.Domain.DomainModels;
using EShop.Domain.DTO;
using EShop.Services.Interface;

namespace EShop.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IProductService _productService;

        public TicketsController(IProductService productServicet)
        {
            _productService = productServicet;
        }

        // GET: Tickets
        public IActionResult Index()
        {
            var allTickets = this._productService.GetAllProducts();
            return View(allTickets);
        }

        // GET: Tickets/Details/5
        public IActionResult Details(Guid? id)
        {
                if (id == null)
                {
                    return NotFound();
                }

                var product = this._productService.GetDetailsForProduct(id);

                if (product == null)
                {
                    return NotFound();
                }

                return View(product);
        }

        public IActionResult AddTicketToCart(Guid? id)
        {
            var model = this._productService.GetShoppingCartInfo(id);
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTicketToCart([Bind("TicketId", "Quantity")] AddToShoppingCardDto item)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._productService.AddToShoppingCart(item, userId);
            if (result)
            {
                return RedirectToAction("Index", "Tickets");
            }

            return View(item);
        }



        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,TicketName,MovieName,Genre,Price,dateValid")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                this._productService.CreateNewProduct(ticket);
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = this._productService.GetDetailsForProduct(id);

            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,TicketName,MovieName,Genre,Price,dateValid")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._productService.UpdeteExistingProduct(ticket);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public IActionResult Delete(Guid? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var ticket = this._productService.GetDetailsForProduct(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            this._productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(Guid id)
        {
            return _productService.GetDetailsForProduct(id) != null;
        }
    }
}
