using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Attribute;
using Web.Common;

namespace Web.Controllers
{
    /// <summary>
    /// 控制器注释
    /// </summary>
    public class ValuesController : BaseApiController
    {
        /// <summary>
        /// 这是接口说明
        /// </summary>
        /// <returns></returns>
        [ApiCustomAuthorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
