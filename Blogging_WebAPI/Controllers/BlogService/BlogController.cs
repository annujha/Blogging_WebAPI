using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using DataLayerForBlogging;
using Blogging_WebAPI.Models;
using Blogging_WebAPI.Enum.HttpStatus;
using Blogging_WebAPI.Enum.APIResponseCode;

namespace Blogging_WebAPI.Controllers.BlogService
{
    public class BlogController : ApiController
    {
        [Authorize(Roles = "user")]
        [HttpGet]
        [Route("api/GetCreatedBlogsList")]
        public IHttpActionResult GetCreatedBlogsList()
        {
            using (BloggingEntities bloggingEntities = new BloggingEntities())
            {
                return Ok(bloggingEntities.BlogLists.Where(data=>data.Active==true).ToList());
            }
        }
        [Authorize(Roles = "user")]
        [HttpPost]
        [Route("api/InserNewBlog")]
        public IHttpActionResult InserNewBlog(BlogModel BlogModel)
        {
            BlogResponseModel BlogResponseModel = new BlogResponseModel();
            try { 
            using (BloggingEntities bloggingEntities = new BloggingEntities())
            {
                bloggingEntities.Blogging_Operations("Insert", 0, BlogModel.Title, BlogModel.Content);
                bloggingEntities.SaveChanges();

                BlogResponseModel.ResponseCode = APIResponseCode.DataInsertedSuccessFully;
                BlogResponseModel.ResponseMessage = APIResponseMessage.DataInsertedSuccessFully;
                BlogResponseModel.Title = BlogModel.Title;
                BlogResponseModel.Content = BlogModel.Content;

                return Ok(new HttpResponseDetails<BlogResponseModel>()
                {
                    APIResponseCode = APIResponseCode.Success,
                    APIResponseMessage = APIResponseMessage.Success,
                    Response = BlogResponseModel
                });
            }
            }
            catch (Exception ex)
            {
                return Ok(new HttpResponseDetails<BlogResponseModel>()
                {
                    APIResponseCode = APIResponseCode.ExceptionGenerated,
                    APIResponseMessage = APIResponseMessage.ExceptionGenerated,
                    Response = BlogResponseModel
                });

            }
        }
        [Authorize(Roles = "user")]
        [HttpPost]
        [Route("api/EditBlogDetails")]
        public IHttpActionResult EditBlogDetails(BlogModel BlogModel)
        {
            EditBlogResponseModel EditBlogResponseModel = new EditBlogResponseModel();
            try
            {
                using (BloggingEntities bloggingEntities = new BloggingEntities())
                {
                    bloggingEntities.Blogging_Operations("Update", BlogModel.BlogId, BlogModel.Title, BlogModel.Content);
                    bloggingEntities.SaveChanges();
                    if (bloggingEntities.BlogLists.Where(data => data.Id== BlogModel.BlogId).Count()==0)
                    {
                        EditBlogResponseModel.ResponseCode = APIResponseCode.NoDataFound;
                        EditBlogResponseModel.ResponseMessage = APIResponseMessage.NoDataFound;
                        EditBlogResponseModel.BlogId = BlogModel.BlogId;
                        EditBlogResponseModel.Title = BlogModel.Title;
                        EditBlogResponseModel.Content = BlogModel.Content;
                    }
                    else
                    {
                        EditBlogResponseModel.ResponseCode = APIResponseCode.DataUpdatedSuccessFully;
                        EditBlogResponseModel.ResponseMessage = APIResponseMessage.DataUpdatedSuccessFully;
                        EditBlogResponseModel.BlogId = BlogModel.BlogId;
                        EditBlogResponseModel.Title = BlogModel.Title;
                        EditBlogResponseModel.Content = BlogModel.Content;
                    }

                    return Ok(new HttpResponseDetails<EditBlogResponseModel>()
                    {
                        APIResponseCode = APIResponseCode.Success,
                        APIResponseMessage = APIResponseMessage.Success,
                        Response = EditBlogResponseModel
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok(new HttpResponseDetails<EditBlogResponseModel>()
                {
                    APIResponseCode = APIResponseCode.ExceptionGenerated,
                    APIResponseMessage = APIResponseMessage.ExceptionGenerated,
                    Response = EditBlogResponseModel
                });

            }
        }
        [Authorize(Roles = "user")]
        [HttpPost]
        [Route("api/DeleteBlog")]
        public IHttpActionResult DeleteBlog(BlogModel BlogModel)
        {
            DeleteBlogResponseModel DeleteBlogResponseModel = new DeleteBlogResponseModel();
            try
            {
                using (BloggingEntities bloggingEntities = new BloggingEntities())
                {
                    bloggingEntities.Blogging_Operations("Delete", BlogModel.BlogId, string.Empty, string.Empty);
                    bloggingEntities.SaveChanges();
                    if (bloggingEntities.BlogLists.Where(data => data.Id == BlogModel.BlogId).Count() == 0)
                    {
                        DeleteBlogResponseModel.ResponseCode = APIResponseCode.NoDataFound;
                        DeleteBlogResponseModel.ResponseMessage = APIResponseMessage.NoDataFound;
                        DeleteBlogResponseModel.BlogId = BlogModel.BlogId;
                        DeleteBlogResponseModel.Title = BlogModel.Title;
                        DeleteBlogResponseModel.Content = BlogModel.Content;
                    }
                    else
                    {
                        DeleteBlogResponseModel.ResponseCode = APIResponseCode.DataDeletedSuccessFully;
                        DeleteBlogResponseModel.ResponseMessage = APIResponseMessage.DataDeletedSuccessFully;
                        DeleteBlogResponseModel.BlogId = BlogModel.BlogId;
                        DeleteBlogResponseModel.Title = BlogModel.Title;
                        DeleteBlogResponseModel.Content = BlogModel.Content;
                    }
                    return Ok(new HttpResponseDetails<DeleteBlogResponseModel>()
                    {
                        APIResponseCode = APIResponseCode.Success,
                        APIResponseMessage = APIResponseMessage.Success,
                        Response = DeleteBlogResponseModel
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok(new HttpResponseDetails<DeleteBlogResponseModel>()
                {
                    APIResponseCode = APIResponseCode.ExceptionGenerated,
                    APIResponseMessage = APIResponseMessage.ExceptionGenerated,
                    Response = DeleteBlogResponseModel
                });

            }
        }
    }
}
