using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBSync.Models.MailChimp
{
    public class OrgBubbleUserRetrieval
    {
        public List<OrgBubble.general_users> users_list { get; set; } = new List<OrgBubble.general_users>();
        public bool ex { get; set; } = false;
        public string error { get; set; } = "";
    }
}