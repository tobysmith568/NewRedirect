using System.Collections.Generic;
using NUnit.Framework;
using Microsoft.AspNetCore.Http;
using Moq;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;

namespace NewRedirect.Tests
{
    [TestFixture]
    public class RedirectTests
    {
        [TestCase("doc", ExpectedResult= "https://docs.google.com/document/u/0/create")]
        [TestCase("sheet", ExpectedResult= "https://docs.google.com/spreadsheets/u/0/create")]
        public string ValidRequestResultsInARedirect(string key)
        {
            var queryCollection = new Mock<IQueryCollection>();
            queryCollection
                .Setup(q => q["key"])
                .Returns(key);

            var request = new Mock<HttpRequest>();
            request
                .Setup(r => r.Query)
                .Returns(queryCollection.Object);

            var result = Redirect.Run(request.Object);

            Assert.IsInstanceOf<RedirectResult>(result);

            RedirectResult redirectResult = (RedirectResult)result;
            return redirectResult.Url;
        }

        [Test]
        public void NoKeyResultsInBadRequest()
        {
            var request = new Mock<HttpRequest>();
            request
                .Setup(r => r.Query)
                .Returns(new QueryCollection());

            var result = Redirect.Run(request.Object);

            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [TestCase("")]
        [TestCase("not a valid key")]
        [TestCase("also not valid")]
        public void IncorrectKeyResultsInBadRequest(string key)
        {
            var queryCollection = new Mock<IQueryCollection>();
            queryCollection
                .Setup(q => q["key"])
                .Returns(key);

            var request = new Mock<HttpRequest>();
            request
                .Setup(r => r.Query)
                .Returns(queryCollection.Object);

            var result = Redirect.Run(request.Object);

            Assert.IsInstanceOf<BadRequestResult>(result);
        }
    }
}