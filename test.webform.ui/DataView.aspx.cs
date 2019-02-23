using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Http;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

using test.integration.common.Models;
using test.integration.common.WebApi;
using test.webform.ui.Utilities;

namespace test.webform.ui
{
    public partial class DataView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GetData();
            RegisterAsyncTask(new PageAsyncTask(GetDataAsync));
        }

        public void GetData()
        {
            var client = new RestClient(@"http://localhost:2181/api/data", "application/json");
            var ts = client.RunRequest();
            BindData(ts);
        }

        public async Task GetDataAsync()
        {
            var ts = await AsyncRestClient.RunRequest(@"http://localhost:2181/api/data", "application/json", HttpVerb.GET);
            BindData(ts);
        }

        private void BindData(string jsonData)
        {
            var js = new JavaScriptSerializer();
            var tsa = js.Deserialize<CloudBaseDataDocument>(jsonData);

            bucketText.Text = tsa.Bucket;
            viewText.Text = tsa.View;
            foreach (var value in tsa.DataValues)
                timeseriesDataList.Items.Add(new ListItem(String.Format("{0}: {1}", value.ValueDate, value.Value)));
        }
    }
}