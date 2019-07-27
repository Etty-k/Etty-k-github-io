using FreeQueueServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeQueueServer.Models
{
    public class StoresActivityTimeDTO
    {
        public int id { get; set; }
        public Nullable<int> store { get; set; }
        public Nullable<int> activityDay { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public StoresActivityTimeDTO ConvertToDTO(tbl_storesActivityTime storesActivityTime)
        {
            return new StoresActivityTimeDTO()
            {
                id = storesActivityTime.Id,
                store = (storesActivityTime.Store != null) ? storesActivityTime.tbl_stores.Id : 0,
                activityDay = storesActivityTime.ActivityDay,
                startTime = storesActivityTime.StartTime,
                endTime = storesActivityTime.EndTime
            };
        }
    }
}