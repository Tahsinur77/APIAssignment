using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIAssignment.Controllers
{
    public class StudentController : ApiController
    {
        [Route("api/Create/Student")]
        public HttpResponseMessage Create()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Created");
        }
    }
}
