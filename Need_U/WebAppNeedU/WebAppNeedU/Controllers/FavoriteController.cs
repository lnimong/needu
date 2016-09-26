namespace WebAppNeedU.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using Deal;
    using WebAppNeedU.Deal.Entities;

    public class FavoriteController : ApiController
    {
        [HttpGet]
        public string FavoriteQuestionInsert(Int64 idQuestion, Int64 idUser)
        {
            string mensaje = "ok";

            try
            {
                new RepositoryFavorite().FavoriteQuestionInsert(idQuestion, idUser);
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }

            return mensaje;
        }

        [HttpGet]
        public string FavoriteQuestionDelete(Int64 idQuestion, Int64 idUser)
        {
            string mensaje = "ok";

            try
            {
                new RepositoryFavorite().FavoriteQuestionDelete(idQuestion, idUser);
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }

            return mensaje;
        }

        [HttpGet]
        public List<EntityQuestion> FavoriteQuestionSelect(Int64 idUser)
        {
            List<EntityQuestion> salida = null;

            try
            {
                salida = new RepositoryFavorite().FavoriteQuestionSelect(idUser);
            }
            catch (Exception ex)
            {

                salida = null;
            }

            return salida;
        }

        [HttpGet]
        public string FavoriteEventInsert(Int64 idEvent, Int64 idUser)
        {
            string mensaje = "ok";

            try
            {
                new RepositoryFavorite().FavoriteEventInsert(idEvent, idUser);
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }

            return mensaje;
        }

        [HttpGet]
        public string FavoriteEventDelete(Int64 idEvent, Int64 idUser)
        {
            string mensaje = "ok";

            try
            {
                new RepositoryFavorite().FavoriteEventDelete(idEvent, idUser);
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }

            return mensaje;
        }

        [HttpGet]
        public List<EntityEvent> FavoriteEventSelect(Int64 idUser)
        {
            List<EntityEvent> salida = null;

            try
            {
                salida = new RepositoryFavorite().FavoriteEventSelect(idUser);
            }
            catch (Exception ex)
            {

                salida = null;
            }

            return salida;
        }
    }
}
