

using Nancy.Testing;
using NUnit.Framework;

namespace itsjustaname_api.tests
{
    [TestFixture]
    public class TransactionModuleTests
    {
        [Test]
        public void TransactionsReturnsCorrectFormatTransaction()
        {
            var browser = new Browser(new Bootstrapper());
            var response = browser.Get("/transactions");

            Assert.That(response.Body.AsString(), Is.Not.EqualTo(string.Empty));
        }
    }
}
