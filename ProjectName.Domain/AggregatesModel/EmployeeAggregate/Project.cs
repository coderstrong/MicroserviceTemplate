using System;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Domain.AggregatesModel.EmployeeAggregate
{
    public class Project : Entity
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public int EmployeeId { get; set; }

        public Project(int projectId, string name, string description, DateTime begin, DateTime end)
        {
            this.ProjectId = projectId;
            this.Name = name;
            this.Description = description;
            this.Begin = begin;
            this.End = end;
        }
    }
}
