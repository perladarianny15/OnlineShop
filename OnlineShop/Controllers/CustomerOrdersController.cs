using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using OnlineShop.Repository;

namespace OnlineShop.Views
{
    public class CustomerOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerOrders
        CustomerOrderRepository customerOrderRepository = new CustomerOrderRepository();
        public ActionResult Index()
        {
            var CostumerList = customerOrderRepository.CustomerList();

            return View(CostumerList.ToList());
        }

        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder customerOrder = new CustomerOrder();
            customerOrder = customerOrderRepository.CustomerList().Where(x => x.CustomerID == id).FirstOrDefault();
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            return View(customerOrder);
        }

        // POST: CustomerOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerOrder customerOrder = new CustomerOrder();
            customerOrderRepository.DeleteOrder(id);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
