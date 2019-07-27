using FreeQueueServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeQueueServer.Models
{
    public class MenuAdditionsDTO
    {
        public int id { get; set; }
        public string product { get; set; }
        public string additionName { get; set; }
        public Nullable<double> additionPrice { get; set; }
        public Nullable<bool> additionStatus { get; set; }
        public string additionImage { get; set; }
        /// <summary>
        /// get sql entity and convert it to simple object without references
        /// </summary>
        /// <param name="addition"></param>
        /// <returns></returns>
        public static MenuAdditionsDTO ConvertToDTO(tbl_menuAddittions addition)
        {
            return new MenuAdditionsDTO()
            {
                id = addition.Id,
                product = (addition.Product != null) ? addition.tbl_storesMenu.ProductName : "",
                additionName = addition.Addition,
                additionPrice = addition.AddtionPrice,
                additionStatus = addition.AdditionStatus,
                additionImage = addition.AdditionImage,
            };
        }

        public static List<MenuAdditionsDTO> ConvertToDTO(List<tbl_menuAddittions> addition)
        {
            return addition.Select(a=> new MenuAdditionsDTO
            {
                id = a.Id,
                product = (a.Product != null) ? a.tbl_storesMenu.ProductName : "",
                additionName = a.Addition,
                additionPrice = a.AddtionPrice,
                additionStatus = a.AdditionStatus,
                additionImage = a.AdditionImage,
            }).ToList();
        }
    }
}