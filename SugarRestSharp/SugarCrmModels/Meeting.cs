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
    /// A class which represents the meetings table.
    /// </summary>
	[ModuleProperty(ModuleName = "Meetings", TableName="meetings")]
	public partial class Meeting : EntityBase
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

		[JsonProperty(PropertyName = "location")]
		public virtual string Location { get; set; }

		[JsonProperty(PropertyName = "password")]
		public virtual string Password { get; set; }

		[JsonProperty(PropertyName = "join_url")]
		public virtual string JoinUrl { get; set; }

		[JsonProperty(PropertyName = "host_url")]
		public virtual string HostUrl { get; set; }

		[JsonProperty(PropertyName = "displayed_url")]
		public virtual string DisplayedUrl { get; set; }

		[JsonProperty(PropertyName = "creator")]
		public virtual string Creator { get; set; }

		[JsonProperty(PropertyName = "external_id")]
		public virtual string ExternalId { get; set; }

		[JsonProperty(PropertyName = "duration_hours")]
		public virtual int? DurationHours { get; set; }

		[JsonProperty(PropertyName = "duration_minutes")]
		public virtual int? DurationMinutes { get; set; }

		[JsonProperty(PropertyName = "date_start")]
		public virtual DateTime? DateStart { get; set; }

		[JsonProperty(PropertyName = "date_end")]
		public virtual DateTime? DateEnd { get; set; }

		[JsonProperty(PropertyName = "parent_type")]
		public virtual string ParentType { get; set; }

		[JsonProperty(PropertyName = "status")]
		public virtual string Status { get; set; }

		[JsonProperty(PropertyName = "type")]
		public virtual string Type { get; set; }

		[JsonProperty(PropertyName = "parent_id")]
		public virtual string ParentId { get; set; }

		[JsonProperty(PropertyName = "reminder_time")]
		public virtual int? ReminderTime { get; set; }

		[JsonProperty(PropertyName = "email_reminder_time")]
		public virtual int? EmailReminderTime { get; set; }

		[JsonProperty(PropertyName = "email_reminder_sent")]
		public virtual sbyte? EmailReminderSent { get; set; }

		[JsonProperty(PropertyName = "outlook_id")]
		public virtual string OutlookId { get; set; }

		[JsonProperty(PropertyName = "sequence")]
		public virtual int? Sequence { get; set; }

		[JsonProperty(PropertyName = "repeat_type")]
		public virtual string RepeatType { get; set; }

		[JsonProperty(PropertyName = "repeat_interval")]
		public virtual int? RepeatInterval { get; set; }

		[JsonProperty(PropertyName = "repeat_dow")]
		public virtual string RepeatDow { get; set; }

		[JsonProperty(PropertyName = "repeat_until")]
		public virtual DateTime? RepeatUntil { get; set; }

		[JsonProperty(PropertyName = "repeat_count")]
		public virtual int? RepeatCount { get; set; }

		[JsonProperty(PropertyName = "repeat_parent_id")]
		public virtual string RepeatParentId { get; set; }

		[JsonProperty(PropertyName = "recurring_source")]
		public virtual string RecurringSource { get; set; }

	}
}