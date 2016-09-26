
namespace WebAppNeedU.Deal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WebAppNeedU.Deal.Data;
    using WebAppNeedU.Deal.Entities;

    public class RepositoryComment
    {
        private Needuapp_BDEntities bd = new Needuapp_BDEntities();

        public List<EntityCommentQuestion> SelectCommentsQuestion(Int64 idQuestion)
        {
            List<EntityCommentQuestion> comments = new List<EntityCommentQuestion>();
            var resultado = bd.CommentsQuestion_Select(idQuestion);

            comments = (from item in resultado
                        select new EntityCommentQuestion
                        {
                            IdQuestion = idQuestion,
                            Comment = item.comment,
                            Date = item.date,
                            NickNameUser = item.nickName
                        }).ToList();

            return comments;
        }

        public void InsertCommentQuestion(EntityCommentQuestion comment)
        {
            bd.CommentsQuestion_Insert(comment.IdQuestion, comment.IdUser, comment.Comment, comment.Date);
        }

        public List<EntityCommentEvent> SelectCommentsEvent(Int64 idEvent)
        {
            List<EntityCommentEvent> comments = new List<EntityCommentEvent>();
            var resultado = bd.CommentsEvent_Select(idEvent);

            comments = (from item in resultado
                        select new EntityCommentEvent
                        {
                            IdEvent = idEvent,
                            Comment = item.comment,
                            Date = item.date,
                            NickNameUser = item.nickName
                        }).ToList();

            return comments;
        }

        public void InsertCommentEvent(EntityCommentEvent comment)
        {
            bd.CommentsEvent_Insert(comment.IdEvent, comment.IdUser, comment.Comment, comment.Date);
        }
    }
}
