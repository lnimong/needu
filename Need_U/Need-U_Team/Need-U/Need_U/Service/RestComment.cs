namespace Need_U.Service
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Entities;

    public class RestComment
    {
        public async Task<string> InsertCommentQuestion(EntityCommentQuestion comment)
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(@"http://api.need-u-app.com/api/Comment/InsertCommentQuestion", content);

            return await result.Content.ReadAsStringAsync();
        }

        public async Task<List<EntityCommentQuestion>> SelectCommentsQuestion(Int64 idQuestion)
        {
            var client = new HttpClient();
            string parameters = string.Format("?idQuestion={0}", idQuestion.ToString());
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Comment/SelectCommentsQuestion" + parameters);
            List<EntityCommentQuestion> list = JsonConvert.DeserializeObject<List<EntityCommentQuestion>>(result);

            return list;
        }

        public async Task<string> InsertCommentEvent(EntityCommentEvent comment)
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(@"http://api.need-u-app.com/api/Comment/InsertCommentEvent", content);

            return await result.Content.ReadAsStringAsync();
        }

        public async Task<List<EntityCommentEvent>> SelectCommentsEvent(Int64 idEvent)
        {
            var client = new HttpClient();
            string parameters = string.Format("?idEvent={0}", idEvent.ToString());
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Comment/SelectCommentsEvent" + parameters);
            List<EntityCommentEvent> list = JsonConvert.DeserializeObject<List<EntityCommentEvent>>(result);

            return list;
        }




    }
}
