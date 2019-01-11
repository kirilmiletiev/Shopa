using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Shopa.Data;
using Shopa.Data.Models;
using Shopa.Data.Models.Enums;
using Shopa.Services.Contracts;

namespace Shopa.Web.Controllers
{
    public class ProductsController : Controller
    {
        //private readonly ShopaDbContext _context;
        private UserManager<ShopaUser> _userManager;
        private IProductService _productService;
        private ShopaUser CurrentUser => _userManager.GetUserAsync(this.User).GetAwaiter().GetResult();

        public ProductsController( UserManager<ShopaUser> userManager, IProductService productService)
        {
            //_context = context;
            _userManager = userManager;
            this._productService = productService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllProductsAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound(); //TODO: ERROR VIEW
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Description,Price,PictureLocalPath,Category,Id")] Product product)
        {
            if (ModelState.IsValid)
            {
                var user = this._userManager.GetUserAsync(this.User).GetAwaiter().GetResult();
                product.User = user;
                user.Products.Add(product);
                _productService.AddProduct(product);
                _productService.SaveChanges();
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

            //var product = await _context.Products.FindAsync(id);
            var product = _productService.GetProductById(id);
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
        [Authorize(Roles = "Admin")]
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
                    //_context.Update(product);
                    //await _context.SaveChangesAsync();
                    product.PictureLocalPath = _productService.FixLocalPath(product.PictureLocalPath);
                    _productService.Update(product);
                    _productService.SaveChanges();
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

            //var product = await _context.Products
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var product = await _context.Products.FindAsync(id);
            var product = _productService.GetProductById(id);

            _productService.Remove(product);
            //await _context.SaveChangesAsync();
            _productService.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            //return _context.Products.Any(e => e.Id == id);
            return _productService.ProductExists(id);
        }
        public async Task<IActionResult> GetAllProductsByCategories(Category category)
        {
            return View(await _productService.GetAllProductsByCategories(category));
        }


        public async Task<IActionResult> GetAllProducts()
        {
            return View(await _productService.GetAllProductsAsync());
        }

        public async Task<IActionResult> AddToFavorite(int productId)
        {
            //var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            var product = _productService.GetProductById(productId);

            var user = await _userManager.GetUserAsync(this.User);

            if (product != null && !product.Equals(null) && user != null)
            {
                var isProductInFavorites = _productService.IsProductInFavorites(productId, user.Id);

                if (isProductInFavorites) // false
                {
                    var favoriteFromContext = _productService.GetFavorite(productId, user.Id);
                    if (favoriteFromContext.IsActive == false)
                    {
                        favoriteFromContext.IsActive = true;
                        _productService.SaveChanges();
                        return  RedirectToAction(nameof(MyFavorites));
                    }
                    _productService.RemoveFavorite(favoriteFromContext);
                }

                if (!isProductInFavorites) 
                {
                    Favorite favorite = new Favorite()
                    {
                        Product = product,
                        ShopaUser = user,
                    };

                    _productService.AddFavorite(favorite);
                }

                _productService.SaveChanges();
                return RedirectToAction(nameof(MyFavorites));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> MyFavorites()
        {
            return View(_productService.GetAllFavorites());
        }

        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            //var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            var product = _productService.GetProductById(productId);

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
                _productService.AddOrder(order);
                //_context.Orders.Add(order);
                //    await _context.SaveChangesAsync();
                ////}
                ////else
                ////{
                //    user.Orders.Add(order);
                //    _context.Orders.Add(order);
                ////}

                 _productService.SaveChanges();
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
