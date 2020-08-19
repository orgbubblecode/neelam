// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591

namespace SugarRestSharp.Models
{
	using System;
	using Newtonsoft.Json;
	

    /// <summary>
    /// A class which represents the leads table.
    /// </summary>
	[ModuleProperty(ModuleName = "Leads", TableName="leads")]
	public partial class Lead : EntityBase
	{
		[JsonProperty(PropertyName = "id")]
		public virtual string Id { get; set; }

		[JsonProperty(PropertyName = "date_entered")]
		public virtual DateTime? DateEntered { get; set; }

		[JsonProperty(PropertyName = "date_modified")]
		public virtual DateTime? DateModified { get; set; }

		[JsonProperty(PropertyName = "modified_user_id")]
		public virtual string ModifiedUserId { get; set; }

		[JsonProperty(PropertyName = "created_by")]
		public virtual string CreatedBy { get; set; }

		[JsonProperty(PropertyName = "description")]
		public virtual string Description { get; set; }

		[JsonProperty(PropertyName = "deleted")]
		public virtual sbyte? Deleted { get; set; }

		[JsonProperty(PropertyName = "assigned_user_id")]
		public virtual string AssignedUserId { get; set; }

		[JsonProperty(PropertyName = "salutation")]
		public virtual string Salutation { get; set; }

		[JsonProperty(PropertyName = "first_name")]
		public virtual string FirstName { get; set; }

		[JsonProperty(PropertyName = "last_name")]
		public virtual string LastName { get; set; }

		[JsonProperty(PropertyName = "title")]
		public virtual string Title { get; set; }

		[JsonProperty(PropertyName = "department")]
		public virtual string Department { get; set; }

		[JsonProperty(PropertyName = "do_not_call")]
		public virtual sbyte? DoNotCall { get; set; }

		[JsonProperty(PropertyName = "phone_home")]
		public virtual string PhoneHome { get; set; }

		[JsonProperty(PropertyName = "phone_mobile")]
		public virtual string PhoneMobile { get; set; }

		[JsonProperty(PropertyName = "phone_work")]
		public virtual string PhoneWork { get; set; }

		[JsonProperty(PropertyName = "phone_other")]
		public virtual string PhoneOther { get; set; }

		[JsonProperty(PropertyName = "phone_fax")]
		public virtual string PhoneFax { get; set; }

		[JsonProperty(PropertyName = "primary_address_street")]
		public virtual string PrimaryAddressStreet { get; set; }

		[JsonProperty(PropertyName = "primary_address_city")]
		public virtual string PrimaryAddressCity { get; set; }

		[JsonProperty(PropertyName = "primary_address_state")]
		public virtual string PrimaryAddressState { get; set; }

		[JsonProperty(PropertyName = "primary_address_postalcode")]
		public virtual string PrimaryAddressPostalcode { get; set; }

		[JsonProperty(PropertyName = "primary_address_country")]
		public virtual string PrimaryAddressCountry { get; set; }

		[JsonProperty(PropertyName = "alt_address_street")]
		public virtual string AltAddressStreet { get; set; }

		[JsonProperty(PropertyName = "alt_address_city")]
		public virtual string AltAddressCity { get; set; }

		[JsonProperty(PropertyName = "alt_address_state")]
		public virtual string AltAddressState { get; set; }

		[JsonProperty(PropertyName = "alt_address_postalcode")]
		public virtual string AltAddressPostalcode { get; set; }

		[JsonProperty(PropertyName = "alt_address_country")]
		public virtual string AltAddressCountry { get; set; }

		[JsonProperty(PropertyName = "assistant")]
		public virtual string Assistant { get; set; }

		[JsonProperty(PropertyName = "assistant_phone")]
		public virtual string AssistantPhone { get; set; }

		[JsonProperty(PropertyName = "converted")]
		public virtual sbyte? Converted { get; set; }

		[JsonProperty(PropertyName = "refered_by")]
		public virtual string ReferedBy { get; set; }

		[JsonProperty(PropertyName = "lead_source")]
		public virtual string LeadSource { get; set; }

		[JsonProperty(PropertyName = "lead_source_description")]
		public virtual string LeadSourceDescription { get; set; }

		[JsonProperty(PropertyName = "status")]
		public virtual string Status { get; set; }

		[JsonProperty(PropertyName = "status_description")]
		public virtual string StatusDescription { get; set; }

		[JsonProperty(PropertyName = "reports_to_id")]
		public virtual string ReportsToId { get; set; }

		[JsonProperty(PropertyName = "account_name")]
		public virtual string AccountName { get; set; }

		[JsonProperty(PropertyName = "account_description")]
		public virtual string AccountDescription { get; set; }

		[JsonProperty(PropertyName = "contact_id")]
		public virtual string ContactId { get; set; }

		[JsonProperty(PropertyName = "account_id")]
		public virtual string AccountId { get; set; }

		[JsonProperty(PropertyName = "opportunity_id")]
		public virtual string OpportunityId { get; set; }

		[JsonProperty(PropertyName = "opportunity_name")]
		public virtual string OpportunityName { get; set; }

		[JsonProperty(PropertyName = "opportunity_amount")]
		public virtual string OpportunityAmount { get; set; }

		[JsonProperty(PropertyName = "campaign_id")]
		public virtual string CampaignId { get; set; }

		[JsonProperty(PropertyName = "birthdate")]
		public virtual DateTime? Birthdate { get; set; }

		[JsonProperty(PropertyName = "portal_name")]
		public virtual string PortalName { get; set; }

		[JsonProperty(PropertyName = "portal_app")]
		public virtual string PortalApp { get; set; }

		[JsonProperty(PropertyName = "website")]
		public virtual string Website { get; set; }

	}
}