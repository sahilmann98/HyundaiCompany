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
using HyundaiCompany.Api.Models;

namespace HyundaiCompany.Api.Controllers
{
    public class CarMastersController : ApiController
    {
        private HyundaiCompanyEntities db = new HyundaiCompanyEntities();

        // GET: api/CarMasters
        public IQueryable<CarMaster> GetCarMasters()
        {
            return db.CarMasters;
        }

        // GET: api/CarMasters/5
        [ResponseType(typeof(CarMaster))]
        public IHttpActionResult GetCarMaster(int id)
        {
            CarMaster carMaster = db.CarMasters.Find(id);
            if (carMaster == null)
            {
                return NotFound();
            }

            return Ok(carMaster);
        }

        // PUT: api/CarMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarMaster(int id, CarMaster carMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carMaster.ID)
            {
                return BadRequest();
            }

            db.Entry(carMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarMasterExists(id))
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

        // POST: api/CarMasters
        [ResponseType(typeof(CarMaster))]
        public IHttpActionResult PostCarMaster(CarMaster carMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CarMasters.Add(carMaster);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carMaster.ID }, carMaster);
        }

        // DELETE: api/CarMasters/5
        [ResponseType(typeof(CarMaster))]
        public IHttpActionResult DeleteCarMaster(int id)
        {
            CarMaster carMaster = db.CarMasters.Find(id);
            if (carMaster == null)
            {
                return NotFound();
            }

            db.CarMasters.Remove(carMaster);
            db.SaveChanges();

            return Ok(carMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarMasterExists(int id)
        {
            return db.CarMasters.Count(e => e.ID == id) > 0;
        }
    }
}