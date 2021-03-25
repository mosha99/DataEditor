using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataEditor;

namespace DataEditor.Controllers
{
    public class CRM_CustomerController : ApiController
    {
        private CRM2008 db = new CRM2008();

        // GET: api/CRM_Customer
        public IQueryable<CRM_Customer> GetCRM_Customer()
        {
            return db.CRM_Customer;
        }

        // GET: api/CRM_Customer/5
        [ResponseType(typeof(CRM_Customer))]
        public IHttpActionResult GetCRM_Customer(int id)
        {
            CRM_Customer cRM_Customer = db.CRM_Customer.Find(id);
            if (cRM_Customer == null)
            {
                return NotFound();
            }

            return Ok(cRM_Customer);
        }

        // PUT: api/CRM_Customer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCRM_Customer(int id, CRM_Customer cRM_Customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cRM_Customer.SHS_ID)
            {
                return BadRequest();
            }

            db.Entry(cRM_Customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CRM_CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CRM_Customer
        [ResponseType(typeof(CRM_Customer))]
        public IHttpActionResult PostCRM_Customer(CRM_Customer cRM_Customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CRM_Customer.Add(cRM_Customer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CRM_CustomerExists(cRM_Customer.SHS_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cRM_Customer.SHS_ID }, cRM_Customer);
        }

        // DELETE: api/CRM_Customer/5
        [ResponseType(typeof(CRM_Customer))]
        public IHttpActionResult DeleteCRM_Customer(int id)
        {
            CRM_Customer cRM_Customer = db.CRM_Customer.Find(id);
            if (cRM_Customer == null)
            {
                return NotFound();
            }

            db.CRM_Customer.Remove(cRM_Customer);
            db.SaveChanges();

            return Ok(cRM_Customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CRM_CustomerExists(int id)
        {
            return db.CRM_Customer.Count(e => e.SHS_ID == id) > 0;
        }
    }
}