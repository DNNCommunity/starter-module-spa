using System.Web.Http;
using System.Net;
using System.Net.Http;
using DotNetNuke.Web.Api;
using DotNetNuke.Services.Exceptions;

namespace starter_module_spa.Services
{
    public class MyController : ControllerBase
    {
        #region "API Endpoints"
        [DnnAuthorize()]
        [HttpGet()]
        public HttpResponseMessage DnnHello()
        {
            try
            {
                string dnnHello = "Hello from DNN!";
                return Request.CreateResponse(HttpStatusCode.OK, dnnHello);
            }
            catch (System.Exception ex)
            {
                //Log exception and reply with Error
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [DnnAuthorize()]
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public HttpResponseMessage DnnHelloPersonalize(DetailsDTO data)
        {
            try
            {
                string dnnMessage = "Hello " + data.name + " from DNN!";
                return Request.CreateResponse(HttpStatusCode.OK, dnnMessage);
            }
            catch (System.Exception ex)
            {
                //Log exception and reply with Error
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

        #region "DTO Classes"
        public class DetailsDTO
        {
            public string name { get; set; }
        }
        #endregion
    }
}