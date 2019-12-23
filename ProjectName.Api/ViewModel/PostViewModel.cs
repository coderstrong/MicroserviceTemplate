using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectName.Api.ViewModel
{
    public class PostViewModel
    {
        public string Title { get; private set; }

        public string Author { get; private set; }

        public string Content { get; private set; }

        public string Status { get; private set; }
    }
}
