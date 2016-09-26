namespace RestServices
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using WebAppNeedU.Deal.Entities;

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
            return JsonConvert.DeserializeObject<EntityQuestion>(result);
        }

        public async Task<List<EntityQuestion>> QuestionsByCountry(Int64 idUser, double latitudeUser, double logitudeUser)
        {
            //Falta... concatenarlo los otros parametros. 
            var client = new HttpClient();
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Question/QuestionsByCountry?idUser=" + idUser.ToString());
            return (List<EntityQuestion>)JsonConvert.DeserializeObject(result);
        }
    }
}
