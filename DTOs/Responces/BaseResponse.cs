using System.Net;

namespace DemoAPI.DTOs.Responces
{
    public class BaseResponse
    {
        public int status_code { get; set; } // to return the status code of the response
        public object data { get; set; } // to retun data associated with the response


        /// <summary>
        ///    This method can be used to generate the response object from the classes which are inherited from the BaseResponse class
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        public void CreateResponse(HttpStatusCode statusCode, Object data)
        {
            status_code = (int)statusCode;
            this.data = data;
        }
    }
}
