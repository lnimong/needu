namespace WebAppNeedU.Deal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Data;
    using Entities;

    public class RepositoryEvent
    {
        private Needuapp_BDEntities bd = new Needuapp_BDEntities();

        public void Insert(EntityEvent entityEvent)
        {
            bd.Event_Insert(entityEvent.IdUser, entityEvent.Title, entityEvent.Description, entityEvent.DateStart, entityEvent.DateEnd, entityEvent.Address, Convert.ToDecimal(entityEvent.Latitude), Convert.ToDecimal(entityEvent.Longitude));
        }

        public void Delete(Int64 idEvent)
        {
            bd.Event_Update(idEvent);
        }

        public List<EntityEvent> SelectEvents(Int64 idUser)
        {
            List<EntityEvent> lista = new List<EntityEvent>();
            var resultado = bd.Event_Select(idUser);

            lista = (from item in resultado
                     select new EntityEvent
                     {
                         IdEvent = item.idEvent,
                         NickName = item.nickName,
                         Title = item.title,
                         Description = item.description,
                         DateStart = item.dateStart,
                         DateEnd = item.dateEnd,
                         Address = item.placeAddress,
                         IdUser = idUser,
                         Latitude = Convert.ToDouble(item.placeGeolocalizeLatitude),
                         Longitude = Convert.ToDouble(item.placeGeolocalizeLongitude)                        
                     }).ToList();

            return lista;
        }

        public List<EntityEvent> EventsByKm(Int16 km, double latitudeUser, double logitudeUser)
        {
            List<EntityEvent> lista = new List<EntityEvent>();
            var resultado = bd.EventByKm_Select((decimal)latitudeUser, (decimal)logitudeUser, km);

            lista = (from item in resultado
                     select new EntityEvent
                     {
                         IdEvent = item.idEvent,
                         NickName = item.nickName,
                         Title = item.title,
                         Description = item.description,
                         DateStart = item.dateStart,
                         DateEnd = item.dateEnd,
                         Address = item.placeAddress,
                         Latitude = Convert.ToDouble(item.placeGeolocalizeLatitude),
                         Longitude = Convert.ToDouble(item.placeGeolocalizeLongitude),
                         Km = item.Km
                     }).ToList();

            return lista;
        }

        public EntityEvent Select(Int64 idEvent)
        {
            EntityEvent entityEvent;
            var resultado = bd.EventById_Select(idEvent).FirstOrDefault();
            entityEvent = new EntityEvent()
            {
                IdEvent = resultado.idEvent,
                IdUser = resultado.idUser,
                NickName = resultado.nickName,
                Title = resultado.title,
                Description = resultado.description,
                DateStart = resultado.dateStart,
                DateEnd = resultado.dateEnd,
                Address = resultado.placeAddress,
                Latitude = Convert.ToDouble(resultado.placeGeolocalizeLatitude),
                Longitude = Convert.ToDouble(resultado.placeGeolocalizeLongitude)
            };
        
            return entityEvent;
        }

        public void InsertEventLike(EntityEventLike eventLike)
        {
            bd.EventLike_Insert(eventLike.IdEvent, eventLike.IdUser, eventLike.Like);
        }

        public EntityEventLike SelectEventLike(Int64 idEvent)
        {
            EntityEventLike eventLike;
            var resultado = bd.EventLike_Select(idEvent).FirstOrDefault();
            eventLike = new EntityEventLike()
            {
                IdEvent = resultado.idEvent,
                NumberOfLike = resultado.NumOfLike,
                NumberOfDisLike = resultado.NumOfDisLike
            };

            return eventLike;
        }

        public EntityEventLike EventLikeByUser(Int64 idEvent, Int64 idUser)
        {
            EntityEventLike eventLike = null;
            var resultado = bd.EventLikeByUser_Select(idEvent, idUser).FirstOrDefault();

            if (resultado != null)
            {
                eventLike = new EntityEventLike()
                {
                    IdEvent = idEvent,
                    IdUser = idUser,
                    Like = resultado.Value
                };
            }

            return eventLike;
        }
    }
}
