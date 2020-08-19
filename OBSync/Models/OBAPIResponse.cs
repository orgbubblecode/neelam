using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OBSync.Models
{
    public class OBAPIResponse
    {
        [Key]
        public int obapiresponseid { get; set; }
        public bool success { get; set; } = false;
        public string message { get; set; } = "";
        public string referenceID { get; set; } = "";
        public string callerIP { get; set; } = "";
        public DateTime responseDate { get; set; }
        public OBAPIEnumEntityType entityTypeId { get; set; }
        public string databaseName { get; set; } = "";
        public string sourceCall { get; set; } = "";
        public object data { get; set; } 

        public OBAPIResponse()
        {
            this.referenceID = Guid.NewGuid().ToString();
            this.responseDate = DateTime.Now;
        }

    }


}