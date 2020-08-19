using MailChimp.Net;
using MailChimp.Net.Core;
using MailChimp.Net.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using OBSync.Models.MailChimp;
using OBSync.Models.OBDataSources.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OBSync.Controllers
{
    public class MailChimpController <T> : Controller
    {
        // GET: MailChimp

        public OrgBubbleUserRetrieval getOrgBubbleUsers()
        {
            OrgBubbleUserRetrieval o = new OrgBubbleUserRetrieval();
            try
            {
                OrgBubbleDbEntities obDb = new OrgBubbleDbEntities();
                
                o.users_list = obDb.general_users.ToList();
            }
            catch(Exception e)
            {
                o.ex = true;
                o.error = e.Message;
            }
            return o;
        }

        public async Task<ActionResult> Index()
        {
            string api_key = System.Configuration.ConfigurationManager.AppSettings["MailChimpApiKey"];
            MailChimpManager Manager = new MailChimpManager(api_key);
            string list_id = "2c3a229e2a";
            OrgBubbleUserRetrieval o = getOrgBubbleUsers();
            if(o.users_list.Count > 0)
            {
                
                foreach(var member in o.users_list)
                {
                    
                    try
                    {
                        var mem = new Member
                        {
                            EmailAddress = member.email,
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