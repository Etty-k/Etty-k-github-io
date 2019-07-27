using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeQueueServer.Models
{
    public class StoresDTO
    {
        public int id { get; set; }
        public string storeName { get; set; }
        public string storeAddress { get; set; }
        public string phone { get; set; }
        public string about { get; set; }
        public string kashrutCertifiction { get; set; }
        public string img { get; set; }
        public string storeCategory { get; set; }
        public bool? reservedSeats { get; set; }
        public bool? club { get; set; }
        public bool? tip { get; set; }
        public bool? storeLoad { get; set; }
        public int? bank { get; set; }
        public int? brunch { get; set; }
        public string account { get; set; }

        public static StoresDTO ConvertToDTO(tbl_stores store)
        {
            return new StoresDTO()
            {
                id = store.Id,
                storeName = store.StoreName,
                storeAddress = store.StoreAddress,
                phone = store.Phone,
                about = store.Phone,
                kashrutCertifiction = store.KashrutCertification,
                img = store.Img,
                storeCategory = store.StoreCategory,
                reservedSeats = store.ReservedSeats,
                club = store.Club,
                tip = store.Tip,
                storeLoad = store.StoreLoad,
                bank = store.Bank,
                brunch = store.Brunch,
                account = store.Account
            };
        }

        public static List<StoresDTO> ConvertToDTO(List<tbl_stores> stores)
        {
            return stores.Select(s => new StoresDTO()
            {
                id = s.Id,
                storeName = s.StoreName,
                storeAddress = s.StoreAddress,
                phone = s.Phone,
                about = s.Phone,
                kashrutCertifiction = s.KashrutCertification,
                img = s.Img,
                storeCategory = s.StoreCategory,
                reservedSeats = s.ReservedSeats,
                club = s.Club,
                tip = s.Tip,
                storeLoad = s.StoreLoad,
                bank = s.Bank,
                brunch = s.Brunch,
                account = s.Account
            }).ToList();
        }
    }
}