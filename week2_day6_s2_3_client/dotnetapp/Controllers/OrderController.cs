using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using dotnetapp.Models; // Replace with the actual namespace

namespace dotnetapp.Controllers // Replace with the actual namespace
{
    public class OrderController : Controller
    {
        private readonly OrdersDbContext _context;

        public OrderController(OrdersDbContext context)
        {
            _context = context;
        }

        public IActionResult DisplayCustomers()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public IActionResult DisplayProductsWithCategories()
        {
            var productsWithCategories = _context.Products.Include(p => p.Category).ToList();
            return View(productsWithCategories);
        }

        public IActionResult DisplayOrderDetails()
        {
            var orderDetails = _context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Product)
                .ToList();

            return View(orderDetails);
        }

        public IActionResult DisplayCategoryInfo()
        {
            var categoryInfo = _context.Products
                .GroupBy(p => p.Category)
                .Select(g => new CategoryInfoViewModel
                {
                    CategoryName = g.Key != null ? g.Key.CategoryName : "N/A",
                    ProductCount = g.Count()
                })
                .ToList();

            return View(categoryInfo);
        }
    }
}
