using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBSync.Models.MailChimp
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Record
    {
        public string user_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string token_code { get; set; }
        public object twofa_secret { get; set; }
        public string email_activation_code { get; set; }
        public string lost_password_code { get; set; }
        public object facebook_id { get; set; }
        public string type { get; set; }
        public string active { get; set; }
        public string package_id { get; set; }
        public string package_expiration_date { get; set; }
        public string package_settings { get; set; }
        public string package_trial_done { get; set; }
        public object payment_subscription_id { get; set; }
        public string date { get; set; }
        public string ip { get; set; }
        public string last_activity { get; set; }
        public string last_user_agent { get; set; }
        public string total_logins { get; set; }
        public string timezone { get; set; }
        public string language { get; set; }
        public string country { get; set; }
    }

    public class Document
    {
        public List<Record> records { get; set; }
    }

    public class AllMyBioUserRetrieval
    {
        public string status { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public Document document { get; set; }
    }


}