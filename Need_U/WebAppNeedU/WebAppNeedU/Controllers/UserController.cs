namespace WebAppNeedU.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Web.Http;
    using Deal;
    using Deal.Entities;
    using Newtonsoft.Json.Linq;

    public class UserController : ApiController
    {
        [HttpPost]
        public string Insert(EntityUser user)
        {
            string mensaje = "ok";

            try
            {
                new RepositoryUser().Insert(user);
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }

            return mensaje;
        }

        [HttpPost]
        public string Update(EntityUser user)
        {
            string mensaje = "ok";

            try
            {
                new RepositoryUser().Update(user);
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }

            return mensaje;
        }

        [HttpGet]
        public string UpdateConexion(Int64 idUser)
        {
            string mensaje = "ok";

            try
            {
                new RepositoryUser().UpdateConexion(idUser);
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }

            return mensaje;
        }

        [HttpGet]
        public EntityUser Select(string email)
        {
            EntityUser user = null;

            try
            {
                user = new RepositoryUser().Select(email);
            }
            catch (Exception ex)
            {
            }

            return user;
        }

        [HttpGet]
        public bool ValidateExistence(string email)
        {
            bool userExist = false;

            try
            {
                EntityUser user = null;
                user = new RepositoryUser().Select(email);

                if (user != null)
                {
                    userExist = true;
                }
            }
            catch (Exception ex)
            {
            }

            return userExist;
        }
    }
}
