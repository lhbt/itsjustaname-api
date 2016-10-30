using Nancy.Testing;
using NUnit.Framework;

namespace itsjustaname_api.tests
{
    [TestFixture]
    public class UserDataModuleTests
    {
        [Test]
        public void ItShouldTakeRawDataAndReturnMappedTransactions()
        {
            const string inputJson = @"{
""transactions"": [
{
""merchant"": ""tesco"",
""amount"": 2950,
""creditOrDebit"": ""Debit"",
""createdDate"": ""2016-10-30T00:00:00.000""
},
{
""merchant"": ""pay"",
""amount"": 344444,
""creditOrDebit"": ""Credit"",
""createdDate"": ""2016-10-30T00:00:00.000""
}
]
}";

            const string expectedResponse = @"[{""totalSpent"":29,""totalReceived"":3444,""transactions"":[{""type"":""debit"",""amount"":29,""name"":""tesco"",""imageUrl"":""http://cdn-2.famouslogos.us/images/tesco-logo.jpg"",""hasUpgrade"":true},{""type"":""credit"",""amount"":3444,""name"":""pay"",""imageUrl"":null,""hasUpgrade"":false}],""date"":""30 October 2016""}]";
            var browser = new Browser(new Bootstrapper());

            var response = browser.Post("/userdata", context => context.Body(inputJson));

            Assert.That(response.Body.AsString(), Is.EqualTo(expectedResponse));
        }
    }
}
