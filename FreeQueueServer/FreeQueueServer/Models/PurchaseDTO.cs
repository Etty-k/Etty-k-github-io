using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeQueueServer.Models
{
    public class PurchaseDTO
    {
        public int id { get; set; }
        public string store { get; set; }
        public Nullable<DateTime> purchaseDate  { get; set; }
        public string customerName { get; set; }
        public string customerPhone { get; set; }
        public string creditCard { get; set; }
        public string creditDate { get; set; }
        public string creditDigits { get; set; }
        public string deliveryAddress { get; set; }
        public string groupName { get; set; }
        public Nullable<int> reservedSeats { get; set; }
        public Nullable<bool> club { get; set; }
        public Nullable<double> tip { get; set; }
        public Nullable<double> parchaseSum { get; set; }
        public string receiptTime { get; set; }

        /// <summary>
        /// get sql entity and convert it to simple object whithout references
        /// </summary>
        /// <param name="purchase"></param>
        /// <returns></returns>
        public static PurchaseDTO ConvertToDTO(tbl_purchases purchase)
        {
            return new PurchaseDTO()
            {
                id = purchase.Id,
                store = (purchase.StoreId != null) ? purchase.tbl_stores.StoreName : "",
                purchaseDate = purchase.PurchaseDate,
                customerName = purchase.CustomerName,
                customerPhone = purchase.CustomerPhone,
                creditCard = purchase.CreditCard,
                creditDate = purchase.CreditDate,
                creditDigits = purchase.CreditDigits,
                deliveryAddress = purchase.DeliveryAddress,
                groupName = purchase.GroupName,
                reservedSeats = purchase.ReservedSeats,
                club = purchase.Club,
                tip = purchase.Tip,
                parchaseSum = purchase.PurchaseSum,
                receiptTime = purchase.ReceiptTime
            };
        }

        public static List<PurchaseDTO> ConvertToDTO(List<tbl_purchases> purchases)
        {
            return purchases.Select(p=> new PurchaseDTO
            {
                id = p.Id,
                store = (p.StoreId != null) ? p.tbl_stores.StoreName : "",
                purchaseDate = p.PurchaseDate,
                customerName = p.CustomerName,
                customerPhone = p.CustomerPhone,
                creditCard = p.CreditCard,
                creditDate = p.CreditDate,
                creditDigits = p.CreditDigits,
                deliveryAddress = p.DeliveryAddress,
                groupName = p.GroupName,
                reservedSeats = p.ReservedSeats,
                club = p.Club,
                tip = p.Tip,
                parchaseSum = p.PurchaseSum,
                receiptTime = p.ReceiptTime
            }).ToList();
        }
    }
}