﻿using Sibers.DAL.Common;
using Sibers.DAL.RelationModels;
using System.ComponentModel.DataAnnotations;

namespace Sibers.DAL.Models
{
    public class Project : BaseEntity<long>
    {
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string PerformerName { get; set; }
        public int Priority { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public Employee? ProjectManager { get; set; }
        public long? ProjectManagerId { get; set; }
        public ICollection<Job>? Jobs { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<ProjectEmployee>? ProjectEmployees { get; set; }
    }
}
