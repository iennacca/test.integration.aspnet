using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using test.integration.common.Models;

namespace test.webapi.service.Controllers
{
    public class DataController : ApiController
    {
        private int[] integerData = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        private CloudBaseDataDocument dataDocument = new CloudBaseDataDocument()
        {
            Bucket = "bucket",
            View = "view",
            DataValues = new List<TimeseriesValue>() 
            { 
                new TimeseriesValue() { ValueDate = DateTime.Parse("1/1/2015"), Value = 1.1F },
                new TimeseriesValue() { ValueDate = DateTime.Parse("2/1/2015"), Value = 2.2F } 
            }
        };

        public CloudBaseDataDocument GetAllData()
        {
            return dataDocument;
        }
    }
}
