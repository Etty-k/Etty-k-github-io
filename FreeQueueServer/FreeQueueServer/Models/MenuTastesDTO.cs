using FreeQueueServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeQueueServer.Models
{
    public class MenuTastesDTO
    {
        public int id { get; set; }
        public string product { get; set; }
        public string tasteName { get; set; }
        public Nullable<bool> tasteStatus { get; set; }
        public string tasteImage { get; set; }
        /// <summary>
        /// get sql entity and convert it to simple object without references
        /// </summary>
        /// <param name="taste"></param>
        /// <returns></returns>
        public static MenuTastesDTO ConvertToDTO(tbl_menuTastes taste)
        {
            return new MenuTastesDTO()
            {
                id = taste.Id,
                product = (taste.Product != null) ? taste.tbl_storesMenu.ProductName : "",
                tasteName = taste.Taste,
                tasteStatus = taste.TasteStatus,
                tasteImage = taste.TasteImage
            };
        }

        public static List<MenuTastesDTO> ConvertToDTO(List<tbl_menuTastes> tastes)
        {
            return tastes.Select(t=> new MenuTastesDTO
            {
                id = t.Id,
                product = (t.Product != null) ? t.tbl_storesMenu.ProductName : "",
                tasteName = t.Taste,
                tasteStatus = t.TasteStatus,
                tasteImage = t.TasteImage
            }).ToList();
        }
    }
}