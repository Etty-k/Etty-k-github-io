using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeQueueServer.Models
{
    public class PurchasesDetailsTasteDTO
    {
        public int id { get; set; }
        public int product { get; set; }
        public int? taste { get; set; }
        public static PurchasesDetailsTasteDTO ConvertToDTO(tbl_purchasesTastes purchasesTaste)
        {
            return new PurchasesDetailsTasteDTO() {
                id = purchasesTaste.Id,
                product = (purchasesTaste.Product != null) ? purchasesTaste.tbl_purchasesProducts.Id : 0 ,
                taste = purchasesTaste.Taste
            };
        }



    }
}