using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeQueueServer.Models
{
    public class PurchasesDetailsAdditionDTO
    {
        public int id { get; set; }
        public int product { get; set; }
        public int? addition { get; set; }
        public static PurchasesDetailsAdditionDTO ConvertToDTO(tbl_purchasesAdditions purchasesAddition)
        {
            return new PurchasesDetailsAdditionDTO()
            {
                id = purchasesAddition.Id,
                product = (purchasesAddition.Product != null) ? purchasesAddition.tbl_purchasesProducts.Id : 0,
                addition = purchasesAddition.Addition
            };
        }
    }
}