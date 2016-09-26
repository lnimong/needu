namespace WebAppNeedU.Deal.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WebAppNeedU.Deal;

    [TestClass()]
    public class RepositoryResponseTests
    {
        [TestMethod()]
        public void ResponseSelectTest()
        {
            RepositoryResponse repositorio = new RepositoryResponse();
            repositorio.ResponseSelect(7);
        }
    }
}