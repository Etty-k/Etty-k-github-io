using FreeQueueServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FreeQueueServer.Controllers
{
    public class OrderController : ApiController
    {

        DB_freeQueueEntities DB = new DB_freeQueueEntities();

        /// <summary>
        /// gets object of PurchaseDTO class and converts it to object of type tbl_purchases
        /// </summary> 
        /// <param name="purchase"></param>
        /// <returns>tbl_purchases</returns>
        public tbl_purchases ConvertFromDto(PurchaseDTO purchase)
        {
            return new tbl_purchases()
            {
                Id = purchase.id,
                CustomerName = purchase.customerName,
                CustomerPhone = purchase.customerPhone,
                DeliveryAddress = purchase.deliveryAddress,
                Club = purchase.club,
                CreditCard = purchase.creditCard,
                CreditDate = purchase.creditDate,
                CreditDigits = purchase.creditDigits,
                GroupName = purchase.groupName,
                PurchaseDate = purchase.purchaseDate,
                PurchaseSum = purchase.parchaseSum,
                ReceiptTime = purchase.receiptTime,
                ReservedSeats = purchase.reservedSeats,
                StoreId = DB.tbl_stores.FirstOrDefault(s => s.StoreName == purchase.store).Id,
                Tip = purchase.tip
            };
        }

        // GET: api/Order
        /// <summary>
        /// gets store id and returns all the orders of this store
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns>IHttpActionResult</returns>
        [Route("GetOrdersByStore/{id}")]
        public IHttpActionResult Get([FromBody] int storeId)
        {
            return Ok(PurchaseDTO.ConvertToDTO(DB.tbl_purchases.Where(p => p.StoreId == storeId).ToList()));
        }

        // GET: api/Order/5
        //public string GetList([FromBody]int storeId)
        //{
        //    //return 
        //}

        // POST: api/Order
        /// <summary>
        /// gets purchase and add it to DB
        /// </summary>
        /// <param name="purchase"></param>
        [Route("AddOrder")]
        public void Post([FromBody]PurchaseDTO purchase)
        {
            DB.tbl_purchases.Add(ConvertFromDto(purchase));
            DB.SaveChanges();
        }

        // PUT: api/Order/5
        /// <summary>
        /// updates purchase in the sql
        /// </summary>
        /// <param name="id"></param>
        /// <param name="purchase"></param>
        [Route("UpdateOrder/{id}")]
        public void Put(int id, [FromBody]PurchaseDTO purchase)
        {
            DB.Entry(ConvertFromDto(purchase)).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }

        // DELETE: api/Order/5
        /// <summary>
        /// deletes purchase from DB
        /// </summary>
        /// <param name="id"></param>
        [Route("DeleteOrder/{id}")]
        public void Delete(int id)
        {
            DB.tbl_purchases.Remove(DB.tbl_purchases.FirstOrDefault(p => p.Id == id));
            DB.SaveChanges();
        }

        /// <summary>
        /// gets group name and check if this group is already exists
        /// </summary>
        /// <param name="group"></param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult GroupExists([FromBody]string group)
        {
            if (DB.tbl_purchases.Where(p => p.GroupName == group) != null)
                return Ok(true);
            return Ok(false);
        }

        /// <summary>
        /// gets store id and returns if there is load in the store
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Load([FromBody]int storeId)
        {
            return Ok(DB.tbl_stores.FirstOrDefault(s => s.Id == storeId).StoreLoad);
        }
    }
}