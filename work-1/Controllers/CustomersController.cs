
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using work_1.Models;
using work_1.Models.ViewModels;

namespace work_1.Controllers
{

    public class CustomersController : Controller
    {
        private readonly FashionDbContext db = new FashionDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(x => x.OrderEntries.Select(o => o.Product))
                .OrderByDescending(x => x.CustomersId)
                .ToList();

            return View(customers);
        }

        public ActionResult AddNewProduct(int? id)
        {
            ViewBag.product = new SelectList(db.Products.ToList(), "ProductsId", "ProductsName", (id != null) ? id.ToString() : "");
            return PartialView("_addNewProduct");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerVM customerVM, int[] productId)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer()
                {
                    CustomersName = customerVM.CustomersName,
                    PaymentDate = customerVM.PaymentDate,
                    CustomerSize = customerVM.CustomerSize,
                    UrgentDelivery = customerVM.UrgentDelivery
                };

                // Image Process
                HttpPostedFileBase file = customerVM.PictureFile;
                if (file != null)
                {
                    string fileName = Path.Combine("/Images/", DateTime.Now.Ticks.ToString() + Path.GetExtension(file.FileName));
                    file.SaveAs(Server.MapPath(fileName));
                    customer.Picture = fileName;
                }

                db.Customers.Add(customer);

                if (productId != null)
                {
                    foreach (var item in productId)
                    {
                        OrderEntry orderEntry = new OrderEntry()
                        {
                            Customer = customer,
                            CustomersId = customer.CustomersId,
                            ProductsId = item
                        };
                        db.OrderEntries.Add(orderEntry);
                    }
                }

                db.SaveChanges();
                return PartialView("_success");
            }
            return PartialView("_error");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();

            Customer customer = db.Customers.FirstOrDefault(x => x.CustomersId == id);
            if (customer == null) return HttpNotFound();

            var customerProducts = db.OrderEntries.Where(x => x.CustomersId == id).ToList();

            CustomerVM customerVM = new CustomerVM()
            {
                CustomersId = customer.CustomersId,
                CustomersName = customer.CustomersName,
                PaymentDate = customer.PaymentDate,
                CustomerSize = customer.CustomerSize,
                Picture = customer.Picture,
                UrgentDelivery = customer.UrgentDelivery
            };

            if (customerProducts.Count > 0)
            {
                foreach (var item in customerProducts)
                {
                    customerVM.ProductList.Add(item.ProductsId);
                }
            }

            return View(customerVM);
        }

        [HttpPost]
        public ActionResult Edit(CustomerVM customerVM, int[] productId)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer()
                {
                    CustomersId = customerVM.CustomersId,
                    CustomersName = customerVM.CustomersName,
                    PaymentDate = customerVM.PaymentDate,
                    CustomerSize = customerVM.CustomerSize,
                    UrgentDelivery = customerVM.UrgentDelivery
                };

                // Image Process
                HttpPostedFileBase file = customerVM.PictureFile;
                if (file != null)
                {
                    string fileName = Path.Combine("/Images/", DateTime.Now.Ticks.ToString() + Path.GetExtension(file.FileName));
                    file.SaveAs(Server.MapPath(fileName));
                    customer.Picture = fileName;
                }
                else
                {
                    customer.Picture = customerVM.Picture;
                }

                db.Entry(customer).State = EntityState.Modified;

                var existingEntries = db.OrderEntries.Where(x => x.CustomersId == customer.CustomersId).ToList();
                db.OrderEntries.RemoveRange(existingEntries);

                // Add new entries back in
                if (productId != null)
                {
                    foreach (var item in productId)
                    {
                        OrderEntry orderEntry = new OrderEntry()
                        {
                            CustomersId = customer.CustomersId,
                            ProductsId = item
                        };
                        db.OrderEntries.Add(orderEntry);
                    }
                }

                db.SaveChanges();
                return PartialView("_success");
            }
            return PartialView("_error");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound();

            Customer customer = db.Customers.FirstOrDefault(x => x.CustomersId == id);
            if (customer == null) return HttpNotFound();

            var customerProducts = db.OrderEntries.Where(x => x.CustomersId == id).ToList();

            CustomerVM customerVM = new CustomerVM()
            {
                CustomersId = customer.CustomersId,
                CustomersName = customer.CustomersName,
                PaymentDate = customer.PaymentDate,
                CustomerSize = customer.CustomerSize,
                Picture = customer.Picture,
                UrgentDelivery = customer.UrgentDelivery
            };

            if (customerProducts.Any())
            {
                foreach (var item in customerProducts)
                {
                    customerVM.ProductList.Add(item.ProductsId);
                }
            }
            return View(customerVM);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);

            if (customer == null) return HttpNotFound();

            var productEntries = db.OrderEntries.Where(x => x.CustomersId == customer.CustomersId).ToList();
            db.OrderEntries.RemoveRange(productEntries);

            db.Customers.Remove(customer);

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}