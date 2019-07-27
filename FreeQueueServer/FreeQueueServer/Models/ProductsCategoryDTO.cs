using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeQueueServer.Models
{
    public class ProductsCategoryDTO
    {
        public int id { get; set; }
        public string category { get; set; }
        public int store { get; set; }

        public static ProductsCategoryDTO ConvertToDTO(tbl_productsCategories productsCategory)
        {
            return new ProductsCategoryDTO()
            {
                id = productsCategory.Id,
                category = productsCategory.Category
            };
        }

        public static List<ProductsCategoryDTO> ConvertToDTO(List<tbl_productsCategories> productsCategories)
        {
            return productsCategories.Select(c=>new ProductsCategoryDTO
            {
                id = c.Id,
                category = c.Category
            }).ToList();
        }
    }
}