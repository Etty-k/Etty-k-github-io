using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeQueueServer.Models
{
    public class StoresMenuDTO
    {
        public int id { get; set; }
        public int store { get; set; }
        public string productName { get; set; }
        public string productCategory { get; set; }
        public Nullable<double> productPrice { get; set; }
        public Nullable<bool> productStatus { get; set; }
        public Nullable<bool> quickProduct { get; set; }
        public Nullable<int> preperationTime { get; set; }
        public string productImage { get; set; }

        public static StoresMenuDTO ConvertToDTO(tbl_storesMenu storeMenu)
        {
            return new StoresMenuDTO()
            {
                id = storeMenu.Id,
                store = (storeMenu.Store != null) ? storeMenu.tbl_stores.Id : 0,
                productName = storeMenu.ProductName,
                productCategory = (storeMenu.ProductCategory != null) ? storeMenu.tbl_productsCategories.Category : "",
                productPrice = storeMenu.ProductPrice,
                productStatus = storeMenu.ProductStatus,
                quickProduct = storeMenu.QuickProduct,
                preperationTime = storeMenu.PreperationTime,
                productImage = storeMenu.ProductImage
            };
        }

        public static List<StoresMenuDTO> ConvertToDTO(List<tbl_storesMenu> storeMenu)
        {
            return storeMenu.Select(m => new StoresMenuDTO
            {
                id = m.Id,
                store = (m.Store != null) ? m.tbl_stores.Id : 0,
                productName = m.ProductName,
                productCategory = (m.ProductCategory != null) ? m.tbl_productsCategories.Category : "",
                productPrice = m.ProductPrice,
                productStatus = m.ProductStatus,
                quickProduct = m.QuickProduct,
                preperationTime = m.PreperationTime,
                productImage = m.ProductImage
            }).ToList();
        }
    }
}