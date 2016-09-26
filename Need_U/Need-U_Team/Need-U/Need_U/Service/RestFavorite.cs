namespace Need_U.Service
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Entities;

    public class RestFavorite
    {
        public async Task<string> FavoriteQuestionInsert(Int64 idQuestion, Int64 idUser)
        {
            var client = new HttpClient();

            string parameters = string.Format("?idQuestion={0}&idUser={1}", idQuestion.ToString(), idUser.ToString());
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Favorite/FavoriteQuestionInsert" + parameters);
            return result;
        }

        public async Task<string> FavoriteQuestionDelete(Int64 idQuestion, Int64 idUser)
        {
            var client = new HttpClient();

            string parameters = string.Format("?idQuestion={0}&idUser={1}", idQuestion.ToString(), idUser.ToString());
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Favorite/FavoriteQuestionDelete" + parameters);
            return result;
        }

        public async Task<List<EntityQuestion>> FavoriteQuestionSelect(Int64 idUser)
        {
            var client = new HttpClient();

            string parameters = string.Format("?idUser={0}", idUser.ToString());
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Favorite/FavoriteQuestionSelect" + parameters);
            List<EntityQuestion> list = JsonConvert.DeserializeObject<List<EntityQuestion>>(result);

            return list;
        }

        public async Task<string> FavoriteEventInsert(Int64 idEvent, Int64 idUser)
        {
            var client = new HttpClient();

            string parameters = string.Format("?idEvent={0}&idUser={1}", idEvent.ToString(), idUser.ToString());
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Favorite/FavoriteEventInsert" + parameters);
            return result;
        }

        public async Task<string> FavoriteEventDelete(Int64 idEvent, Int64 idUser)
        {
            var client = new HttpClient();

            string parameters = string.Format("?idEvent={0}&idUser={1}", idEvent.ToString(), idUser.ToString());
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Favorite/FavoriteEventDelete" + parameters);
            return result;
        }

        public async Task<List<EntityEvent>> FavoriteEventSelect(Int64 idUser)
        {
            var client = new HttpClient();

            string parameters = string.Format("?idUser={0}", idUser.ToString());
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Favorite/FavoriteEventSelect" + parameters);
            List<EntityEvent> list = JsonConvert.DeserializeObject<List<EntityEvent>>(result);

            return list;
        }
    }
}
