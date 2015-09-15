using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Promocje_Web.Services;

namespace Promocje_Web.Controllers.Api
{
    public class TempFileController : ApiController
    {
        // GET: api/TempFile
      /*  public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET: api/TempFile/5
      /*  public string Get(int id)
        {
            return "value";
        }*/

        // POST: api/TempFile
        [HttpPost]
        public IHttpActionResult Post()
        {
            List<string> fileNames = new List<string>();
             
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {                    
                    var postedFile = httpRequest.Files[file];
                    string uniqueName = System.IO.Path.GetRandomFileName() + postedFile.FileName;
                    var filePath = Path.Combine(ServerTools.TempFolderPath, uniqueName);
                    postedFile.SaveAs(filePath);
                    fileNames.Add(uniqueName);
                    // NOTE: To store in memory use postedFile.InputStream
                }
                
            }

            return Ok(fileNames);
        }

        // PUT: api/TempFile/5
      /*  public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TempFile/5
        public void Delete(int id)
        {
        }*/
    }
}
