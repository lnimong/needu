namespace Need_U.Service
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Entities;

    public class RestResponse
    {
        public async Task<string> Insert(EntityResponse response)
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(@"http://api.need-u-app.com/api/Response/Insert", content);

            return await result.Content.ReadAsStringAsync();
        }

        public async Task<List<EntityResponse>> Select(Int64 idQuestion)
        {
            var client = new HttpClient();
            string parameters = string.Format("?idQuestion={0}", idQuestion.ToString());
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Response/Select" + parameters);
            List<EntityResponse> list = JsonConvert.DeserializeObject<List<EntityResponse>>(result);

            return list;
        }


        public async Task<EntityResponse> ResponseByUser(Int64 idQuestion, Int64 idUser)
        {
            var client = new HttpClient();
            string parameter = string.Format("?IdQuestion={0}&idUser={1}", idQuestion.ToString(), idUser.ToString());
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Response/ResponseByUser" + parameter);
            EntityResponse reponse = JsonConvert.DeserializeObject<EntityResponse>(result);

            return reponse;

        }


    }
}
