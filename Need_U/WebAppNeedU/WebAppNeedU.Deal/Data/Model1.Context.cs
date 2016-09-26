﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppNeedU.Deal.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Needuapp_BDEntities : DbContext
    {
        public Needuapp_BDEntities()
            : base("name=Needuapp_BDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventLike> EventLike { get; set; }
        public virtual DbSet<OptionQuestion> OptionQuestion { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Response> Response { get; set; }
        public virtual DbSet<CommentsEvent> CommentsEvent { get; set; }
        public virtual DbSet<CommentsQuestion> CommentsQuestion { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
    
        public virtual int CommentsEvent_Insert(Nullable<long> idEvent, Nullable<long> idUser, string comment, Nullable<System.DateTime> date)
        {
            var idEventParameter = idEvent.HasValue ?
                new ObjectParameter("idEvent", idEvent) :
                new ObjectParameter("idEvent", typeof(long));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(long));
    
            var commentParameter = comment != null ?
                new ObjectParameter("comment", comment) :
                new ObjectParameter("comment", typeof(string));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CommentsEvent_Insert", idEventParameter, idUserParameter, commentParameter, dateParameter);
        }
    
        public virtual ObjectResult<CommentsEvent_Select_Result> CommentsEvent_Select(Nullable<long> idEvent)
        {
            var idEventParameter = idEvent.HasValue ?
                new ObjectParameter("idEvent", idEvent) :
                new ObjectParameter("idEvent", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CommentsEvent_Select_Result>("CommentsEvent_Select", idEventParameter);
        }
    
        public virtual int CommentsQuestion_Insert(Nullable<long> idQuestion, Nullable<long> idUser, string comment, Nullable<System.DateTime> date)
        {
            var idQuestionParameter = idQuestion.HasValue ?
                new ObjectParameter("idQuestion", idQuestion) :
                new ObjectParameter("idQuestion", typeof(long));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(long));
    
            var commentParameter = comment != null ?
                new ObjectParameter("comment", comment) :
                new ObjectParameter("comment", typeof(string));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CommentsQuestion_Insert", idQuestionParameter, idUserParameter, commentParameter, dateParameter);
        }
    
        public virtual ObjectResult<CommentsQuestion_Select_Result> CommentsQuestion_Select(Nullable<long> idQuestion)
        {
            var idQuestionParameter = idQuestion.HasValue ?
                new ObjectParameter("idQuestion", idQuestion) :
                new ObjectParameter("idQuestion", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CommentsQuestion_Select_Result>("CommentsQuestion_Select", idQuestionParameter);
        }
    
        public virtual int Event_Delete(Nullable<long> idEvent)
        {
            var idEventParameter = idEvent.HasValue ?
                new ObjectParameter("idEvent", idEvent) :
                new ObjectParameter("idEvent", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Event_Delete", idEventParameter);
        }
    
        public virtual int Event_Insert(Nullable<long> idUser, string title, string description, Nullable<System.DateTime> dateStart, Nullable<System.DateTime> dateEnd, string placeAddress, Nullable<decimal> placeGeolocalizeLatitude, Nullable<decimal> placeGeolocalizeLongitude)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(long));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var dateStartParameter = dateStart.HasValue ?
                new ObjectParameter("dateStart", dateStart) :
                new ObjectParameter("dateStart", typeof(System.DateTime));
    
            var dateEndParameter = dateEnd.HasValue ?
                new ObjectParameter("dateEnd", dateEnd) :
                new ObjectParameter("dateEnd", typeof(System.DateTime));
    
            var placeAddressParameter = placeAddress != null ?
                new ObjectParameter("placeAddress", placeAddress) :
                new ObjectParameter("placeAddress", typeof(string));
    
            var placeGeolocalizeLatitudeParameter = placeGeolocalizeLatitude.HasValue ?
                new ObjectParameter("placeGeolocalizeLatitude", placeGeolocalizeLatitude) :
                new ObjectParameter("placeGeolocalizeLatitude", typeof(decimal));
    
            var placeGeolocalizeLongitudeParameter = placeGeolocalizeLongitude.HasValue ?
                new ObjectParameter("placeGeolocalizeLongitude", placeGeolocalizeLongitude) :
                new ObjectParameter("placeGeolocalizeLongitude", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Event_Insert", idUserParameter, titleParameter, descriptionParameter, dateStartParameter, dateEndParameter, placeAddressParameter, placeGeolocalizeLatitudeParameter, placeGeolocalizeLongitudeParameter);
        }
    
        public virtual int EventLike_Insert(Nullable<long> idEvent, Nullable<long> idUser, Nullable<bool> like)
        {
            var idEventParameter = idEvent.HasValue ?
                new ObjectParameter("IdEvent", idEvent) :
                new ObjectParameter("IdEvent", typeof(long));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(long));
    
            var likeParameter = like.HasValue ?
                new ObjectParameter("like", like) :
                new ObjectParameter("like", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EventLike_Insert", idEventParameter, idUserParameter, likeParameter);
        }
    
        public virtual ObjectResult<EventLike_Select_Result> EventLike_Select(Nullable<long> idEvent)
        {
            var idEventParameter = idEvent.HasValue ?
                new ObjectParameter("idEvent", idEvent) :
                new ObjectParameter("idEvent", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EventLike_Select_Result>("EventLike_Select", idEventParameter);
        }
    
        public virtual int FavoriteQuestion_Delete(Nullable<long> idQuestion, Nullable<long> idUser)
        {
            var idQuestionParameter = idQuestion.HasValue ?
                new ObjectParameter("idQuestion", idQuestion) :
                new ObjectParameter("idQuestion", typeof(long));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FavoriteQuestion_Delete", idQuestionParameter, idUserParameter);
        }
    
        public virtual int FavoriteQuestion_Insert(Nullable<long> idQuestion, Nullable<long> idUser)
        {
            var idQuestionParameter = idQuestion.HasValue ?
                new ObjectParameter("idQuestion", idQuestion) :
                new ObjectParameter("idQuestion", typeof(long));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FavoriteQuestion_Insert", idQuestionParameter, idUserParameter);
        }
    
        public virtual int OptionQuestion_Insert(Nullable<long> idQuestion, byte[] image, string textOption)
        {
            var idQuestionParameter = idQuestion.HasValue ?
                new ObjectParameter("idQuestion", idQuestion) :
                new ObjectParameter("idQuestion", typeof(long));
    
            var imageParameter = image != null ?
                new ObjectParameter("image", image) :
                new ObjectParameter("image", typeof(byte[]));
    
            var textOptionParameter = textOption != null ?
                new ObjectParameter("textOption", textOption) :
                new ObjectParameter("textOption", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("OptionQuestion_Insert", idQuestionParameter, imageParameter, textOptionParameter);
        }
    
        public virtual int Question_Delete(Nullable<long> idQuestion)
        {
            var idQuestionParameter = idQuestion.HasValue ?
                new ObjectParameter("idQuestion", idQuestion) :
                new ObjectParameter("idQuestion", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Question_Delete", idQuestionParameter);
        }
    
        public virtual ObjectResult<Nullable<long>> Question_Insert(Nullable<long> idUser, string title, string description, Nullable<decimal> latitude, Nullable<decimal> longitude)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(long));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var latitudeParameter = latitude.HasValue ?
                new ObjectParameter("latitude", latitude) :
                new ObjectParameter("latitude", typeof(decimal));
    
            var longitudeParameter = longitude.HasValue ?
                new ObjectParameter("longitude", longitude) :
                new ObjectParameter("longitude", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("Question_Insert", idUserParameter, titleParameter, descriptionParameter, latitudeParameter, longitudeParameter);
        }
    
        public virtual ObjectResult<Question_Select_Result> Question_Select(Nullable<long> idUser)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Question_Select_Result>("Question_Select", idUserParameter);
        }
    
        public virtual ObjectResult<QuestionByCountry_Select_Result> QuestionByCountry_Select(Nullable<long> idUser)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<QuestionByCountry_Select_Result>("QuestionByCountry_Select", idUserParameter);
        }
    
        public virtual ObjectResult<QuestionById_Select_Result> QuestionById_Select(Nullable<long> idQuestion)
        {
            var idQuestionParameter = idQuestion.HasValue ?
                new ObjectParameter("idQuestion", idQuestion) :
                new ObjectParameter("idQuestion", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<QuestionById_Select_Result>("QuestionById_Select", idQuestionParameter);
        }
    
        public virtual int Response_Insert(Nullable<long> idOptionQuestion, Nullable<long> idUser)
        {
            var idOptionQuestionParameter = idOptionQuestion.HasValue ?
                new ObjectParameter("idOptionQuestion", idOptionQuestion) :
                new ObjectParameter("idOptionQuestion", typeof(long));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Response_Insert", idOptionQuestionParameter, idUserParameter);
        }
    
        public virtual ObjectResult<Response_Select_Result> Response_Select(Nullable<long> idQuestion)
        {
            var idQuestionParameter = idQuestion.HasValue ?
                new ObjectParameter("idQuestion", idQuestion) :
                new ObjectParameter("idQuestion", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Response_Select_Result>("Response_Select", idQuestionParameter);
        }
    
        public virtual int FavoriteEvent_Delete(Nullable<long> idEvent, Nullable<long> idUser)
        {
            var idEventParameter = idEvent.HasValue ?
                new ObjectParameter("idEvent", idEvent) :
                new ObjectParameter("idEvent", typeof(long));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FavoriteEvent_Delete", idEventParameter, idUserParameter);
        }
    
        public virtual int FavoriteEvent_Insert(Nullable<long> idEvent, Nullable<long> idUser)
        {
            var idEventParameter = idEvent.HasValue ?
                new ObjectParameter("idEvent", idEvent) :
                new ObjectParameter("idEvent", typeof(long));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FavoriteEvent_Insert", idEventParameter, idUserParameter);
        }
    
        public virtual ObjectResult<FavoriteEvent_Select_Result> FavoriteEvent_Select(Nullable<long> idUser)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FavoriteEvent_Select_Result>("FavoriteEvent_Select", idUserParameter);
        }
    
        public virtual ObjectResult<Event_Select_Result> Event_Select(Nullable<long> idUser)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Event_Select_Result>("Event_Select", idUserParameter);
        }
    
        public virtual ObjectResult<FavoriteQuestion_Select_Result> FavoriteQuestion_Select(Nullable<long> idUser)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FavoriteQuestion_Select_Result>("FavoriteQuestion_Select", idUserParameter);
        }
    
        public virtual ObjectResult<EventById_Select_Result> EventById_Select(Nullable<long> idEvent)
        {
            var idEventParameter = idEvent.HasValue ?
                new ObjectParameter("idEvent", idEvent) :
                new ObjectParameter("idEvent", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EventById_Select_Result>("EventById_Select", idEventParameter);
        }
    
        public virtual int Event_Update(Nullable<long> idEvent)
        {
            var idEventParameter = idEvent.HasValue ?
                new ObjectParameter("idEvent", idEvent) :
                new ObjectParameter("idEvent", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Event_Update", idEventParameter);
        }
    
        public virtual int Question_Update(Nullable<long> idQuestion)
        {
            var idQuestionParameter = idQuestion.HasValue ?
                new ObjectParameter("idQuestion", idQuestion) :
                new ObjectParameter("idQuestion", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Question_Update", idQuestionParameter);
        }
    
        public virtual ObjectResult<EventByKm_Select_Result> EventByKm_Select(Nullable<decimal> latitude, Nullable<decimal> longitude, Nullable<int> kM)
        {
            var latitudeParameter = latitude.HasValue ?
                new ObjectParameter("latitude", latitude) :
                new ObjectParameter("latitude", typeof(decimal));
    
            var longitudeParameter = longitude.HasValue ?
                new ObjectParameter("longitude", longitude) :
                new ObjectParameter("longitude", typeof(decimal));
    
            var kMParameter = kM.HasValue ?
                new ObjectParameter("KM", kM) :
                new ObjectParameter("KM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EventByKm_Select_Result>("EventByKm_Select", latitudeParameter, longitudeParameter, kMParameter);
        }
    
        public virtual ObjectResult<QuestionBykm_Select_Result> QuestionBykm_Select(Nullable<decimal> latitude, Nullable<decimal> longitude, Nullable<int> kM)
        {
            var latitudeParameter = latitude.HasValue ?
                new ObjectParameter("latitude", latitude) :
                new ObjectParameter("latitude", typeof(decimal));
    
            var longitudeParameter = longitude.HasValue ?
                new ObjectParameter("longitude", longitude) :
                new ObjectParameter("longitude", typeof(decimal));
    
            var kMParameter = kM.HasValue ?
                new ObjectParameter("KM", kM) :
                new ObjectParameter("KM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<QuestionBykm_Select_Result>("QuestionBykm_Select", latitudeParameter, longitudeParameter, kMParameter);
        }
    
        public virtual ObjectResult<Nullable<long>> ResponseByUser_Select(Nullable<long> idQuestion, Nullable<long> idUser)
        {
            var idQuestionParameter = idQuestion.HasValue ?
                new ObjectParameter("idQuestion", idQuestion) :
                new ObjectParameter("idQuestion", typeof(long));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("IdUser", idUser) :
                new ObjectParameter("IdUser", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("ResponseByUser_Select", idQuestionParameter, idUserParameter);
        }
    
        public virtual ObjectResult<Nullable<bool>> EventLikeByUser_Select(Nullable<long> idEvent, Nullable<long> idUser)
        {
            var idEventParameter = idEvent.HasValue ?
                new ObjectParameter("IdEvent", idEvent) :
                new ObjectParameter("IdEvent", typeof(long));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<bool>>("EventLikeByUser_Select", idEventParameter, idUserParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_generate(string tableName)
        {
            var tableNameParameter = tableName != null ?
                new ObjectParameter("tableName", tableName) :
                new ObjectParameter("tableName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_generate", tableNameParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int User_Insert(string firstName, string lastName, string nickName, Nullable<System.DateTime> birthday, string job, string city, string codeCountry, Nullable<bool> sex, string email, string photoUrl)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("firstName", firstName) :
                new ObjectParameter("firstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("lastName", lastName) :
                new ObjectParameter("lastName", typeof(string));
    
            var nickNameParameter = nickName != null ?
                new ObjectParameter("nickName", nickName) :
                new ObjectParameter("nickName", typeof(string));
    
            var birthdayParameter = birthday.HasValue ?
                new ObjectParameter("birthday", birthday) :
                new ObjectParameter("birthday", typeof(System.DateTime));
    
            var jobParameter = job != null ?
                new ObjectParameter("job", job) :
                new ObjectParameter("job", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("city", city) :
                new ObjectParameter("city", typeof(string));
    
            var codeCountryParameter = codeCountry != null ?
                new ObjectParameter("codeCountry", codeCountry) :
                new ObjectParameter("codeCountry", typeof(string));
    
            var sexParameter = sex.HasValue ?
                new ObjectParameter("sex", sex) :
                new ObjectParameter("sex", typeof(bool));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var photoUrlParameter = photoUrl != null ?
                new ObjectParameter("photoUrl", photoUrl) :
                new ObjectParameter("photoUrl", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("User_Insert", firstNameParameter, lastNameParameter, nickNameParameter, birthdayParameter, jobParameter, cityParameter, codeCountryParameter, sexParameter, emailParameter, photoUrlParameter);
        }
    
        public virtual ObjectResult<UserByEmail_Select_Result> UserByEmail_Select(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UserByEmail_Select_Result>("UserByEmail_Select", emailParameter);
        }
    
        public virtual int UserConexiones_Update(Nullable<long> idUser)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UserConexiones_Update", idUserParameter);
        }
    
        public virtual int User_Update(string firstName, string lastName, string nickName, Nullable<System.DateTime> birthday, string job, string city, string codeCountry, Nullable<bool> sex, string photoUrl)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("firstName", firstName) :
                new ObjectParameter("firstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("lastName", lastName) :
                new ObjectParameter("lastName", typeof(string));
    
            var nickNameParameter = nickName != null ?
                new ObjectParameter("nickName", nickName) :
                new ObjectParameter("nickName", typeof(string));
    
            var birthdayParameter = birthday.HasValue ?
                new ObjectParameter("birthday", birthday) :
                new ObjectParameter("birthday", typeof(System.DateTime));
    
            var jobParameter = job != null ?
                new ObjectParameter("job", job) :
                new ObjectParameter("job", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("city", city) :
                new ObjectParameter("city", typeof(string));
    
            var codeCountryParameter = codeCountry != null ?
                new ObjectParameter("codeCountry", codeCountry) :
                new ObjectParameter("codeCountry", typeof(string));
    
            var sexParameter = sex.HasValue ?
                new ObjectParameter("sex", sex) :
                new ObjectParameter("sex", typeof(bool));
    
            var photoUrlParameter = photoUrl != null ?
                new ObjectParameter("photoUrl", photoUrl) :
                new ObjectParameter("photoUrl", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("User_Update", firstNameParameter, lastNameParameter, nickNameParameter, birthdayParameter, jobParameter, cityParameter, codeCountryParameter, sexParameter, photoUrlParameter);
        }
    }
}