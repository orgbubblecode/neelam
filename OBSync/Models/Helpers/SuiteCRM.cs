using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SugarRestSharp;

using AllMyBio;
using OrgBubble;
using OBSync.Models.OBDataSources;

using OBSync.Models;
//using SugarRestSharp;
using SugarRestSharp.Models;

using Elmah;
using RestSharp;
using Newtonsoft.Json;
using OrgBubbleDataViews;
using OBSync.Models.OBDataSources.Systems;
using OBSync.Models.OBDataSources.Products;

namespace OBSync.Models.Helpers
{
    public class SuiteCRM
    {

        static private AllMyBioDbEntities ambDb = new AllMyBioDbEntities();
        static private OrgBubbleDbEntities obDb = new OrgBubbleDbEntities();
        static private OBSyncOLTP OBSyncDB = new OBSyncOLTP();
        static private OBCRMDbEntities OBCRMDB = new OBCRMDbEntities();
        static private orgbubble_data_viewsEntities obViewsDb = new orgbubble_data_viewsEntities();


        public static SugarRestClient GetSuiteCRMClient()
        {

            // sugarCRM project site: 
            string sugarCrmUrl = "https://crm.orgbubble.com/service/v4_1/rest.php";
            string sugarCrmUsername = "obapiuser";
            string sugarCrmPassword = "Th34piUs3770";

            return new SugarRestClient(sugarCrmUrl, sugarCrmUsername, sugarCrmPassword);


        }


        public static List<OBAPIResponse> UpdateAllMyBioUsersBasicInformation()
        {


            List<OBAPIResponse> Responses = new List<OBAPIResponse>();
            List<AllMyBio.user> obLst = new List<AllMyBio.user>();
            obLst = ambDb.users.ToList();


            if (obLst.Count > 0)
            {

                foreach (AllMyBio.user oAMBUser in obLst)
                {

                    OBAPIResponse response = UpdateAllMyBioUsersBasicInformation(oAMBUser);
                    Responses.Add(response);

                }
            }

            return Responses;




        }


        public static OBAPIResponse UpdateAllMyBioUsersBasicInformation(AllMyBio.user User)
        {


            OBAPIEntitiesTracker oTrackedUser = GetSuiteCRMRecordID(User.user_id.ToString(),
                                                                      (int)OBAPIEnumEntityType.AMBAccount,
                                                                      (int)OBAPISuiteCRMModuleTypes.Accounts);

            string strAccountID = "";
            string strContactID = "";
            string strEmailAddressID = "";
            string strBeanID = "";
            string strAccountContactID = "";

            OBAPIResponse Response = new OBAPIResponse();

            var client = OBSync.Models.Helpers.SuiteCRM.GetSuiteCRMClient();

            if (String.IsNullOrEmpty(oTrackedUser.OBAPISugarCRMID))
            {

                //Add CRM Account
                try
                {

                    Account oNewAccount = new Account()
                    {
                        Name = User.name.ToLower(),
                        AssignedUserId = "6fa5fc21-77d4-ca8d-9e83-5de1a1d5f2ba",
                   
                    };
                    var oNewAccountrRequest = new SugarRestRequest("Accounts", RequestType.Create);
                    oNewAccountrRequest.Parameter = oNewAccount;
                    List<string> selectNewAccountFields = new List<string>();
                    selectNewAccountFields.Add(nameof(Account.Name));
                    selectNewAccountFields.Add(nameof(Account.AssignedUserId));
                    oNewAccountrRequest.Options.SelectFields = selectNewAccountFields;
                    SugarRestResponse oNewAccountrRequestResponse = client.Execute(oNewAccountrRequest);
                    strAccountID = (string)oNewAccountrRequestResponse.Data;


                    //Account Tracker
                    OBAPIEntitiesTracker oNewTrackedAccount = new OBAPIEntitiesTracker();
                    oNewTrackedAccount.OBAPIEntityID = User.user_id.ToString();
                    oNewTrackedAccount.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.AMBAccount;
                    oNewTrackedAccount.OBAPISugarCRMID = strAccountID;
                    oNewTrackedAccount.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.Accounts;


                    OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedAccount);
                    OBSyncDB.Entry(oNewTrackedAccount).State = System.Data.Entity.EntityState.Added;
                    OBSyncDB.SaveChanges();
                    OBSyncDB.Entry(oNewTrackedAccount).State = System.Data.Entity.EntityState.Detached;



                    //Create Contact 
                    Contact oContactToCreate = new Contact()
                    {
                        FirstName = Models.Helpers.Utilities.NameObject(User.name).First,
                        LastName = Models.Helpers.Utilities.NameObject(User.name).Last,
                        AssignedUserId = "6fa5fc21-77d4-ca8d-9e83-5de1a1d5f2ba"
                    };
                    var oNewConntactRequest = new SugarRestRequest("Contacts", RequestType.Create);
                    oNewConntactRequest.Parameter = oContactToCreate;
                    List<string> selectNewContactFields = new List<string>();
                    selectNewContactFields.Add(nameof(Contact.FirstName));
                    selectNewContactFields.Add(nameof(Contact.LastName));
                    oNewConntactRequest.Options.SelectFields = selectNewContactFields;
                    SugarRestResponse oNewConntactResponse = client.Execute(oNewConntactRequest);
                    strContactID = (string)oNewConntactResponse.Data;

                    //Contact Tracker
                    OBAPIEntitiesTracker oNewTrackedUser = new OBAPIEntitiesTracker();
                    oNewTrackedUser.OBAPIEntityID = User.user_id.ToString();
                    oNewTrackedUser.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.AMBUserInformation;
                    oNewTrackedUser.OBAPISugarCRMID = strContactID;
                    oNewTrackedUser.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.Contacts;
                    OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedUser);
                    OBSyncDB.Entry(oNewTrackedUser).State = System.Data.Entity.EntityState.Added;
                    OBSyncDB.SaveChanges();
                    OBSyncDB.Entry(oNewTrackedUser).State = System.Data.Entity.EntityState.Detached;





                    //AccountsContacts oAccountContact = new AccountsContacts()
                    //{
                    //    ContactId = strContactID,
                    //    AccountId = strAccountID,
                    //    Deleted = 0,
                    //    DateModified = DateTime.Now,
                    //};
                    //var oAccountContactRequest = new SugarRestRequest("AccountsContacts", RequestType.Create);
                    //oAccountContactRequest.Parameter = oAccountContact;
                    //List<string> selectAccountContacFields = new List<string>();
                    //selectAccountContacFields.Add(nameof(AccountsContacts.ContactId));
                    //selectAccountContacFields.Add(nameof(AccountsContacts.AccountId));
                    //selectAccountContacFields.Add(nameof(AccountsContacts.Deleted));
                    //selectAccountContacFields.Add(nameof(AccountsContacts.DateModified));
                    //oAccountContactRequest.Options.SelectFields = selectAccountContacFields;
                    //SugarRestResponse oAccountContactResponse = client.Execute(oAccountContactRequest);
                    //strAccountContactID = (string)oAccountContactResponse.Data;

                    ////Email Tracker
                    //OBAPIEntitiesTracker oNewTrackedAccountContact = new OBAPIEntitiesTracker();
                    //oNewTrackedAccountContact.OBAPIEntityID = User.id.ToString();
                    //oNewTrackedAccountContact.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.OBAccount;
                    //oNewTrackedAccountContact.OBAPISugarCRMID = strAccountContactID;
                    //oNewTrackedAccountContact.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.AccountContacts;
                    //OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedAccountContact);
                    //OBSyncDB.Entry(oNewTrackedAccountContact).State = System.Data.Entity.EntityState.Added;
                    //OBSyncDB.SaveChanges();
                    //OBSyncDB.Entry(oNewTrackedAccountContact).State = System.Data.Entity.EntityState.Detached;

                    //EmailAddresses oContactEmail = new EmailAddresses()
                    //{
                    //    EmailAddress = User.email,
                    //    EmailAddressCaps = User.email.ToUpper(),
                    //    DateCreated = DateTime.Now,
                    //    DateModified = DateTime.Now,
                    //};
                    //var oNewEmailRequest = new SugarRestRequest("EmailAddresses", RequestType.Create);
                    //oNewEmailRequest.Parameter = oContactEmail;
                    //List<string> selectNewEmailAddressFieldsFields = new List<string>();
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddresses.EmailAddress));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddresses.EmailAddressCaps));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddresses.DateCreated));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddresses.DateModified));
                    //oNewEmailRequest.Options.SelectFields = selectNewEmailAddressFieldsFields;
                    //SugarRestResponse oNewEmailResponse = client.Execute(oNewEmailRequest);
                    //strEmailAddressID = (string)oNewEmailResponse.Data;

                    ////Email Tracker
                    //OBAPIEntitiesTracker oNewTrackedEmailAddress = new OBAPIEntitiesTracker();
                    //oNewTrackedEmailAddress.OBAPIEntityID = User.id.ToString();
                    //oNewTrackedEmailAddress.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.OBUserEmailAddress;
                    //oNewTrackedEmailAddress.OBAPISugarCRMID = strEmailAddressID;
                    //oNewTrackedEmailAddress.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.EmailAddresses;
                    //OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedEmailAddress);
                    //OBSyncDB.Entry(oNewTrackedEmailAddress).State = System.Data.Entity.EntityState.Added;
                    //OBSyncDB.SaveChanges();
                    //OBSyncDB.Entry(oNewTrackedEmailAddress).State = System.Data.Entity.EntityState.Detached;

                    //EmailAddrBeanRel oContactEmailBeanRelation = new EmailAddrBeanRel()
                    //{
                    //    EmailAddressId = strEmailAddressID,
                    //    BeanId = strContactID,
                    //    BeanModule = "Contacts",
                    //    PrimaryAddress = 1,
                    //    ReplyToAddress=0,
                    //    DateCreated = DateTime.Now,
                    //    DateModified = DateTime.Now,
                    //    Deleted = 0

                    //};
                    //var oContactEmailBeanRelationRequest = new SugarRestRequest("EmailAddrBeanRel", RequestType.Create);
                    //oContactEmailBeanRelationRequest.Parameter = oContactEmailBeanRelation;
                    //List<string> selectContactEmailBeanRelationFields = new List<string>();
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.EmailAddressId));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.BeanId));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.PrimaryAddress));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.ReplyToAddress));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.Deleted));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.DateCreated));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.DateModified));
                    //oContactEmailBeanRelationRequest.Options.SelectFields = selectContactEmailBeanRelationFields;
                    //SugarRestResponse oNewEmailBeanResponse = client.Execute(oContactEmailBeanRelationRequest);
                    //strBeanID = (string)oNewEmailBeanResponse.Data;
                    ////Contact Tracker
                    //OBAPIEntitiesTracker oNewTrackedBean = new OBAPIEntitiesTracker();
                    //oNewTrackedBean.OBAPIEntityID = User.id.ToString();
                    //oNewTrackedBean.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.OBUserInformation;
                    //oNewTrackedBean.OBAPISugarCRMID = strBeanID;
                    //oNewTrackedBean.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.EmailAddressesBeans;
                    //OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedBean);
                    //OBSyncDB.Entry(oNewTrackedBean).State = System.Data.Entity.EntityState.Added;
                    //OBSyncDB.SaveChanges();
                    //OBSyncDB.Entry(oNewTrackedBean).State = System.Data.Entity.EntityState.Detached;

                    //Add Contact To Account
                    accounts_contacts oNewaccounts_contacts = new accounts_contacts();
                    Guid oNewaccounts_contactsGUID = Guid.NewGuid();
                    oNewaccounts_contacts.id = oNewaccounts_contactsGUID.ToString();
                    oNewaccounts_contacts.contact_id = strContactID;
                    oNewaccounts_contacts.account_id = strAccountID;
                    oNewaccounts_contacts.date_modified = DateTime.Now;
                    oNewaccounts_contacts.deleted = false;
                    OBCRMDB.accounts_contacts.Add(oNewaccounts_contacts);
                    OBCRMDB.SaveChanges();

                    //Account Contact Relation Tracker
                    OBAPIEntitiesTracker oNewTrackedAccountContact = new OBAPIEntitiesTracker();
                    oNewTrackedAccountContact.OBAPIEntityID = User.user_id.ToString();
                    oNewTrackedAccountContact.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.AMBAccount;
                    oNewTrackedAccountContact.OBAPISugarCRMID = oNewaccounts_contactsGUID.ToString();
                    oNewTrackedAccountContact.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.AccountContacts;
                    OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedAccountContact);
                    OBSyncDB.Entry(oNewTrackedAccountContact).State = System.Data.Entity.EntityState.Added;
                    OBSyncDB.SaveChanges();
                    OBSyncDB.Entry(oNewTrackedAccountContact).State = System.Data.Entity.EntityState.Detached;
                    strAccountContactID = oNewaccounts_contactsGUID.ToString();

                    //Add Email To Contact
                    email_addresses oUserContactEmail = new email_addresses();
                    Guid gEmailID = Guid.NewGuid();
                    oUserContactEmail.id = gEmailID;
                    oUserContactEmail.email_address = User.email;
                    oUserContactEmail.email_address_caps = User.email.ToUpper();
                    oUserContactEmail.invalid_email = false;
                    oUserContactEmail.opt_out = false;
                    oUserContactEmail.confirm_opt_in = "confirmed-opt-in";
                    oUserContactEmail.date_created = DateTime.Now;
                    oUserContactEmail.date_modified = DateTime.Now;
                    oUserContactEmail.deleted = false;
                    OBCRMDB.email_addresses.Add(oUserContactEmail);
                    OBCRMDB.SaveChanges();

                    //Email Tracker
                    OBAPIEntitiesTracker oNewTrackedEmailAddress = new OBAPIEntitiesTracker();
                    oNewTrackedEmailAddress.OBAPIEntityID = User.user_id.ToString();
                    oNewTrackedEmailAddress.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.AMBUserEmailAddress;
                    oNewTrackedEmailAddress.OBAPISugarCRMID = gEmailID.ToString();
                    oNewTrackedEmailAddress.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.EmailAddresses;
                    OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedEmailAddress);
                    OBSyncDB.Entry(oNewTrackedEmailAddress).State = System.Data.Entity.EntityState.Added;
                    OBSyncDB.SaveChanges();
                    OBSyncDB.Entry(oNewTrackedEmailAddress).State = System.Data.Entity.EntityState.Detached;
                    strEmailAddressID = gEmailID.ToString();

                    Guid gEmailBeanID = Guid.NewGuid();
                    email_addr_bean_rel oEmailContactRelation = new email_addr_bean_rel()
                    {
                        id = gEmailBeanID,
                        email_address_id = gEmailID,
                        bean_id = Guid.Parse(strContactID),
                        bean_module = "Contacts",
                        primary_address = true,
                        reply_to_address = false,
                        date_created = DateTime.Now,
                        date_modified = DateTime.Now,
                        deleted = false
                    };

                    OBCRMDB.email_addr_bean_rel.Add(oEmailContactRelation);
                    OBCRMDB.SaveChanges();

                    //Contact Tracker
                    OBAPIEntitiesTracker oNewTrackedBean = new OBAPIEntitiesTracker();
                    oNewTrackedBean.OBAPIEntityID = User.user_id.ToString();
                    oNewTrackedBean.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.AMBUserInformation;
                    oNewTrackedBean.OBAPISugarCRMID = gEmailBeanID.ToString();
                    oNewTrackedBean.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.EmailAddressesBeans;
                    OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedBean);
                    OBSyncDB.Entry(oNewTrackedBean).State = System.Data.Entity.EntityState.Added;
                    OBSyncDB.SaveChanges();
                    OBSyncDB.Entry(oNewTrackedBean).State = System.Data.Entity.EntityState.Detached;
                    strBeanID = gEmailBeanID.ToString();

                    //  request.Options.Query = String.Concat("contacts.id IN (SELECT bean_id FROM email_addr_bean_rel eabr JOIN email_addresses ea ON (eabr.email_address_id = ea.id) WHERE bean_module = 'Contacts' AND ea.email_address_caps = '", oOBUser.email, "' AND eabr.deleted=0)");
                    //request.Options.QueryPredicates = new List<QueryPredicate>();

                }

                catch (Exception e)
                {
                    Response.message = e.Message;
                    Response.referenceID = strAccountID;
                    Response.callerIP = Helpers.Network.GetIPAddress();
                    Response.responseDate = DateTime.Now;
                    Response.entityTypeId = OBAPIEnumEntityType.OBAccount;
                    Response.databaseName = obDb.Database.Connection.Database;
                    Response.data = e;
                    Response.success = false;

                    return Response;

                    throw;
                }




            }
            else
            {
                //UPDATE CRM Account


                var readAccountRequest = new SugarRestRequest("Accounts", RequestType.ReadById);
                strAccountID = oTrackedUser.OBAPISugarCRMID;
                readAccountRequest.Parameter = strAccountID;
                SugarRestResponse accountReadResponse = client.Execute(readAccountRequest);
                Account oAccountToUpdate = (Account)accountReadResponse.Data;

                var updateAccountRequest = new SugarRestRequest(RequestType.Update);
                oAccountToUpdate.Name = User.name.ToLower();
                updateAccountRequest.Parameter = oAccountToUpdate;
                List<string> selectAccountToUpdateFields = new List<string>();
                selectAccountToUpdateFields.Add(nameof(Account.Name));
                updateAccountRequest.Options.SelectFields = selectAccountToUpdateFields;
                SugarRestResponse responseAccountUpdate = client.Execute<Account>(updateAccountRequest);



                List<AllMyBio.users_logs> ambUserLogs = ambDb.users_logs.Where(w => w.user_id == User.user_id).ToList();

                if (ambUserLogs != null && ambUserLogs.Count > 0)
                {
                    foreach (AllMyBio.users_logs oULogs in ambUserLogs)
                    {

                        //var readNoteRequest

                    }
                }




            }




            //Update Customs
            if (!String.IsNullOrEmpty(strAccountID))
            {
                Guid oAccountID = Guid.Parse(strAccountID);
                accounts_cstm oCRMAccountCustomInfo = OBCRMDB.accounts_cstm.Where(w => w.id_c == oAccountID).FirstOrDefault();

                if (oCRMAccountCustomInfo != null)
                {
                    oCRMAccountCustomInfo.isallmybiocustomer_c = true;
                    oCRMAccountCustomInfo.allmybio_id_c = User.user_id;

                    string strPackage = "";
                    int oPack = 0;
                    if (int.TryParse(User.package_id, out oPack))
                    {
                        int iPackID = int.Parse(User.package_id);
                        AllMyBio.package oUAMBBPack = ambDb.packages.Where(w => w.package_id == iPackID).FirstOrDefault();
                        strPackage = (oUAMBBPack == null) ? "N/A" : oUAMBBPack.name;
                    }

                    if (!string.IsNullOrEmpty(User.package_id) && !int.TryParse(User.package_id, out oPack))
                    {
                        strPackage = User.package_id;
                    }


                    oCRMAccountCustomInfo.allmybio_package_c = strPackage;
                    oCRMAccountCustomInfo.isallmybioactive_c = (User.active == 1 ? true : false);

                    OBCRMDB.accounts_cstm.Add(oCRMAccountCustomInfo);
                    OBCRMDB.Entry(oCRMAccountCustomInfo).State = System.Data.Entity.EntityState.Modified;
                    OBCRMDB.SaveChanges();
                }
            }




            Response.message = string.Concat("Added/Updated AMB User ", User.email);
            Response.referenceID = strAccountID;
            Response.callerIP = Helpers.Network.GetIPAddress();
            Response.responseDate = DateTime.Now;
            Response.entityTypeId = OBAPIEnumEntityType.AMBAccount;
            Response.databaseName = obDb.Database.Connection.Database;
            Response.data = strAccountID;

            Response.success = true;



            return Response;





        }





        public static List<OBAPIResponse> UpdateOrgBubbleUsersBasicInformation()
        {


            List<OBAPIResponse> Responses = new List<OBAPIResponse>();
            List<OrgBubble.general_users> obLst = new List<OrgBubble.general_users>();
            obLst = obDb.general_users.ToList();


            if (obLst.Count > 0)
            {

                foreach (var oOBUser in obLst)
                {

                    OBAPIResponse response = UpdateOrgBubbleUsersBasicInformation(oOBUser);
                    Responses.Add(response);

                }
            }

            return Responses;




        }



        public static OBAPIResponse UpdateOrgBubbleUsersBasicInformation(general_users User)
        {


            OBAPIEntitiesTracker oTrackedUser = GetSuiteCRMRecordID(User.id.ToString(),
                                                                   (int)OBAPIEnumEntityType.OBAccount,
                                                                   (int)OBAPISuiteCRMModuleTypes.Accounts);

            string strAccountID = "";
            string strContactID = "";
            string strEmailAddressID = "";
            string strBeanID = "";
            string strAccountContactID = "";

            OBAPIResponse Response = new OBAPIResponse();




            var client = OBSync.Models.Helpers.SuiteCRM.GetSuiteCRMClient();

            if (String.IsNullOrEmpty(oTrackedUser.OBAPISugarCRMID))
            {

                //Add CRM Account
                try
                {

                    Account oNewAccount = new Account()
                    {
                        Name = User.email.ToLower(),
                        AssignedUserId = "6fa5fc21-77d4-ca8d-9e83-5de1a1d5f2ba",
                        Description = SuiteCRM.GetOBUserAccountsListInHTML(User.id.ToString())
                        
                    };
                    var oNewAccountrRequest = new SugarRestRequest("Accounts", RequestType.Create);
                    oNewAccountrRequest.Parameter = oNewAccount;
                    List<string> selectNewAccountFields = new List<string>();
                    selectNewAccountFields.Add(nameof(Account.Name));
                    selectNewAccountFields.Add(nameof(Account.Description));
                    selectNewAccountFields.Add(nameof(Account.AssignedUserId));
                    oNewAccountrRequest.Options.SelectFields = selectNewAccountFields;
                    SugarRestResponse oNewAccountrRequestResponse = client.Execute(oNewAccountrRequest);
                    strAccountID = (string)oNewAccountrRequestResponse.Data;


                    //Account Tracker
                    OBAPIEntitiesTracker oNewTrackedAccount = new OBAPIEntitiesTracker();
                    oNewTrackedAccount.OBAPIEntityID = User.id.ToString();
                    oNewTrackedAccount.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.OBAccount;
                    oNewTrackedAccount.OBAPISugarCRMID = strAccountID;
                    oNewTrackedAccount.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.Accounts;
                    OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedAccount);
                    OBSyncDB.Entry(oNewTrackedAccount).State = System.Data.Entity.EntityState.Added;
                    OBSyncDB.SaveChanges();
                    OBSyncDB.Entry(oNewTrackedAccount).State = System.Data.Entity.EntityState.Detached;



                    //Create Contact 
                    Contact oContactToCreate = new Contact()
                    {
                        FirstName = Models.Helpers.Utilities.NameObject(User.fullname).First,
                        LastName = Models.Helpers.Utilities.NameObject(User.fullname).Last,
                        AssignedUserId = "6fa5fc21-77d4-ca8d-9e83-5de1a1d5f2ba"
                    };
                    var oNewConntactRequest = new SugarRestRequest("Contacts", RequestType.Create);
                    oNewConntactRequest.Parameter = oContactToCreate;
                    List<string> selectNewContactFields = new List<string>();
                    selectNewContactFields.Add(nameof(Contact.FirstName));
                    selectNewContactFields.Add(nameof(Contact.LastName));
                    oNewConntactRequest.Options.SelectFields = selectNewContactFields;
                    SugarRestResponse oNewConntactResponse = client.Execute(oNewConntactRequest);
                    strContactID = (string)oNewConntactResponse.Data;

                    //Contact Tracker
                    OBAPIEntitiesTracker oNewTrackedUser = new OBAPIEntitiesTracker();
                    oNewTrackedUser.OBAPIEntityID = User.id.ToString();
                    oNewTrackedUser.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.OBUserInformation;
                    oNewTrackedUser.OBAPISugarCRMID = strContactID;
                    oNewTrackedUser.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.Contacts;
                    OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedUser);
                    OBSyncDB.Entry(oNewTrackedUser).State = System.Data.Entity.EntityState.Added;
                    OBSyncDB.SaveChanges();
                    OBSyncDB.Entry(oNewTrackedUser).State = System.Data.Entity.EntityState.Detached;





                    //AccountsContacts oAccountContact = new AccountsContacts()
                    //{
                    //    ContactId = strContactID,
                    //    AccountId = strAccountID,
                    //    Deleted = 0,
                    //    DateModified = DateTime.Now,
                    //};
                    //var oAccountContactRequest = new SugarRestRequest("AccountsContacts", RequestType.Create);
                    //oAccountContactRequest.Parameter = oAccountContact;
                    //List<string> selectAccountContacFields = new List<string>();
                    //selectAccountContacFields.Add(nameof(AccountsContacts.ContactId));
                    //selectAccountContacFields.Add(nameof(AccountsContacts.AccountId));
                    //selectAccountContacFields.Add(nameof(AccountsContacts.Deleted));
                    //selectAccountContacFields.Add(nameof(AccountsContacts.DateModified));
                    //oAccountContactRequest.Options.SelectFields = selectAccountContacFields;
                    //SugarRestResponse oAccountContactResponse = client.Execute(oAccountContactRequest);
                    //strAccountContactID = (string)oAccountContactResponse.Data;

                    ////Email Tracker
                    //OBAPIEntitiesTracker oNewTrackedAccountContact = new OBAPIEntitiesTracker();
                    //oNewTrackedAccountContact.OBAPIEntityID = User.id.ToString();
                    //oNewTrackedAccountContact.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.OBAccount;
                    //oNewTrackedAccountContact.OBAPISugarCRMID = strAccountContactID;
                    //oNewTrackedAccountContact.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.AccountContacts;
                    //OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedAccountContact);
                    //OBSyncDB.Entry(oNewTrackedAccountContact).State = System.Data.Entity.EntityState.Added;
                    //OBSyncDB.SaveChanges();
                    //OBSyncDB.Entry(oNewTrackedAccountContact).State = System.Data.Entity.EntityState.Detached;

                    //EmailAddresses oContactEmail = new EmailAddresses()
                    //{
                    //    EmailAddress = User.email,
                    //    EmailAddressCaps = User.email.ToUpper(),
                    //    DateCreated = DateTime.Now,
                    //    DateModified = DateTime.Now,
                    //};
                    //var oNewEmailRequest = new SugarRestRequest("EmailAddresses", RequestType.Create);
                    //oNewEmailRequest.Parameter = oContactEmail;
                    //List<string> selectNewEmailAddressFieldsFields = new List<string>();
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddresses.EmailAddress));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddresses.EmailAddressCaps));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddresses.DateCreated));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddresses.DateModified));
                    //oNewEmailRequest.Options.SelectFields = selectNewEmailAddressFieldsFields;
                    //SugarRestResponse oNewEmailResponse = client.Execute(oNewEmailRequest);
                    //strEmailAddressID = (string)oNewEmailResponse.Data;

                    ////Email Tracker
                    //OBAPIEntitiesTracker oNewTrackedEmailAddress = new OBAPIEntitiesTracker();
                    //oNewTrackedEmailAddress.OBAPIEntityID = User.id.ToString();
                    //oNewTrackedEmailAddress.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.OBUserEmailAddress;
                    //oNewTrackedEmailAddress.OBAPISugarCRMID = strEmailAddressID;
                    //oNewTrackedEmailAddress.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.EmailAddresses;
                    //OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedEmailAddress);
                    //OBSyncDB.Entry(oNewTrackedEmailAddress).State = System.Data.Entity.EntityState.Added;
                    //OBSyncDB.SaveChanges();
                    //OBSyncDB.Entry(oNewTrackedEmailAddress).State = System.Data.Entity.EntityState.Detached;

                    //EmailAddrBeanRel oContactEmailBeanRelation = new EmailAddrBeanRel()
                    //{
                    //    EmailAddressId = strEmailAddressID,
                    //    BeanId = strContactID,
                    //    BeanModule = "Contacts",
                    //    PrimaryAddress = 1,
                    //    ReplyToAddress=0,
                    //    DateCreated = DateTime.Now,
                    //    DateModified = DateTime.Now,
                    //    Deleted = 0

                    //};
                    //var oContactEmailBeanRelationRequest = new SugarRestRequest("EmailAddrBeanRel", RequestType.Create);
                    //oContactEmailBeanRelationRequest.Parameter = oContactEmailBeanRelation;
                    //List<string> selectContactEmailBeanRelationFields = new List<string>();
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.EmailAddressId));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.BeanId));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.PrimaryAddress));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.ReplyToAddress));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.Deleted));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.DateCreated));
                    //selectNewEmailAddressFieldsFields.Add(nameof(EmailAddrBeanRel.DateModified));
                    //oContactEmailBeanRelationRequest.Options.SelectFields = selectContactEmailBeanRelationFields;
                    //SugarRestResponse oNewEmailBeanResponse = client.Execute(oContactEmailBeanRelationRequest);
                    //strBeanID = (string)oNewEmailBeanResponse.Data;
                    ////Contact Tracker
                    //OBAPIEntitiesTracker oNewTrackedBean = new OBAPIEntitiesTracker();
                    //oNewTrackedBean.OBAPIEntityID = User.id.ToString();
                    //oNewTrackedBean.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.OBUserInformation;
                    //oNewTrackedBean.OBAPISugarCRMID = strBeanID;
                    //oNewTrackedBean.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.EmailAddressesBeans;
                    //OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedBean);
                    //OBSyncDB.Entry(oNewTrackedBean).State = System.Data.Entity.EntityState.Added;
                    //OBSyncDB.SaveChanges();
                    //OBSyncDB.Entry(oNewTrackedBean).State = System.Data.Entity.EntityState.Detached;

                    //Add Contact To Account
                    accounts_contacts oNewaccounts_contacts = new accounts_contacts();
                    Guid oNewaccounts_contactsGUID = Guid.NewGuid();
                    oNewaccounts_contacts.id = oNewaccounts_contactsGUID.ToString();
                    oNewaccounts_contacts.contact_id = strContactID;
                    oNewaccounts_contacts.account_id = strAccountID;
                    oNewaccounts_contacts.date_modified = DateTime.Now;
                    oNewaccounts_contacts.deleted = false;
                    OBCRMDB.accounts_contacts.Add(oNewaccounts_contacts);
                    OBCRMDB.SaveChanges();

                    //Account Contact Relation Tracker
                    OBAPIEntitiesTracker oNewTrackedAccountContact = new OBAPIEntitiesTracker();
                    oNewTrackedAccountContact.OBAPIEntityID = User.id.ToString();
                    oNewTrackedAccountContact.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.OBAccount;
                    oNewTrackedAccountContact.OBAPISugarCRMID = oNewaccounts_contactsGUID.ToString();
                    oNewTrackedAccountContact.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.AccountContacts;
                    OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedAccountContact);
                    OBSyncDB.Entry(oNewTrackedAccountContact).State = System.Data.Entity.EntityState.Added;
                    OBSyncDB.SaveChanges();
                    OBSyncDB.Entry(oNewTrackedAccountContact).State = System.Data.Entity.EntityState.Detached;
                    strAccountContactID = oNewaccounts_contactsGUID.ToString();

                    //Add Email To Contact
                    email_addresses oUserContactEmail = new email_addresses();
                    Guid gEmailID = Guid.NewGuid();
                    oUserContactEmail.id = gEmailID;
                    oUserContactEmail.email_address = User.email;
                    oUserContactEmail.email_address_caps = User.email.ToUpper();
                    oUserContactEmail.invalid_email = false;
                    oUserContactEmail.opt_out = false;
                    oUserContactEmail.confirm_opt_in = "confirmed-opt-in";
                    oUserContactEmail.date_created = DateTime.Now;
                    oUserContactEmail.date_modified = DateTime.Now;
                    oUserContactEmail.deleted = false;
                    OBCRMDB.email_addresses.Add(oUserContactEmail);
                    OBCRMDB.SaveChanges();

                    //Email Tracker
                    OBAPIEntitiesTracker oNewTrackedEmailAddress = new OBAPIEntitiesTracker();
                    oNewTrackedEmailAddress.OBAPIEntityID = User.id.ToString();
                    oNewTrackedEmailAddress.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.OBUserEmailAddress;
                    oNewTrackedEmailAddress.OBAPISugarCRMID = gEmailID.ToString();
                    oNewTrackedEmailAddress.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.EmailAddresses;
                    OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedEmailAddress);
                    OBSyncDB.Entry(oNewTrackedEmailAddress).State = System.Data.Entity.EntityState.Added;
                    OBSyncDB.SaveChanges();
                    OBSyncDB.Entry(oNewTrackedEmailAddress).State = System.Data.Entity.EntityState.Detached;
                    strEmailAddressID = gEmailID.ToString();

                    Guid gEmailBeanID = Guid.NewGuid();
                    email_addr_bean_rel oEmailContactRelation = new email_addr_bean_rel()
                    {
                        id = gEmailBeanID,
                        email_address_id = gEmailID,
                        bean_id = Guid.Parse(strContactID),
                        bean_module = "Contacts",
                        primary_address = true,
                        reply_to_address = false,
                        date_created = DateTime.Now,
                        date_modified = DateTime.Now,
                        deleted = false
                    };

                    OBCRMDB.email_addr_bean_rel.Add(oEmailContactRelation);
                    OBCRMDB.SaveChanges();

                    //Contact Tracker
                    OBAPIEntitiesTracker oNewTrackedBean = new OBAPIEntitiesTracker();
                    oNewTrackedBean.OBAPIEntityID = User.id.ToString();
                    oNewTrackedBean.OBAPIEntityTypeID = (int)OBAPIEnumEntityType.OBUserInformation;
                    oNewTrackedBean.OBAPISugarCRMID = gEmailBeanID.ToString();
                    oNewTrackedBean.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.EmailAddressesBeans;
                    OBSyncDB.OBAPIEntitiesTrackers.Add(oNewTrackedBean);
                    OBSyncDB.Entry(oNewTrackedBean).State = System.Data.Entity.EntityState.Added;
                    OBSyncDB.SaveChanges();
                    OBSyncDB.Entry(oNewTrackedBean).State = System.Data.Entity.EntityState.Detached;
                    strBeanID = gEmailBeanID.ToString();

                    //  request.Options.Query = String.Concat("contacts.id IN (SELECT bean_id FROM email_addr_bean_rel eabr JOIN email_addresses ea ON (eabr.email_address_id = ea.id) WHERE bean_module = 'Contacts' AND ea.email_address_caps = '", oOBUser.email, "' AND eabr.deleted=0)");
                    //request.Options.QueryPredicates = new List<QueryPredicate>();

                }

                catch (Exception e)
                {
                    Response.message = e.Message;
                    Response.referenceID = strAccountID;
                    Response.callerIP = Helpers.Network.GetIPAddress();
                    Response.responseDate = DateTime.Now;
                    Response.entityTypeId = OBAPIEnumEntityType.OBAccount;
                    Response.databaseName = obDb.Database.Connection.Database;
                    Response.data = e;
                    Response.success = false;

                    return Response;

                    throw;
                }




            }
            else
            {
                //UPDATE CRM Account


                var readAccountRequest = new SugarRestRequest("Accounts", RequestType.ReadById);
                strAccountID = oTrackedUser.OBAPISugarCRMID;
                readAccountRequest.Parameter = strAccountID;
                SugarRestResponse accountReadResponse = client.Execute(readAccountRequest);
                Account oAccountToUpdate = (Account)accountReadResponse.Data;

                var updateAccountRequest = new SugarRestRequest(RequestType.Update);
                oAccountToUpdate.Name = String.Concat("OB:", User.email.ToLower());
       
                updateAccountRequest.Parameter = oAccountToUpdate;
                List<string> selectAccountToUpdateFields = new List<string>();

                selectAccountToUpdateFields.Add(nameof(Account.Name));


                updateAccountRequest.Options.SelectFields = selectAccountToUpdateFields;
                SugarRestResponse responseAccountUpdate = client.Execute<Account>(updateAccountRequest);









            }




            //Update Customs
            if (!String.IsNullOrEmpty(strAccountID))
            {
                Guid oAccountID = Guid.Parse(strAccountID);
                accounts_cstm oCRMAccountCustomInfo = OBCRMDB.accounts_cstm.Where(w => w.id_c == oAccountID).FirstOrDefault();

                if (oCRMAccountCustomInfo != null)
                {
                    oCRMAccountCustomInfo.isorgbubblecustomer_c = true;
                    oCRMAccountCustomInfo.orgbubbleid_c = User.id;

                    general_packages oUOBPack = obDb.general_packages.Where(w => w.id == User.package).FirstOrDefault();

                    string strPackage = (oUOBPack == null) ? "N/A" : oUOBPack.name;

                    oCRMAccountCustomInfo.orgbubblepackage_c = strPackage;
                    oCRMAccountCustomInfo.isorgbubbleactive_c = (User.status == 1 ? true : false);


                    oCRMAccountCustomInfo.more_account_information_c = SuiteCRM.GetOBUserAccountsListInHTML(User.id.ToString()); ;


                    OBCRMDB.accounts_cstm.Add(oCRMAccountCustomInfo);
                    OBCRMDB.Entry(oCRMAccountCustomInfo).State = System.Data.Entity.EntityState.Modified;
                    OBCRMDB.SaveChanges();



                    SuiteCRM.UpdateOrgBubbleUsersActivities(User);



                }
            }




            Response.message = string.Concat("Added/Updated OB User ", User.email);
            Response.referenceID = strAccountID;
            Response.callerIP = Helpers.Network.GetIPAddress();
            Response.responseDate = DateTime.Now;
            Response.entityTypeId = OBAPIEnumEntityType.OBAccount;
            Response.databaseName = obDb.Database.Connection.Database;
            Response.data = strAccountID;

            Response.success = true;



            return Response;


        }


        public static OBAPIResponse UpdateOrgBubbleUsersActivities(general_users User)
        {

            OBAPIEntitiesTracker oTrackedUser = GetSuiteCRMRecordID(User.id.ToString(),
                                                                       (int)OBAPIEnumEntityType.OBAccount,
                                                                       (int)OBAPISuiteCRMModuleTypes.Accounts);



            OBAPIResponse Response = new OBAPIResponse();




            if (!String.IsNullOrEmpty(oTrackedUser.OBAPISugarCRMID))
            {

                List<orgbubble_socialmedia_posts> obActiLst = obViewsDb.orgbubble_socialmedia_posts.Where(w => w.uid == User.id).ToList();


                if (obActiLst != null && obActiLst.Count>0)
                {

                    foreach (orgbubble_socialmedia_posts oPost in obActiLst)
                    {

                        OBAPIEnumEntityType entTye = OBAPIEnumEntityType.NullVal;

                        switch (oPost.socialmedia)
                        {
                            case "FACEBOOK":
                                entTye = OBAPIEnumEntityType.OBFacebookPost;
                                break;
                            case "INSTAGRAM":
                                entTye = OBAPIEnumEntityType.OBInstagramPost;
                                break;
                            case "TWITTER":
                                entTye = OBAPIEnumEntityType.OBTwitterPost;
                                break;
                            case "LINKEDIN":
                                entTye = OBAPIEnumEntityType.OBLinkedInPost;
                                break;
                            case "PINTEREST":
                                entTye = OBAPIEnumEntityType.OBPinterestPost;
                                break;
                          
                                
                        }


                        if (entTye != OBAPIEnumEntityType.NullVal)
                        {
                            OBAPIEntitiesTracker oTrackedActivity = GetSuiteCRMRecordID(oPost.id.ToString(),
                                                                       (int)entTye,
                                                                       (int)OBAPISuiteCRMModuleTypes.Notes);


                            if (String.IsNullOrEmpty(oTrackedActivity.OBAPISugarCRMID))
                            {
                                //Serialize Json Object
                                OrgBubblePost_response oObPostResults = new OrgBubblePost_response(oPost);

                                //Add Note
                                var client = OBSync.Models.Helpers.SuiteCRM.GetSuiteCRMClient();
                                  
                                Note oNote = new Note()
                                {
                                    ContactId = "",
                                    CreatedBy = "6fa5fc21-77d4-ca8d-9e83-5de1a1d5f2ba",
                                    AssignedUserId = "6fa5fc21-77d4-ca8d-9e83-5de1a1d5f2ba",
                                    ParentType = "Accounts",
                                    ParentId = oTrackedUser.OBAPISugarCRMID,
                                    Deleted = 0,
                                    DateEntered = oPost.created,
                                    DateModified = oPost.changed,

                                    Name = string.Concat(oPost.socialmedia, " to ", oPost.category_or_type, " - Status Code:", oPost.status),
                                    Description = oObPostResults.TextMessage,

                                };
                                var oNewNote = new SugarRestRequest("Notes", RequestType.Create);
                                oNewNote.Parameter = oNote;
                                List<string> selectNewNoteFields = new List<string>();

                                selectNewNoteFields.Add(nameof(Note.ContactId));
                                selectNewNoteFields.Add(nameof(Note.CreatedBy));
                                selectNewNoteFields.Add(nameof(Note.AssignedUserId));
                                selectNewNoteFields.Add(nameof(Note.ParentType));
                                selectNewNoteFields.Add(nameof(Note.ParentId));
                                selectNewNoteFields.Add(nameof(Note.Deleted));
                                selectNewNoteFields.Add(nameof(Note.DateEntered));
                                selectNewNoteFields.Add(nameof(Note.DateModified));
                                selectNewNoteFields.Add(nameof(Note.Name));
                                selectNewNoteFields.Add(nameof(Note.Description));

                                oNewNote.Options.SelectFields = selectNewNoteFields;
                                SugarRestResponse oNewAccountrRequestResponse = client.Execute(oNewNote);
                                string strNoteID = (string)oNewAccountrRequestResponse.Data;


                                //SugarRestResponse response = client.Execute<Note>(oNewNote);

                                //UPDATE CRM CUSTOM FIELD
                                notes_cstm oNewCRMNote = OBCRMDB.notes_cstm.Find(Guid.Parse(strNoteID)); //new notes_cstm();
                                //Guid gNoteID = Guid.NewGuid();
                                if (oNewCRMNote != null)
                                {
                                    oNewCRMNote.activitydetails_c = oObPostResults.HTML;
                                    oNewCRMNote.status_c = oPost.status.ToString();
                                    oNewCRMNote.socialmedia_c = oPost.socialmedia;
                                    oNewCRMNote.recordid_c = oPost.id;
                                    OBCRMDB.notes_cstm.Add(oNewCRMNote);
                                    OBCRMDB.Entry(oNewCRMNote).State = System.Data.Entity.EntityState.Modified;
                                    OBCRMDB.SaveChanges();
                                }
                              
                                                                                             



                                //ADD RECORD TO TRACKER
                                OBAPIEntitiesTracker oNewEntityNote = new OBAPIEntitiesTracker();
                                oNewEntityNote.OBAPIEntityID = oPost.id.ToString();
                                oNewEntityNote.OBAPIEntityTypeID = (int)entTye;
                                oNewEntityNote.OBAPISugarCRMID = strNoteID;
                                oNewEntityNote.OBAPISugarModuleID = (int)OBAPISuiteCRMModuleTypes.Notes;
                                OBSyncDB.OBAPIEntitiesTrackers.Add(oNewEntityNote);
                                OBSyncDB.Entry(oNewEntityNote).State = System.Data.Entity.EntityState.Added;
                                OBSyncDB.SaveChanges();
                                OBSyncDB.Entry(oNewEntityNote).State = System.Data.Entity.EntityState.Detached;
                                
                                //strBeanID = gEmailBeanID.ToString();






                            }
                            else
                            {
                                //Update Note


                            }


                        }
                       




                    }

                }

            }



            return Response;



            }






        public static OBAPIEntitiesTracker GetSuiteCRMRecordID(string OBAPIEntityID,
                                                                  int OBAPIEntityTypeID,
                                                                  int OBAPISugarModuleID)
        {

            OBAPIEntitiesTracker oTracker = OBSyncDB.OBAPIEntitiesTrackers
                                                    .Where(w => w.OBAPIEntityID == OBAPIEntityID
                                                    && w.OBAPIEntityTypeID == OBAPIEntityTypeID
                                                    && w.OBAPISugarModuleID == OBAPISugarModuleID).FirstOrDefault();

            if (oTracker != null)
            {
                return oTracker;
            }

            return new OBAPIEntitiesTracker();
            
        }


        public static string GetOBUserAccountsListInHTML (string OBUserID)
        {

            List<orgbubble_socialmedia_accounts> OBUserAccounts = obViewsDb.orgbubble_socialmedia_accounts.Where(w => w.uid == OBUserID).ToList();
            string strHTMLTable = "<table style='width:100%'> ##HEADER## ##ROWS## </table>";

            if (OBUserAccounts!= null && OBUserAccounts.Count>0)

            {

                var names = typeof(orgbubble_socialmedia_accounts).GetProperties()
                        .Select(property => property.Name)
                        .ToArray();



                string strHTMLHeader = "";

                foreach (string field in names)
                {
                    strHTMLHeader += String.Concat("<th>", field, "</th>");
                }

                strHTMLHeader = string.Concat("<tr>", strHTMLHeader, "</tr>");

                string strHTMLRows = "";

                foreach (orgbubble_socialmedia_accounts oAccount in OBUserAccounts)
                {
                    strHTMLRows += "<tr>";
          
                    strHTMLRows += string.Concat( "<td>", oAccount.socialmedia, "</td>");

                    strHTMLRows += string.Concat("<td>", oAccount.uid, "</td>");

                    strHTMLRows += string.Concat("<td>", oAccount.pid, "</td>");

                    strHTMLRows += string.Concat("<td>", oAccount.type, "</td>");

                    strHTMLRows += string.Concat("<td>", oAccount.fullname, "</td>");

                    strHTMLRows += string.Concat("<td>", oAccount.url, "</td>");

                    strHTMLRows += string.Concat("<td>", oAccount.status, "</td>");

                    strHTMLRows += string.Concat("<td>", oAccount.changed, "</td>");

                    strHTMLRows += string.Concat("<td>", oAccount.created, "</td>");

                    strHTMLRows += "</tr>";
                    
                }




                strHTMLTable = strHTMLTable.Replace("##HEADER##", strHTMLHeader).Replace("##ROWS##", strHTMLRows);


                return strHTMLTable;
            }
            else
            {
                return "";
            }




        }














    }
}