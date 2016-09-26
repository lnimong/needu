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

    public class QuestionController : ApiController
    {
        [HttpPost]
        public string Insert(EntityQuestion question)
        {
            string mensaje = "ok";

            try
            {
                new RepositoryQuestion().Insert(question);
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }

            return mensaje;
        }
            
        [HttpGet]
        public EntityQuestion QuestionById(Int64 idQuestion)
        {
            EntityQuestion salida = null;

            try
            {
                salida = new RepositoryQuestion().QuestionById(idQuestion);
            }
            catch (Exception ex)
            {

                salida = null;
            }

            return salida;
        }

        [HttpGet]
        public List<EntityQuestion> QuestionsByCountry(Int64 idUser)
        {
            List<EntityQuestion> salida = null;

            try
            {
                salida = new RepositoryQuestion().QuestionsByCountry(idUser);
            }
            catch (Exception ex)
            {

                salida = null;
            }

            return salida;
        }

        [HttpGet]
        public List<EntityQuestion> QuestionSelect(Int64 idUser)
        {
            List<EntityQuestion> salida = null;

            try
            {
                salida = new RepositoryQuestion().QuestionSelect(idUser);
            }
            catch (Exception ex)
            {

                salida = null;
            }

            return salida;
        }

        [HttpGet]
        public List<EntityQuestion> QuestionByKmSelect(Int16 km, double latitudeUser, double logitudeUser)
        {
            List<EntityQuestion> salida = null;

            try
            {
                salida = new RepositoryQuestion().QuestionByKmSelect(km, latitudeUser, logitudeUser);
            }
            catch (Exception ex)
            {

                salida = null;
            }

            return salida;
        }

        [HttpGet]
        public string Delete(Int64 IdQuestion)
        {
            string message = "Ok";
            try
            {
                new RepositoryQuestion().Delete(IdQuestion);
                

            }
            catch (Exception e)
            {

                message = "Not Ok";
            }

            return message;
        }
    }
}
