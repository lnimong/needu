using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppNeedU.Deal;
using WebAppNeedU.Deal.Entities;

namespace WebAppNeedU.Controllers
{
    public class EventController : ApiController
    {
        [HttpPost]
        public string Insert(EntityEvent entityEvent)
        {
            string mensaje = "ok";

            try
            {
                new RepositoryEvent().Insert(entityEvent);
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }

            return mensaje;
        }

        [HttpGet]
        public EntityEvent Select(Int64 idEvent)
        {
            EntityEvent salida = null;

            try
            {
                salida = new RepositoryEvent().Select(idEvent);
            }
            catch (Exception ex)
            {

                salida = null;
            }

            return salida;
        }

        [HttpGet]
        public List<EntityEvent> SelectEvents(Int64 idUser)
        {
            List<EntityEvent> salida = null;

            try
            {
                salida = new RepositoryEvent().SelectEvents(idUser);
            }
            catch (Exception ex)
            {

                salida = null;
            }

            return salida;
        }

        [HttpGet]
        public List<EntityEvent> EventsByKm(Int16 km, double latitudeUser, double logitudeUser)
        {
            List<EntityEvent> salida = null;

            try
            {
                salida = new RepositoryEvent().EventsByKm(km, latitudeUser, logitudeUser);
            }
            catch (Exception ex)
            {

                salida = null;
            }

            return salida;
        }

        [HttpGet]
        public string Delete(Int64 IdEvent)
        {
            string message = "Ok";
            try
            {
                new RepositoryEvent().Delete(IdEvent);


            }
            catch (Exception e)
            {

                message = "Not Ok";
            }

            return message;
        }

        [HttpPost]
        public string InsertEventLike(EntityEventLike eventLike)
        {
            string mensaje = "ok";

            try
            {
                new RepositoryEvent().InsertEventLike(eventLike);
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }

            return mensaje;
        }

        [HttpGet]
        public EntityEventLike EventLikeByUser(Int64 idEvent, Int64 idUser)
        {
            EntityEventLike salida = null;

            try
            {
                salida = new RepositoryEvent().EventLikeByUser(idEvent, idUser);
            }
            catch (Exception ex)
            {

                salida = null;
            }

            return salida;
        }

        [HttpGet]
        public EntityEventLike SelectEventLike(Int64 idEvent)
        {
            EntityEventLike salida = null;

            try
            {
                salida = new RepositoryEvent().SelectEventLike(idEvent);
            }
            catch (Exception ex)
            {

                salida = null;
            }

            return salida;
        }


    }
}
