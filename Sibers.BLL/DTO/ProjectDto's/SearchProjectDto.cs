﻿using Sibers.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.BLL.DTO.ProjectDto_s
{
    public class SearchProjectDto
    {
        public long? ProjectId { get; set; }
        public string? Name { get; set; }
        public string? CustomerName { get; set; }
        public string? PerformerName { get; set; }
        public int? Priority { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public long? ProjectManagerId { get; set; }
    }
}