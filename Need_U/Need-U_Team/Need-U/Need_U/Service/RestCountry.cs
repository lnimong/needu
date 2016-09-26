namespace Need_U.Service
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Entities;

    public class RestCountry
    {
        public async Task<List<EntityCountry>> Select()
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Country/Select");
            List<EntityCountry> list = JsonConvert.DeserializeObject<List<EntityCountry>>(result);

            return list;
        }
    }
}
