using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogging_WebAPI.Models
{
    public class BlogModel
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}