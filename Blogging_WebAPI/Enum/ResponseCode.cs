using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogging_WebAPI.Enum.APIResponseCode
{
    public class ResponseCode
    {
    }
    public class APIResponseCode
    {
        public const int Success = 0;
        public const int ExceptionGenerated = -1;
        public const int Ok = 200;
        public const int DataInsertedSuccessFully = 201;
        public const int DataUpdatedSuccessFully = 202;
        public const int DataDeletedSuccessFully = 203;
        public const int NoDataFound = 204;
    }
    public class APIResponseMessage
    {
        public const string Success = "Success";
        public const string ExceptionGenerated = "There is some issue.Please try after some time.";
        public const string DataInsertedSuccessFully = "New blog data has been inserted successfully.";
        public const string DataUpdatedSuccessFully = "Blog data has been updated successfully.";
        public const string DataDeletedSuccessFully = "Blog data has been deleted successfully.";
        public const string NoDataFound = "There is no blog record on specified id.";
    }
}