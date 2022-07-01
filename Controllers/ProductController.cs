using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Data;
using ShopBridge.Models;
using ShopBridge.ViewModels;
using System;
using System.Linq;

namespace ShopBridge.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;
        private readonly IProductRepository _product;

        //Constructor
        public ProductController(ApplicationDbContext context, IHostingEnvironment env, IProductRepository product)
        {
            _context = context;
            _env = env;
            _product = product;
        }

        public IActionResult Index()
        {
            var model = _product.GetAllProducts();
            return View(model);
        }

        public IActionResult Details(int? id)
        {
            DetailsProductViewModel detailsProductViewModel = new DetailsProductViewModel()
            {
                Products = _product.GetProduct(id ?? 1)
            };
            return View(detailsProductViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var products = _context.Products;
            ViewData["ProductCode"] = products.Count() + 1;
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddProductViewModel model)
        {
            //model.Amount = model.Qty * model.Price;

            try
            {
                if (ModelState.IsValid)
                {
                    Product newProduct = new Product
                    {
                        ProductCode = model.ProductCode,
                        ProductDate = model.Date,
                        ProductName = model.ProductName,
                        ProductDescription = model.ProductDescription,
                        Price = model.Price,
                        Qty = model.Qty,
                        Amount=model.Qty*model.Price,
                        NarrationRemarks=model.Narration
                    };
                    _product.Add(newProduct);
                    return RedirectToAction("Details", new { id = newProduct.ProductId });
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = _product.GetProduct(id);

            EditProductViewModel editProductViewModel = new EditProductViewModel
            {
                ProductId = product.ProductId,
                Date = product.ProductDate,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName, 
                ProductDescription= product.ProductDescription,
                Price = product.Price,
                Qty= product.Qty,
                Amount=product.Amount,
                Narration=product.NarrationRemarks,
                Username=product.Username,
            };
            return View(editProductViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditProductViewModel model)
        {
            model.Amount=model.Qty * model.Price;

            if (ModelState.IsValid)
            {
                Product product = _product.GetProduct(model.ProductId);

                product.ProductDate = model.Date;
                product.ProductCode = model.ProductCode;
                product.ProductName = model.ProductName;
                product.ProductDescription= model.ProductDescription;
                product.Price = model.Price;
                product.Qty= model.Qty;
                product.Amount= model.Qty * model.Price;
                product.NarrationRemarks = model.Narration;
                product.Username= model.Username;

                Product updateProduct = _product.Update(product);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Product product = _product.GetProduct(id);
            if(product == null)
            {
                return BadRequest("Product not found.");
                //return View("Error");
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(int id, string Delete)
        {
            try
            {
                Product product= _product.GetProduct(id);
                if(product != null)
                {
                    _product.Delete(id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
