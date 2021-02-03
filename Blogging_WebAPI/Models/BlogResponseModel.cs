using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogging_WebAPI.Models
{
    public class BlogResponseModel
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
    public class EditBlogResponseModel
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
    public class DeleteBlogResponseModel
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}