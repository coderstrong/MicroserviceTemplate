using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Domain.AggregatesModel.EmployeeAggregate
{
    public class Employee : Entity, IAggregateRoot
    {
        [MaxLength(90)]
        public string FullName { get; set; }
        public Address Address { get; set; }
        public int EmployeeTypeId { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public List<Project> Projects { get; set; }

        public Employee() { }
        public Employee(string fullName, Address address, EmployeeType employeeType)
        {
            this.FullName = fullName;
            this.Address = address;
            this.EmployeeTypeId = employeeType.Id;
            this.Projects = new List<Project>();
        }

        public void AddProject(int projectId, string name, string description, DateTime start, DateTime end)
        {
            var existProject = this.Projects.Where(o => o.ProjectId == projectId).SingleOrDefault();
            if(existProject == null)
            {
                var project = new Project(projectId, name, description, start, end);
                this.Projects.Add(project);
            }
        }
    }
}
