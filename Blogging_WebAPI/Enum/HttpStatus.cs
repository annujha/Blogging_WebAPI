using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogging_WebAPI.Enum.HttpStatus
{
    public class HttpResponseDetails<TResponseType>
    {
        public int APIResponseCode { get; set; }
        public string APIResponseMessage { get; set; }
        public TResponseType Response { get; set; }
    }

}