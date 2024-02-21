﻿using Microsoft.VisualBasic;

namespace TaskManagerCore.Model
{
    /// <summary>
    /// Immutable class (ie. 'record' after C# 9.0)
    /// 
    /// As per requirements:
    /// - The Id does not have a publicly accessible setter (populated at construction and then passed through builder methods internally)
    /// - Description, Notes, Completed, DueDate (Optional)
    /// - Overdue method
    /// </summary>
    public class TaskData
    {
        public string Id { get; }

        public string Description { get; }

        public string Notes { get; }

        public bool Completed { get; }

        public DateTime? DueDate { get; }

        public bool Overdue { get => IsOverdue(); }

        #region constructors

        public TaskData(string description)
        {
            Id = "";
            Description = description;
            Notes = "";
            Completed = false;
        }

        public TaskData(string description, string notes, DateTime? dueDate = null)
            : this(description)
        {
            Id = "";
            Description = description;
            Notes = notes;
            DueDate = dueDate;
        }

        public TaskData(string id, string description, string notes, bool completed, DateTime? dueDate)
        {
            Id = id;
            Description = description;
            Notes = notes;
            Completed = completed;
            DueDate = dueDate;
        }

        #endregion
        /// <summary>
        /// Calculates if Task is overdue, same result as 'Overdue' property
        /// </summary>
        /// <returns></returns>
        public virtual bool IsOverdue() => DueDate != null && !Completed && ComparisonTime() > DueDate;
        //{
        //    //if (DueDate == null)
        //    //{
        //    //    return false;
        //    //}

        //    //return !Completed && ComparisonTime() > DueDate;
        //    return DueDate != null && !Completed && ComparisonTime() > DueDate;
        //}

        #region Builder methods
        public virtual TaskData WithDescription(string value)
        {
            //value ??= string.Empty; // compound assignment
            if (value == null)
            {
                value = string.Empty;
            }
            return new TaskData(Id, value, Notes, Completed, DueDate);
        }

        public virtual TaskData WithNotes(string value)
        {
            //value ??= string.Empty; // compound assignment
            if (value == null)
            {
                value = string.Empty;
            }
            return new TaskData(Id, Description, value, Completed, DueDate);
        }

        public virtual TaskData WithCompleted(bool value)
        {
            return new TaskData(Id, Description, Notes, value, DueDate);
        }

        public virtual TaskData WithDueDate(DateTime? value)
        {
            return new TaskData(Id, Description, Notes, Completed, value);
        }

        #endregion

        /// <summary>
        /// Protected method that can be overridden for tests by extending class.
        /// Can be used to test the repeating and habitual classes
        /// </summary>
        /// <returns></returns>
        protected virtual DateTime ComparisonTime()
        {
            return DateTime.Now;
        }
    }
}