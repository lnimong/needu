using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAppNeedU.Deal;

namespace WebAppNeedU.Deal.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WebAppNeedU.Deal;
    using System.Collections.Generic;
    using WebAppNeedU.Deal.Entities;

    [TestClass()]
    public class RepositoryQuestionTests
    {
        [TestMethod()]
        public void InsertTest()
        {
            EntityQuestion question = new EntityQuestion();
            question.IdUser = 4;
            question.Latitude = 555;
            question.Longitud = 666;
            question.Title = "Color de zapatos favorito";
            question.Description = "Cúal es su color favorito de zapatos?";
            question.OptionsQuestion = new List<EntityOptionQuestion>();

            EntityOptionQuestion option = new EntityOptionQuestion();
            option.TextOption = "Azul";
            question.OptionsQuestion.Add(option);

            option = new EntityOptionQuestion();
            option.TextOption = "Amarillo";
            question.OptionsQuestion.Add(option);

            option = new EntityOptionQuestion();
            option.TextOption = "Negro";
            question.OptionsQuestion.Add(option);

            RepositoryQuestion repositorio = new RepositoryQuestion();
            repositorio.Insert(question);
        }

        [TestMethod()]
        public void QuestionByIdTest()
        {
            RepositoryQuestion repositorio = new RepositoryQuestion();
            repositorio.QuestionById(7);
        }



        [TestMethod()]
        public void QuestionByIdTest1()
        {
            RepositoryQuestion repositorio = new RepositoryQuestion();
            repositorio.QuestionById(7);
        }

        [TestMethod()]
        public void QuestionsByCountryTest()
        {
            RepositoryQuestion repositorio = new RepositoryQuestion();
            repositorio.QuestionsByCountry(4);
        }

        [TestMethod()]
        public void QuestionSelectTest()
        {
            RepositoryQuestion repositorio = new RepositoryQuestion();
            repositorio.QuestionSelect(4);
        }

        [TestMethod()]
        public void QuestionSelectTest1()
        {
            RepositoryQuestion repositorio = new RepositoryQuestion();
            repositorio.QuestionByKmSelect(10000, 60, 50);
        }
    }
}