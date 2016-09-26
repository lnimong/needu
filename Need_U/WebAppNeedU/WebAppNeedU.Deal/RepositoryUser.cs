namespace WebAppNeedU.Deal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Data;
    using Entities;

    public class RepositoryUser
    {
        private Needuapp_BDEntities bd = new Needuapp_BDEntities();

        public void Insert(EntityUser user)
        {
            bd.User_Insert(user.FirstName, user.LastName, user.NickName, user.Birthday, user.Job, user.City, user.CodeCountry, user.Sex, user.Email, user.PhotoUrl);
        }

        public EntityUser Select(string email)
        {
            EntityUser entityUser;
            var resultado = bd.UserByEmail_Select(email).FirstOrDefault();
            entityUser = new EntityUser()
            {
                IdUser = resultado.idUser,
                FirstName = resultado.firstName,
                LastName = resultado.lastName,
                NickName = resultado.nickName,
                Birthday = resultado.birthday,
                Job = resultado.job,
                City = resultado.city,
                CodeCountry = resultado.codeCountry,
                NameCountry = resultado.nameCountry,
                Sex = resultado.sex,
                Email = resultado.email,
                ConexionNumber = resultado.conexionNumber,
                PhotoUrl = resultado.photoUrl
            };

            return entityUser;
        }

        public void UpdateConexion(Int64 idUser)
        {
            bd.UserConexiones_Update(idUser);
        }

        public void Update(EntityUser user)
        {
            bd.User_Update(user.FirstName, user.LastName, user.NickName, user.Birthday, user.Job, user.City, user.CodeCountry, user.Sex, user.PhotoUrl);
        }


    }
}
