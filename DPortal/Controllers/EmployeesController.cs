//using DPortal.Factory;
using DPortal.Builder.ConcreteBuilder;
using DPortal.Builder.IBuilder;
using DPortal.Factory.AbstractFactory;
using DPortal.Factory.FactoryMethod;
using DPortal.Models;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Director = DPortal.Builder.Director;

namespace DPortal.Controllers
{
    public class EmployeesController : BaseController
    {
        private EmployeePortalEntities db = new EmployeePortalEntities();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.EmployeeType);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "Id", "Types");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,JobDesc,Number,Department,HourlyPay,Bonus,EmployeeTypeId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                //EmployeeManagerFactory empFactory = new EmployeeManagerFactory();
                //IEmployeeManager empManager = empFactory.GetEmployeeManager(employee.EmployeeTypeId);
                //if (empManager != null)
                //{
                //    employee.Bonus = empManager.GetBonus();
                //    employee.HourlyPay = empManager.GetHourlyPay();
                //}

                BaseEmployeeFactory employeeFactory = new EmployeeManagerFactory().CreateFactory(employee);
                employeeFactory.ApplySalary();

                IComputerFactory computerFactory = new EmployeeSystemFactory().Create(employee);
                EmployeeSystemManager manager = new EmployeeSystemManager(computerFactory);
                employee.ComputerDetails = manager.GetSystemDetails();

                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "Id", "Types", employee.EmployeeTypeId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "Id", "Types", employee.EmployeeTypeId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,JobDesc,Number,Department,HourlyPay,Bonus,EmployeeTypeId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "Id", "Types", employee.EmployeeTypeId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult BuildSystem(int? Id)
        {
            //return View(Id);
            Employee employee = db.Employees.Find(Id);
            if (employee.ComputerDetails.Contains("Laptop"))
            {
                return View("BuildLaptop", Id);
            }
            else
            {
                return View("BuildDesktop", Id);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuildLaptop(FormCollection collection)
        {
            Employee employee = db.Employees.Find(Convert.ToInt32(collection["Id"]));
            ISystemBuilder systemBuilder = new LaptopBuilder();

            Director.ConfigurationBuilder configurationBuilder = new Director.ConfigurationBuilder();
            configurationBuilder.BuildSystem(systemBuilder, collection);
            ComputerSystem computerSystem = systemBuilder.GetSystem();

            employee.SystemConfigurationDetails = string.Format("RAM: {0},HDDSize: {1},TouchScreen: {2}", computerSystem.RAM,
                computerSystem.HDDSize, computerSystem.TouchScreen);

            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuildDesktop(FormCollection collection)
        {
            Employee employee = db.Employees.Find(Convert.ToInt32(collection["Id"]));
            ISystemBuilder systemBuilder = new DesktopBuilder();

            Director.ConfigurationBuilder configurationBuilder = new Director.ConfigurationBuilder();
            configurationBuilder.BuildSystem(systemBuilder, collection);
            ComputerSystem computerSystem = systemBuilder.GetSystem();

            employee.SystemConfigurationDetails = string.Format("RAM: {0},HDDSize: {1},Keyboard: {2},Mouse: {3}", computerSystem.RAM,
                computerSystem.HDDSize, computerSystem.Keyboard, computerSystem.Mouse );

            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult BuildSystem(int Id, string RAM, string HDD)
        //{
        //    Employee employee = db.Employees.Find(Id);
        //    ComputerSystem computerSystem = new ComputerSystem(RAM, HDD);
        //    employee.SystemConfigurationDetails = computerSystem.Build();
        //    db.Entry(employee).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
