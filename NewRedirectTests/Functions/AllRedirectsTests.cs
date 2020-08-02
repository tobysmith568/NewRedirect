using NUnit.Framework;
using NewRedirect.Functions;
using System;
using System.Collections.Generic;
using System.Text;
using NewRedirect.Storage;
using Microsoft.AspNetCore.Mvc;

namespace NewRedirect.Functions.Tests
{
    [TestFixture]
    public class AllRedirectsTests
    {
        [Test]
        public void ReturnsRedirects()
        {
            var result = AllRedirects.Run(null);

            Assert.IsInstanceOf<OkObjectResult>(result);

            OkObjectResult okResult = (OkObjectResult)result;

            Assert.IsInstanceOf<Redirection[]>(okResult.Value);

            Redirection[] redirections = (Redirection[])okResult.Value;

            Assert.IsTrue(redirections.Length > 0);
        }

        [Test]
        public void ReturnsRedirectsWithValues()
        {
            var result = AllRedirects.Run(null);

            Assert.IsInstanceOf<OkObjectResult>(result);

            OkObjectResult okResult = (OkObjectResult)result;

            Assert.IsInstanceOf<Redirection[]>(okResult.Value);

            Redirection[] redirections = (Redirection[])okResult.Value;

            Assert.IsTrue(redirections.Length > 0);
        }
    }
}