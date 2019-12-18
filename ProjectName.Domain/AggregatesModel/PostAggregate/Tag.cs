using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectName.Domain.AggregatesModel.PostAggregate
{
    public class Tag
    {
        public string Name { get; private set; }
        public Tag(string Name)
        {
            this.Name = Name;
        }
    }
}
