using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Promocje_Web.Controllers.Api
{
    public class TempFileController : ApiController
    {
        // GET: api/TempFile
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TempFile/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TempFile
        public void Post([FromBody]string value)
        {
            HttpRequestMessage request = this.Request;
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/uploads");
            var provider = new MultipartFormDataStreamProvider(root);

            var task = request.Content.ReadAsMultipartAsync(provider).
                ContinueWith<HttpResponseMessage>(o =>
                {

                    string file1 = provider.BodyPartFileNames.First().Value;
                    // this is the file name on the server where the file was saved 

                    return new HttpResponseMessage()
                    {
                        Content = new StringContent("File uploaded.")
                    };
                }
            ); 
        }

        // PUT: api/TempFile/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TempFile/5
        public void Delete(int id)
        {
        }
    }
}
