namespace WebAppNeedU.Deal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WebAppNeedU.Deal.Data;
    using WebAppNeedU.Deal.Entities;

    public class RepositoryFavorite
    {
        private Needuapp_BDEntities bd = new Needuapp_BDEntities();

        public void FavoriteQuestionInsert(Int64 idQuestion, Int64 idUser)
        {
            bd.FavoriteQuestion_Insert(idQuestion, idUser);
        }

        public void FavoriteQuestionDelete(Int64 idQuestion, Int64 idUser)
        {
            bd.FavoriteQuestion_Delete(idQuestion, idUser);
        }

        public List<EntityQuestion> FavoriteQuestionSelect(Int64 idUser)
        {
            List<EntityQuestion> listaQuestion = new List<EntityQuestion>();
            var resultado = bd.FavoriteQuestion_Select(idUser).ToList();

            listaQuestion = (from item in resultado
                             select new EntityQuestion
                             {
                                 IdQuestion = item.idQuestion,
                                 Title = item.title,
                                 Description = item.description,
                                 Latitude = (double)item.latitude,
                                 Longitud = (double)item.longitude,
                                 IdUser = idUser,
                                 NickName = item.nickName,
                                 OptionsQuestion = MapearOptionsQuestion(item.idQuestion, item.image, item.textOption)
                             }).ToList();

            return listaQuestion;
        }

        public void FavoriteEventInsert(Int64 idEvent, Int64 idUser)
        {
            bd.FavoriteEvent_Insert(idEvent, idUser);
        }

        public void FavoriteEventDelete(Int64 idEvent, Int64 idUser)
        {
            bd.FavoriteEvent_Delete(idEvent, idUser);
        }

        public List<EntityEvent> FavoriteEventSelect(Int64 idUser)
        {
            List<EntityEvent> listaEntityEvent = new List<EntityEvent>();
            var resultado = bd.FavoriteEvent_Select(idUser).ToList();

            listaEntityEvent = (from item in resultado
                                select new EntityEvent
                                {
                                    IdUser = idUser,
                                    IdEvent = item.idEvent,
                                    NickName = item.nickName,
                                    Title  = item.title,
                                    Description = item.description,
                                    DateStart = item.dateStart,
                                    DateEnd = item.dateEnd,
                                    Address = item.placeAddress,
                                    Latitude = (double)item.placeGeolocalizeLatitude,
                                    Longitude = (double)item.placeGeolocalizeLongitude
                                }).ToList();

            return listaEntityEvent;
        }

        private List<EntityOptionQuestion> MapearOptionsQuestion(long idQuestion, byte[] image, string textOption)
        {
            List<EntityOptionQuestion> listaEntitieOptionQuestion = new List<EntityOptionQuestion>();
            EntityOptionQuestion entitieOptionQuestion = new EntityOptionQuestion();
            entitieOptionQuestion.IdQuestion = idQuestion;
            entitieOptionQuestion.Image = image;
            entitieOptionQuestion.TextOption = textOption;
            listaEntitieOptionQuestion.Add(entitieOptionQuestion);
            return listaEntitieOptionQuestion;
        }
    }
}
