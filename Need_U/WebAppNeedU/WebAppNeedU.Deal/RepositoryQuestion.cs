namespace WebAppNeedU.Deal
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using Data;
    using Entities;

    public class RepositoryQuestion
    {
        private Needuapp_BDEntities bd = new Needuapp_BDEntities();

        public void Insert(EntityQuestion question)
        {
            long? idQuestion = bd.Question_Insert(question.IdUser, question.Title, question.Description, (decimal)question.Latitude, (decimal)question.Longitud).FirstOrDefault();
                       
            foreach (EntityOptionQuestion item in question.OptionsQuestion)
            {
                bd.OptionQuestion_Insert(idQuestion, item.Image, item.TextOption);
            }
        }

        public EntityQuestion QuestionById(Int64 idQuestion)
        {
            EntityQuestion question = new EntityQuestion();
            var resultado = bd.QuestionById_Select(idQuestion).ToList();
            question.IdQuestion = idQuestion;
            question.Title = resultado.First().title;
            question.Description = resultado.First().description;
            question.Latitude = (double)resultado.First().latitude;
            question.Longitud = (double)resultado.First().longitude;
            question.IdUser = resultado.First().idUser;
            question.NickName = resultado.First().nickName;

            question.OptionsQuestion = (from item in resultado
                                        select new EntityOptionQuestion
                                        {
                                            IdOptionQuestion = item.idOptionQuestion,
                                            TextOption = item.textOption,
                                            Image = item.image
                                        }).ToList();
            return question;
        }

        public List<EntityQuestion> QuestionsByCountry(Int64 idUser)
        {
            List<EntityQuestion> question = new List<EntityQuestion>();
            var resultado = bd.QuestionByCountry_Select(idUser).ToList();
            
            question = (from item in resultado
                        select new EntityQuestion
                        {
                            IdQuestion = item.idQuestion,
                            Title = item.title,
                            Description = item.description,
                            Latitude = (double)item.latitude,
                            Longitud = (double)item.longitude,
                            NickName = item.nickName,                                                     
                            OptionsQuestion = MapearOptionsQuestion(item.idQuestion, item.image, item.textOption),
                        }).ToList();

            return question;
        }

        public List<EntityQuestion> QuestionByKmSelect(Int16 km, double latitudeUser, double logitudeUser)
        {
            List<EntityQuestion> listaQuestion = new List<EntityQuestion>();
            var resultado = bd.QuestionBykm_Select((decimal)latitudeUser, (decimal)logitudeUser, km).ToList();

            listaQuestion = (from item in resultado
                             select new EntityQuestion
                             {
                                 IdQuestion = item.idQuestion,
                                 Title = item.title,
                                 Latitude = (double)item.latitude,
                                 Longitud = (double)item.longitude,
                                 NickName = item.nickName,
                                 OptionsQuestion = MapearOptionsQuestion(item.idQuestion, item.image, item.textOption),
                                 Km = item.Km
                             }).ToList();

            return listaQuestion;
        }

        public List<EntityQuestion> QuestionSelect(Int64 idUser)
        {
            List<EntityQuestion> listaQuestion = new List<EntityQuestion>();
            var resultado = bd.Question_Select(idUser).ToList();

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
                                 OptionsQuestion = MapearOptionsQuestion(item.idQuestion, item.image, item.textOption),                              
                             }).ToList();          

            return listaQuestion;
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

        public void Delete(Int64 IdQuestion )
        {
            bd.Question_Update(IdQuestion);
        }

        public void FavoritInsert(Int64 IdQuestion, Int64 IdUser)
        {
            bd.FavoriteQuestion_Insert(IdQuestion, IdUser);
        }

        
    }
}
