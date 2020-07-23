using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace finance.Controllers
{
    public class loansController : Controller
    {
        int nextLoanNum = 2000;
        private LoanDBContext db = new LoanDBContext();

        // GET: loans
        public ActionResult Index()
        {
            var loans = db.loans.ToList();
            return View(loans);
        }

        // GET: loans/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loans loans = db.loans.Find(id);
            if (loans == null)
            {
                return HttpNotFound();
            }
            return View(loans);
        }

        public ActionResult CreateNew()
        {
            return View();
        }

        // GET: loans/Create
        [HttpPost]
        public ActionResult CreateLoan(string ForeName, String LastName)
        {
            loans loan = new loans();

            var customer = db.customers.Where(c => c.ForeName.ToUpper() == ForeName.ToUpper() &&
                                                c.SurName.ToUpper() == LastName.ToUpper()).FirstOrDefault();
            if (customer != null)
            {
                loan.CustomerForeName = customer.ForeName;
                loan.CustomerSurName = customer.SurName;
                loan.DateOfBirth = customer.DateofBirth;
            }
            else
            {
                TempData["CustomerInfo"] = "Customer not found. Please reveiw the information or create a customer profile.";
                return View(loan);
            }
            var lastLoan = db.loans.OrderByDescending(l => l.LoanNumber).FirstOrDefault();
            if (lastLoan == null)
            {
                loan.LoanNumber = nextLoanNum;
            }
            else
            {
                var lastloan = lastLoan.LoanNumber;
                loan.LoanNumber = lastloan + 1;
            }
            return View(loan);
        }

        // POST: loans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( loans loans)
        {
            if (ModelState.IsValid)
            {
                var existingLoans = db.loans.Where(l => l.LoanOriginatedBy == loans.LoanOriginatedBy
                                            && l.IsInactive == false).ToList();

                if (existingLoans.Count > 0)
                {
                    var number = existingLoans.Select(l => new { name = l.CustomerForeName + " " + l.CustomerSurName }).Distinct().ToList();
                    if (number.Count() > 10)
                    {
                        TempData["LoansCreation"] = "An error occured while creating the loan. Managers are not allowed to create loans if more than 10 active customer loans already exists.";
                        return RedirectToAction("Index");
                    }
                }

                loans.LoanID = Guid.NewGuid();
                db.loans.Add(loans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loans);
        }

        // GET: loans/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loans loans = db.loans.Find(id);
            if (loans == null)
            {
                return HttpNotFound();
            }
            return View(loans);
        }

        // POST: loans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoanID,LoanNumber,LoanType,StartDate,IntrestRate,Value,Duration,IsInactive,CustomerID,LoanOriginatedBy")] loans loans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loans);
        }

        // GET: loans/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loans loans = db.loans.Find(id);
            if (loans == null)
            {
                return HttpNotFound();
            }
            return View(loans);
        }

        // POST: loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            loans loans = db.loans.Find(id);

            var inactive = loans.IsInactive;

            if (inactive)
            {
                db.loans.Remove(loans);
                db.SaveChanges();
                TempData["Error Deletion"] = "Loan " + loans.LoanNumber +"deleted successfully";
                return RedirectToAction("Index");
            }

            TempData["Error Deletion"] = "Error Deleting the loan #" + loans.LoanNumber + ". This Loan is active. Deletion of an actve loans is not permissible";

            return RedirectToAction("Index");
        }

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
