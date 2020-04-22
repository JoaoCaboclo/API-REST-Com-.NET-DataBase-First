using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebAppJohn.DAL;


namespace WebAppJohn.Controllers
{
    public class ProductsJohnsController : ApiController
    {
        private ModelProductsJohn db = new ModelProductsJohn();

        // GET: api/ProductsJohns  
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IQueryable<ProductsJohn> GetProductsJohn()
        {
            return db.ProductsJohn;
        }

        // GET: api/ProductsJohns/5
        [ResponseType(typeof(ProductsJohn))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult GetProductsJohn(int id)
        {
            ProductsJohn productsJohn = db.ProductsJohn.Find(id);
            if (productsJohn == null)
            {
                return NotFound();
            }

            return Ok(productsJohn);
        }

        // PUT: api/ProductsJohns/5
        [ResponseType(typeof(void))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PutProductsJohn(int id, ProductsJohn productsJohn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productsJohn.ID)
            {
                return BadRequest();
            }

            db.Entry(productsJohn).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsJohnExists(id))
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

        // POST: api/ProductsJohns
        [ResponseType(typeof(ProductsJohn))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PostProductsJohn(ProductsJohn productsJohn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductsJohn.Add(productsJohn);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productsJohn.ID }, productsJohn);
        }

        // DELETE: api/ProductsJohns/5
        [ResponseType(typeof(ProductsJohn))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult DeleteProductsJohn(int id)
        {
            ProductsJohn productsJohn = db.ProductsJohn.Find(id);
            if (productsJohn == null)
            {
                return NotFound();
            }

            db.ProductsJohn.Remove(productsJohn);
            db.SaveChanges();

            return Ok(productsJohn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductsJohnExists(int id)
        {
            return db.ProductsJohn.Count(e => e.ID == id) > 0;
        }
    }
}