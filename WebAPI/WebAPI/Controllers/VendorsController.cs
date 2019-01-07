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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class VendorsController : ApiController
    {
        private SampleDBEntities db = new SampleDBEntities();

        // GET: api/GetVendors
        [Route("api/GetVendors")]
        public IQueryable<Vendor> GetVendors()
        {
            return db.Vendors;
        }

        [Route("api/GetBranches/{id}")]
        public IEnumerable<Branch> GetBranches(int id)
        {
            return db.Branches.ToList().Where(b=>b.VendorID==id);
        }

        // GET: api/Branches/5
        [Route("api/GetProducts/{id}/{vendorid}")]
        public IEnumerable<Product> GetProducts(int id,int vendorid)
        {
            return db.Products.ToList().Where(p => p.ID == id && p.VenderID==vendorid);
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