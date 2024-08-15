using ConsumerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsumerApi.Service;

namespace ConsumerApi.Controllers;

public class ProductController : Controller
{
    private readonly CrudService _productService;

    public ProductController(CrudService productService)
    {
        _productService = productService;
    }
    // GET: ProductController
    public ActionResult Index()
    {
        var products = _productService.GetAllProductsAsync();
        return View(products);
    }

    // GET: ProductController/Details/5
    public ActionResult Details(int id)
    {
        var product = _productService.GetProductByIdAsync(id);
        if (product == null)
            return NotFound();

        return View(product);
    }

    // GET: ProductController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ProductController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Product product)
    {
        if (ModelState.IsValid)
        {
            _productService.CreateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // GET: ProductController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: ProductController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Product product)
    {
        if (id != product.Id)
            return BadRequest();

        if (ModelState.IsValid)
        {
            _productService.UpdateProductAsync(id, product);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }
    // GET: ProductController/Delete/5
    public IActionResult Delete(int id)
    {
        var product = _productService.GetProductByIdAsync(id);
        if (product == null)
            return NotFound();

        return View(product);
    }
    // POST: ProductController/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _productService.DeleteProductAsync(id);
        return RedirectToAction(nameof(Index));
    }
}

    

    
    

    

    

    

  

