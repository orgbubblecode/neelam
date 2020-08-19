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
    /// A class which represents the schedulers table.
    /// </summary>
	[ModuleProperty(ModuleName = "Schedulers", TableName="schedulers")]
	public partial class Scheduler : EntityBase
	{
		[JsonProperty(PropertyName = "id")]
		public virtual string Id { get; set; }

		[JsonProperty(PropertyName = "deleted")]
		public virtual sbyte? Deleted { get; set; }

		[JsonProperty(PropertyName = "date_entered")]
		public virtual DateTime? DateEntered { get; set; }

		[JsonProperty(PropertyName = "date_modified")]
		public virtual DateTime? DateModified { get; set; }

		[JsonProperty(PropertyName = "created_by")]
		public virtual string CreatedBy { get; set; }

		[JsonProperty(PropertyName = "modified_user_id")]
		public virtual string ModifiedUserId { get; set; }

		[JsonProperty(PropertyName = "name")]
		public virtual string Name { get; set; }

		[JsonProperty(PropertyName = "job")]
		public virtual string Job { get; set; }

		[JsonProperty(PropertyName = "date_time_start")]
		public virtual DateTime? DateTimeStart { get; set; }

		[JsonProperty(PropertyName = "date_time_end")]
		public virtual DateTime? DateTimeEnd { get; set; }

		[JsonProperty(PropertyName = "job_interval")]
		public virtual string JobInterval { get; set; }

		[JsonProperty(PropertyName = "time_from")]
		public virtual string TimeFrom { get; set; }

		[JsonProperty(PropertyName = "time_to")]
		public virtual string TimeTo { get; set; }

		[JsonProperty(PropertyName = "last_run")]
		public virtual DateTime? LastRun { get; set; }

		[JsonProperty(PropertyName = "status")]
		public virtual string Status { get; set; }

		[JsonProperty(PropertyName = "catch_up")]
		public virtual sbyte? CatchUp { get; set; }

	}
}