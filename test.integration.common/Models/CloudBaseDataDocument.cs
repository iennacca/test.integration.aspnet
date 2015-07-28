using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.integration.common.Models
{
    public class TimeseriesValue
    {
        public DateTime ValueDate;
        public float Value;
    }
    public class CloudBaseDataDocument
    {
        public string Bucket;
        public string View;
        public IEnumerable<TimeseriesValue> DataValues;
    }
}
