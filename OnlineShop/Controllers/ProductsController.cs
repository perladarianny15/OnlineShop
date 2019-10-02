using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using OnlineShop.Repository;

namespace OnlineShop.Views
{
    public class ProductsController : Controller
    {
        ProductRepository productsRepository = new ProductRepository();
        Product Product = new Product();
        Customer customer = new Customer();
        CustomerOrder customerOrder = new CustomerOrder();
        CustomerOrderRepository customerOrderRepository = new CustomerOrderRepository();
        CustomerRepository customRepository = new CustomerRepository();
        // GET: Products
        public ActionResult Index()
        {
            var ProductList = productsRepository.ProductList();

            return View(ProductList.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productsRepository.FindProductByID(id);
            Product = productsRepository.ProductList().Where(x => x.ProductID == id).FirstOrDefault();
            if (Product == null)
            {
                return HttpNotFound();
            }
            return View(Product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProducttName,ProductCategory,ProductDescription,ProductPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                productsRepository.RegisterProduct(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productsRepository.FindProductByID(id);
            Product = productsRepository.ProductList().Where(x => x.ProductID == id).FirstOrDefault();
            if (Product == null)
            {
                return HttpNotFound();
            }
            return View(Product);
        }

        // POST: Products/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProducttName,ProductCategory,ProductDescription,ProductPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                productsRepository.UpdateProductByID(product.ProductID, product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productsRepository.FindProductByID(id);
            Product = productsRepository.ProductList().Where(x => x.ProductID == id).FirstOrDefault();
            if (Product == null)
            {
                return HttpNotFound();
            }
            return View(Product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productsRepository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult GetSelectedItem(int id)
        {
            DateTime date = DateTime.Now;
            string format = string.Empty;

            string nombre = TempData["UserName"] as string;
            string Email = TempData["UserEmail"] as string;

            Product = productsRepository.ProductList().Where(x => x.ProductID == id).FirstOrDefault();
            customer = customRepository.CustomerList().Where(x => x.FirstName == nombre || x.Email == Email).FirstOrDefault();
            


            if (Product != null && customer != null)
            {
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                customerOrder.OrderDate = sqlFormattedDate;
                customerOrder.OrderStatus = "Active";
                customerOrder.Product_id = Product.ProductID;
                customerOrder.CustomerID = customer.CustomerId;
                customerOrderRepository.RegisterCustomerOrder(customerOrder);
            }

            return RedirectToAction("Index");

        }

    }
}
