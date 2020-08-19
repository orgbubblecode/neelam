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
    /// A class which represents the calls_leads table.
    /// </summary>
	[ModuleProperty(ModuleName = "CallsLeads", TableName="calls_leads")]
	public partial class CallsLeads : EntityBase
	{
		[JsonProperty(PropertyName = "id")]
		public virtual string Id { get; set; }

		[JsonProperty(PropertyName = "call_id")]
		public virtual string CallId { get; set; }

		[JsonProperty(PropertyName = "lead_id")]
		public virtual string LeadId { get; set; }

		[JsonProperty(PropertyName = "required")]
		public virtual string Required { get; set; }

		[JsonProperty(PropertyName = "accept_status")]
		public virtual string AcceptStatus { get; set; }

		[JsonProperty(PropertyName = "date_modified")]
		public virtual DateTime? DateModified { get; set; }

		[JsonProperty(PropertyName = "deleted")]
		public virtual sbyte? Deleted { get; set; }

	}
}