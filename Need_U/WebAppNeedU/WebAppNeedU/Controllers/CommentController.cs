namespace WebAppNeedU.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using WebAppNeedU.Deal;
    using WebAppNeedU.Deal.Entities;

    public class CommentController : ApiController
    {
        [HttpPost]
        public string InsertCommentQuestion(EntityCommentQuestion comment)
        {
            string mensaje = "ok";

            try
            {
                new RepositoryComment().InsertCommentQuestion(comment);
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }

            return mensaje;
        }

        [HttpGet]
        public List<EntityCommentQuestion> SelectCommentsQuestion(Int64 idQuestion)
        {
            List<EntityCommentQuestion> lista = null;

            try
            {
                lista = new RepositoryComment().SelectCommentsQuestion(idQuestion);
            }
            catch (Exception ex)
            {

                lista = null;
            }

            return lista;
        }

        [HttpPost]
        public string InsertCommentEvent(EntityCommentEvent comment)
        {
            string mensaje = "ok";

            try
            {
                new RepositoryComment().InsertCommentEvent(comment);
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }

            return mensaje;
        }

        [HttpGet]
        public List<EntityCommentEvent> SelectCommentsEvent(Int64 idEvent)
        {
            List<EntityCommentEvent> lista = null;

            try
            {
                lista = new RepositoryComment().SelectCommentsEvent(idEvent);
            }
            catch (Exception ex)
            {

                lista = null;
            }

            return lista;
        }
    }
}
