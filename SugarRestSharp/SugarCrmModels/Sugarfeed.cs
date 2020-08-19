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
    /// A class which represents the sugarfeed table.
    /// </summary>
	[ModuleProperty(ModuleName = "Sugarfeed", TableName="sugarfeed")]
	public partial class Sugarfeed : EntityBase
	{
		[JsonProperty(PropertyName = "id")]
		public virtual string Id { get; set; }

		[JsonProperty(PropertyName = "name")]
		public virtual string Name { get; set; }

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

		[JsonProperty(PropertyName = "related_module")]
		public virtual string RelatedModule { get; set; }

		[JsonProperty(PropertyName = "related_id")]
		public virtual string RelatedId { get; set; }

		[JsonProperty(PropertyName = "link_url")]
		public virtual string LinkUrl { get; set; }

		[JsonProperty(PropertyName = "link_type")]
		public virtual string LinkType { get; set; }

	}
}