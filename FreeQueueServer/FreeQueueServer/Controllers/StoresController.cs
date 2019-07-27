using FreeQueueServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FreeQueueServer.Controllers
{
    [RoutePrefix("api/Store")]
    public class StoresController : ApiController
    {
        DB_freeQueueEntities DB = new DB_freeQueueEntities();

        /// <summary>
        /// convert store object from DTO object to SQL object
        /// </summary>
        /// <param name="store"></param>
        /// <returns>tbl_stores</returns>
        public tbl_stores ConvertFromDto(StoresDTO store)
        {
            return new tbl_stores()
            {
                Id = store.id,
                StoreName = store.storeName,
                StoreAddress = store.storeAddress,
                Phone = store.phone,
                About = store.about,
                KashrutCertification = store.kashrutCertifiction,
                Img = store.img,
                StoreCategory = store.storeCategory,
                ReservedSeats = store.reservedSeats,
                Club = store.club,
                Tip=store.tip,
                StoreLoad = store.storeLoad,
                Bank = store.bank,
                Brunch = store.brunch,
                Account = store.account,
            };
        }

        // GET: api/Stores
        /// <summary>
        /// return the stores list
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [Route("GetStores")]
        public IHttpActionResult Get()
        {
            return Ok(StoresDTO.ConvertToDTO(DB.tbl_stores.ToList()));
        }

        // GET: api/Stores/5
        /// <summary>
        /// get Id and retun the match store
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StoresDTO</returns>
        [Route("GetStoreDetails/{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(StoresDTO.ConvertToDTO(DB.tbl_stores.FirstOrDefault(s => s.Id == id)));
        }

        // POST: api/Stores
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stores/5
        /// <summary>
        /// update exists store
        /// </summary>
        /// <param name="id"></param>
        /// <param name="store"></param>
        /// <returns></returns>
        [Route("UpdateStoreDetails/{id}")]
        public IHttpActionResult Put(int id, [FromBody]StoresDTO store)
        {
            DB.Entry(ConvertFromDto(store)).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
            return Ok(StoresDTO.ConvertToDTO(DB.tbl_stores.ToList()));
        }

        // DELETE: api/Stores/5
        /// <summary>
        /// delete store by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IHttpActionResult</returns>
        [Route("DeleteStore/{id}")]
        public IHttpActionResult Delete(int id)
        {
            DB.tbl_stores.Remove(DB.tbl_stores.FirstOrDefault(s => s.Id == id));
            DB.SaveChanges();
            return Ok(StoresDTO.ConvertToDTO(DB.tbl_stores.ToList()));
        }        
        
    }
}
