namespace WebAppNeedU.Deal.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using WebAppNeedU.Deal;
    using WebAppNeedU.Deal.Entities;

    [TestClass()]
    public class RepositoryFavoriteTests
    {
        [TestMethod()]
        public void FavoriteQuestionInsertTest()
        {
            RepositoryFavorite repositorio = new RepositoryFavorite();

            Int64 idUser = 4;
            Int64 idQuestion = 7;
            repositorio.FavoriteQuestionInsert(idQuestion, idUser);
        }

        [TestMethod()]
        public void FavoriteQuestionDeleteTest()
        {
            RepositoryFavorite repositorio = new RepositoryFavorite();
            repositorio.FavoriteQuestionDelete(7, 4);
        }

        [TestMethod()]
        public void FavoriteQuestionSelectTest()
        {
            RepositoryFavorite repositorio = new RepositoryFavorite();
            repositorio.FavoriteQuestionSelect(4);
        }
    }
}