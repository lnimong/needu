namespace WebAppNeedU.Deal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Data;
    using Entities;

    public class RepositoryResponse
    {
        private Needuapp_BDEntities bd = new Needuapp_BDEntities();

        public void Insert(EntityResponse response)
        {
            bd.Response_Insert(response.IdOptionQuestion, response.IdUser);
        }

        public EntityResponse ResponseByUser(Int64 idQuestion, Int64 idUser)
        {
            EntityResponse response = null;
            var resultado = bd.ResponseByUser_Select(idQuestion, idUser);
            if (resultado !=null)
            {
                response = new EntityResponse();
                response.IdUser = idUser;
                response.IdOptionQuestion = resultado.First().Value;
            }

           return response;
        }

        public List<EntityResponse> ResponseSelect(Int64 idQuestion)
        {
            List<EntityResponse> entitieResponse = new List<EntityResponse>();
            var resultado = bd.Response_Select(idQuestion).ToList();
            entitieResponse = (from item in resultado

                               select new EntityResponse
                               {
                                   IdOptionQuestion = item.idOptionQuestion,
                                   Percentage = item.percentage
                               }).ToList();

            return entitieResponse;
        }
    }
}
