using AllMyBio;
using MailChimp.Net;
using MailChimp.Net.Core;
using MailChimp.Net.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Newtonsoft.Json;
using OBSync.Models.MailChimp;
using OBSync.Models.OBDataSources.Products;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OBSync.Controllers
{
    public class HomeController : Controller
    {

         
        public OrgBubbleUserRetrieval getOrgBubbleUsers()
        {
            OrgBubbleUserRetrieval o = new OrgBubbleUserRetrieval();
            try
            {
                OrgBubbleDbEntities obDb = new OrgBubbleDbEntities();

                o.users_list = obDb.general_users.ToList();
            }
            catch (Exception e)
            {
                o.ex = true;
                o.error = e.Message;
            }
            return o;
        }






        public async Task<ActionResult> Index()
        {
            // This is code to access api. You have to change token value
            // We need to access token generation through api too. I didn't do that, because i was testing my code
            AllMyBioUserRetrieval values = null;
            try
            {
                var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9leGFtcGxlLm9yZyIsImF1ZCI6Imh0dHA6XC9cL2V4YW1wbGUuY29tIiwiZXhwIjoxNTk2ODU2NTY2LCJkYXRhIjpbXX0.ueGa5rLowErCXVPFKxJVzF995iiKsTmilelZlokUA34";
                string URI = "http://apidataset.orgbubble.com/amb/v1/prod/users/read.php";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var res = await client.GetAsync(URI);
                if (res.IsSuccessStatusCode)
                {
                    var json = res.Content.ReadAsStringAsync().Result;
                    values = JsonConvert.DeserializeObject<AllMyBioUserRetrieval>(json);
                    // values contain list of rest api data. I am not using this data right now to add in the mailchimp
                    // Slight modification is needed in the structure of class to properly add this object in mailchimp
                }
            }
            catch (Exception e)
            {
                var s = e;
            }


            // This is code to add data in mail chimp
            string api_key = System.Configuration.ConfigurationManager.AppSettings["MailChimpApiKey"];
            MailChimpManager Manager = new MailChimpManager(api_key);
            string list_id = "2c3a229e2a";

            // Here orgbubble is being called directly by accessing database, this o is not initialized using rest api
            // This OrgBubbleUserRetrieval class structure should be followed by rest api return type to add data in
            // mailchimp correctly.
            OrgBubbleUserRetrieval o = getOrgBubbleUsers();
            if (o.users_list.Count > 0)
            {

                foreach (var member in o.users_list)
                {

                    try
                    {
                        var mem = new Member
                        {
                            EmailAddress = member.email,
                            EmailType = "html",
                            Status = Status.Subscribed,
                            MergeFields = new Dictionary<string, object>
                        {
                            {"First Name", member.fullname}
                        }
                        };
                        var m = await Manager.Members.AddOrUpdateAsync(list_id, mem);
                    }


                    catch (MailChimpException mce)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadGateway, mce.Message);
                    }
                    catch (Exception e)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.ServiceUnavailable, e.Message);
                    }
                }
            }
            var model = await Manager.Lists.GetAsync(list_id);
            return View(model);

        }
    }
}
