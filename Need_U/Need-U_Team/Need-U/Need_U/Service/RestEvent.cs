namespace Need_U.Service
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Entities;
    using System.Globalization;

    public class RestEvent
    {
        public async Task<string> Insert(EntityEvent entityEvent)
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(entityEvent), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(@"http://api.need-u-app.com/api/Event/Insert", content);

            return await result.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(Int64 idEvent)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Event/Delete?idEvent=" + idEvent.ToString());
            return result;
        }

        public async Task<EntityEvent> SelectEventById(Int64 idEvent)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Event/Select?idEvent=" + idEvent.ToString());
            return JsonConvert.DeserializeObject<EntityEvent>(result);
        }

        public async Task<List<EntityEvent>> SelectEvents(Int64 idUser)
        {
            var client = new HttpClient();
            string parameters = string.Format("?idUser={0}", idUser.ToString());
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Event/SelectEvents" + parameters);
            List<EntityEvent> list = JsonConvert.DeserializeObject<List<EntityEvent>>(result);

            return list;
        }

        public async Task<string> InsertEventLike(EntityEventLike eventLike)
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(eventLike), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(@"http://api.need-u-app.com/api/Event/InsertEventLike", content);

            return await result.Content.ReadAsStringAsync();
        }

        public async Task<EntityEventLike> SelectEventLike(Int64 idEvent)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Event/SelectEventLike?idEvent=" + idEvent.ToString());
            return JsonConvert.DeserializeObject<EntityEventLike>(result);
        }

        public async Task<List<EntityEvent>> EventsByKm(Int16 km, double latitudeUser, double logitudeUser)
        {
            var client = new HttpClient();
            string parameters = string.Format("?km={0}&latitudeUser={1}&logitudeUser={2}", km.ToString(), latitudeUser.ToString(new CultureInfo("en-US")), logitudeUser.ToString(new CultureInfo("en-US")));
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Event/EventsByKm" + parameters);
            List<EntityEvent> list = JsonConvert.DeserializeObject<List<EntityEvent>>(result);

            return list;
        }


        public async Task<EntityEventLike> EventLikeByUser(Int64 idEvent, Int64 idUser)
        {
            var client = new HttpClient();
            string parameters = string.Format("?idEvent={0}&idUser={1}", idEvent.ToString(), idUser.ToString());
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/Event/EventLikeByUser" + parameters);
            return JsonConvert.DeserializeObject<EntityEventLike>(result);
        }
    }
}
