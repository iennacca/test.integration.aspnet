using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Http;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
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
            var ts = client.MakeRequest();
            var jss = new JavaScriptSerializer();
            var tsa = jss.Deserialize<int[]>(ts);

            foreach (var value in tsa)
                ListBox1.Items.Add(new ListItem(Convert.ToString(value)));
        }

        public async Task GetDataAsync()
        {
            var ts = await AsyncRestClient.RunAsync(@"http://localhost:2181/api/data", "application/json");
            var js = new JavaScriptSerializer();
            var tsa = js.Deserialize<int[]>(ts);

            foreach (var value in tsa)
                ListBox1.Items.Add(new ListItem(Convert.ToString(value)));
        }
    }
}