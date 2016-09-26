using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Need_U.Entities;
using Newtonsoft.Json;

namespace Need_U.Service
{
    public class RestUser
    {
        public async Task<string> Insert(EntityUser user)
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(@"http://api.need-u-app.com/api/User/Insert", content);
            return await result.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(EntityUser user)
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(@"http://api.need-u-app.com/api/User/Update", content);
            return await result.Content.ReadAsStringAsync();
        }

        public async Task<string> UpdateConexion(Int64 idUser)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/User/UpdateConexion?idUser=" + idUser.ToString());
            return result;
        }

        public async Task<EntityUser> Select(string email)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/User/Select?email=" + email);
            EntityUser theUser = JsonConvert.DeserializeObject<EntityUser>(result);
            return theUser;
        }

        public async Task<bool> ValidateExistence(string email)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync(@"http://api.need-u-app.com/api/User/ValidateExistence?email=" + email);
            bool existe = JsonConvert.DeserializeObject<bool>(result);
            return existe;
        }
    }
}

