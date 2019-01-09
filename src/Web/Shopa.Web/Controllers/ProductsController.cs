using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Shopa.Data;
using Shopa.Data.Models;
using Shopa.Data.Models.Enums;
using Shopa.Web.Services;

namespace Shopa.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopaDbContext _context;
        private UserManager<ShopaUser> _userManager;

        public ProductsController(ShopaDbContext context, UserManager<ShopaUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Price,PictureLocalPath,Category,Id")] Product product)
        {
            if (ModelState.IsValid)
            {
                var path = product.PictureLocalPath;
                path = path.Replace('\\', '/');
                string result = "";
                var count = 0;

                string str = "";

                for (int i = path.Length - 1; i >= 0; i--)
                {
                    if (path[i].Equals('/'))
                    {
                        count++;
                    }

                    if (count == 2)
                    {
                        break;
                    }

                    str += (path[i]);
                }

                result = Reverse(str);
                result.Replace('/', '\\');
                product.PictureLocalPath = result;
                var user = this._userManager.GetUserAsync(this.User).GetAwaiter().GetResult();
                product.User = user;
                user.Products.Add(product);

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,Price,TimeOfCreation,PictureLocalPath,StoreId,Category,Id, ")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
        private static string Reverse(string result)
        {
            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public async Task<IActionResult> GetAllProductsByCategories(Category category)
        {
            return View(await _context.Products.Where(x => x.Category == category).ToListAsync());
        }


        public async Task<IActionResult> GetAllProducts()
        {
            return View(await _context.Products.ToListAsync());
        }

        public async Task<IActionResult> AddToFavorite(int productId)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            if (product != null && !product.Equals(null))
            {

                var user = _userManager.GetUserAsync(this.User).GetAwaiter().GetResult();
                if (user.Products.Contains(product))
                {
                    user.Products.Remove(product);
                }
                else
                {
                    user.Products.Add(product);
                }

                await _context.SaveChangesAsync();
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetQuantityIfOrderedProduct(int quantity)
        {
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            if (product != null && !product.Equals(null))
            {

                var user = _userManager.GetUserAsync(this.User).GetAwaiter().GetResult();
                //if (!user.Orders.Any())
                //{
                OrderProduct orderProduct = new OrderProduct()
                {
                    Product = product,
                    Quantity = quantity
                };

                var order = PrepareOrder(product, user);
                order.Products.Add(orderProduct);

                var totalPrice = CaltulateOrderTotalPrice(order);

                order.TotalPrice = totalPrice;
                //order.User.Id = user.Id;

                    user.Orders.Add(order);
                _context.Orders.Add(order);
                //    await _context.SaveChangesAsync();
                ////}
                ////else
                ////{
                //    user.Orders.Add(order);
                //    _context.Orders.Add(order);
                ////}

                await _context.SaveChangesAsync();
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        private decimal CaltulateOrderTotalPrice(Order order)
        {
            decimal result = 0;
            foreach (var product in order.Products)
            {
                var pricePerProduct = product.Product.Price;
                var quantity = product.Quantity;
                var total = pricePerProduct * quantity;

                result += total;
            }

            return result;
        }

        private Order PrepareOrder(Product product, ShopaUser user)
        {
            Order order = new Order()
            {
                User = user,
                Products = new List<OrderProduct>()
                {

                }
            };
            return order;
        }
    }
}
