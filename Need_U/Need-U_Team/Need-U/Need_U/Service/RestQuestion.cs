namespace Need_U.Service
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Entities;
    using Newtonsoft.Json.Linq;
    using System.Linq;
    using System.Globalization;

    public class RestQuestion
    {
        public async Task<string> Insert(EntityQuestion question)
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(question), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(@"http://api.need-u-app.com/api/Question/Insert", content);

            return await result.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(Int64 idQuestion)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Question/Delete?idQuestion=" + idQuestion.ToString());
            return result;
        }

        public async Task<EntityQuestion> QuestionById(Int64 idQuestion)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Question/QuestionById?idQuestion=" + idQuestion.ToString());
            EntityQuestion theQuestion = JsonConvert.DeserializeObject<EntityQuestion>(result);

            return theQuestion;
        }

        public async Task<List<EntityQuestion>> QuestionsByCountry(Int64 idUser)
        {
            var client = new HttpClient();
            string parameters = string.Format("?idUser={0}", idUser.ToString());
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Question/QuestionsByCountry" + parameters);
            List<EntityQuestion> list = JsonConvert.DeserializeObject<List<EntityQuestion>>(result);

            return list;
        }

        public async Task<List<EntityQuestion>> QuestionsByUser(Int64 idUser)
        {
            var client = new HttpClient();
            string parameters = string.Format("?idUser={0}", idUser.ToString());
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Question/QuestionSelect" + parameters);
            List<EntityQuestion> list = JsonConvert.DeserializeObject<List<EntityQuestion>>(result);

            return list;
        }


        public async Task<List<EntityQuestion>> ByKmSelect(Int16 km, double latitudeUser, double logitudeUser)
        {
            var client = new HttpClient();
            string parameter = string.Format("?km={0}&latitudeUser={1}&logitudeUser={2}", km.ToString(), latitudeUser.ToString(new CultureInfo("en-US")), logitudeUser.ToString(new CultureInfo("en-US")));
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Question/QuestionByKmSelect" + parameter);
            List<EntityQuestion> list = JsonConvert.DeserializeObject<List<EntityQuestion>>(result);

            return list;
        }

    }
}
