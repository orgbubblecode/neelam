using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using DescriptionLibrary;

namespace OBSync.Models
{
    

    public enum OBAPIEnumEntityType
    {
        [Description("OrgBubble Account")]
        NullVal = 0,

        [Description("OrgBubble Account")]
        OBAccount = 1000,

        [Description("OrgBubble User Information")]
        OBUserInformation = 1001,


        OBUserLogin = 1002,


        [Description("OrgBubble User Email Address")]
        OBUserEmailAddress = 1003,


        [Description("Facebook Post")]
        OBFacebookPost = 1004,
        [Description("Insagram Post")]
        OBInstagramPost = 1005,
        [Description("Twitter Post")]
        OBTwitterPost = 1006,
        [Description("LinkedIn Post")]
        OBLinkedInPost = 1007,
        [Description("Pinterests Post")]
        OBPinterestPost = 1008,



        [Description("AllMyBio Account")]
        AMBAccount = 2000,
        AMBUserInformation = 2001,
        AMBUserLogin = 2002,

        [Description("AllMyBio User Email Address")]
        AMBUserEmailAddress = 2003,







    }


    public enum OBAPISuiteCRMModuleTypes
    {

        Accounts,
        ACLRoles,
        AM_ProjectTemplates,
        AOK_KnowledgeBase,
        AOP_Case_Updates,
        AOR_Reports,
        AOS_Contracts,
        AOS_Invoices,
        AOS_Line_Item_Groups,
        AOS_Products,
        AOS_Product_Categories,
        AOS_Quotes,
        AOW_Processed,
        AOW_WorkFlow,
        Bugs,
        Calls,
        CampaignLog,
        Campaigns,
        Cases,
        Contacts,
        Documents,
        EmailMarketing,
        Emails,
        EmailTemplates,
        FP_events,
        FP_Event_Locations,
        jjwg_Maps,
        Leads,
        Meetings,
        OAuth2Clients,
        OAuthKeys,
        Opportunities,
        Project,
        ProjectTask,
        ProspectLists,
        Prospects,
        Releases,
        Roles,
        Schedulers,
        SecurityGroups,
        SurveyQuestionOptions,
        SurveyQuestions,
        SurveyResponses,
        Surveys,
        Tasks,
        Users,

        EmailAddresses,
        EmailAddressesBeans,
        AccountContacts,
        Notes
   


    }


}