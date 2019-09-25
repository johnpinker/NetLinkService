using NUnit.Framework;
using linkservicenet.Controllers;
using linkservicenet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class LinkServiceTests
    {
        private readonly TestLinkService _testLinkService;
        private readonly LinksController _linksController;

        public LinkServiceTests()
        {
            _testLinkService = new TestLinkService();
            _linksController = new LinksController(_testLinkService);
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetReturnsCorrectNumber()
        {
            var result = _linksController.Get();
            Assert.AreEqual(result.Value.Count, _testLinkService._links.Count);
        }

        [Test]
        public void TestGetReturnsSuccess()
        {
            var result = _linksController.Get(_testLinkService._links[0].Id);
            var respResult = (ActionResult<Link>)result;
            Assert.IsNotNull(respResult.Value);
        }
    }
}