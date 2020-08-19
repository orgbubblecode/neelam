using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OBSync.Models
{
    public class OBAPIEntitiesTracker
    {
        [Key]
        public int OBAPIEntitiesTrackerID { get; set; }

        public string OBAPIEntityID { get; set; } = "";

        public int OBAPIEntityTypeID { get; set; } = 0;

        public string OBAPISugarCRMID { get; set; } = "";

        public int OBAPISugarModuleID { get; set; } = 0;


    }
}