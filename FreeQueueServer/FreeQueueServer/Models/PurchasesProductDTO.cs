using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeQueueServer.Models
{
    public class PurchasesProductDTO
    {
        public int id { get; set; }
        public Nullable<int> purchase { get; set; }
        public string product { get; set; }
        public Nullable<int> productCount { get; set; }
        public Nullable<double> price { get; set; }

        public static PurchasesProductDTO ConvertToDTO(tbl_purchasesProducts purchasesProduct)
        {
            return new PurchasesProductDTO()
            {
                id = purchasesProduct.Id,
                purchase = (purchasesProduct != null) ? purchasesProduct.tbl_purchases.Id : 0,
                product = (purchasesProduct != null) ? purchasesProduct.tbl_storesMenu.ProductName : "",
                productCount = purchasesProduct.ProductCount,
                price = purchasesProduct.Price
            };
        }

        public static List<PurchasesProductDTO> ConvertToDTO(List<tbl_purchasesProducts> purchasesProducts)
        {
            return purchasesProducts.Select(p=> new PurchasesProductDTO
            {
                id = p.Id,
                purchase = (p != null) ? p.tbl_purchases.Id : 0,
                product = (p != null) ? p.tbl_storesMenu.ProductName : "",
                productCount = p.ProductCount,
                price = p.Price
            }).ToList();
        }
    }
}