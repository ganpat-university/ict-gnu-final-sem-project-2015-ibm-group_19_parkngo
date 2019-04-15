using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkNGoFinal.ViewModel
{
    public class LocationList
    {
        public int LocationID { get; set; }
        
        public string Location { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}