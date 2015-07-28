using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace test.webapi.Controllers
{
    public class DataController : ApiController
    {
        private int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

        public IEnumerable<int> GetAllData()
        {
            return data;
        }
    }
}
