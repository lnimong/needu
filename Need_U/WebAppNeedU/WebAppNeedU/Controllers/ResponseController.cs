namespace WebAppNeedU.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using WebAppNeedU.Deal;
    using WebAppNeedU.Deal.Entities;

    public class ResponseController : ApiController
    {
        [HttpGet]
        public List<EntityResponse> Select(Int64 idQuestion)
        {
            List<EntityResponse> salida = null;

            try
            {
                salida = new RepositoryResponse().ResponseSelect(idQuestion);
            }
            catch (Exception ex)
            {

                salida = null;
            }

            return salida;
        }

        [HttpPost]
        public string Insert(EntityResponse response)
        {
            string mensaje = "ok";

            try
            {
                new RepositoryResponse().Insert(response);
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }

            return mensaje;
        }

        [HttpGet]
        public EntityResponse ResponseByUser(Int64 idQuestion, Int64 idUser)
        {
           EntityResponse salida = null;

            try
            {
                salida = new RepositoryResponse().ResponseByUser(idQuestion, idUser);
            }
            catch (Exception ex)
            {

                salida = null;
            }

            return salida;
        }
    }
}