using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Test.Models;

namespace finance.Controllers
{
    public class CustomersTableViewController : ApiController
    {
        // GET api/CustomersTableView
        public HttpResponseMessage Get()
        {
            using (LoanDBContext db = new LoanDBContext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.customers.ToList());
                
            }
        }

        // GET api/CustomersTableView/id      
        public HttpResponseMessage Get(Guid? id)
        {
            try
            {
                using (LoanDBContext db = new LoanDBContext())
                {
                    var entity = db.customers.Find(id);

                    if (entity != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer with Id =" + id.ToString() + " not found");
                    }
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
        }

        // Post
        [HttpPost]
        public HttpResponseMessage updateCustomerDetails([FromBody] customer customer)
        {
            try
            {
                using (LoanDBContext db = new LoanDBContext())
                {
                        customer.CustomerID = Guid.NewGuid();
                        db.customers.Add(customer);
                        db.SaveChanges();

                        var message = Request.CreateResponse(HttpStatusCode.Created, customer);
                        message.Headers.Location = new Uri(Request.RequestUri + customer.CustomerID.ToString());
                        return message;                    
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage deleteCustomerRecord(Guid? id)
        {
            try
            {
                using (LoanDBContext db = new LoanDBContext())
                {
                    customer customer = db.customers.Find(id);

                    if (customer == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer with Id =" + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        db.customers.Remove(customer);
                        db.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, customer);
                    }

                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        //Put
        public HttpResponseMessage Put(Guid? id, [FromBody]customer customer)
        {
            try
            {
                using (LoanDBContext db = new LoanDBContext())
                {
                    var entity = db.customers.Find(id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer with Id =" + id.ToString() + " not found to Update");
                    }
                    else
                    {
                        entity.Title = customer.Title;
                        entity.ForeName = customer.ForeName;
                        entity.MiddleInitial = customer.MiddleInitial;
                        entity.SurName = customer.SurName;
                        entity.DateofBirth = customer.DateofBirth;
                        entity.Status = customer.Status;

                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, customer);
                    }
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}