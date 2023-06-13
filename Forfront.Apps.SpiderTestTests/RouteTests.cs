using Microsoft.VisualStudio.TestTools.UnitTesting;
using Forfront.Apps.Spiders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Forfront.Apps.Spiders.Validators;

namespace Forfront.Apps.Spiders.Tests
{
    [TestClass()]
    public class RouteTests
    {
        [TestMethod()]
        public void RouteTestInvalidDataStart()
        {
            try
            {
                RouteValidator validator = new RouteValidator("aRLF");
              
                Assert.Fail();//route should not initialise without error if route invalid
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Route should only contain a combination of characters R,L or F");

            }
            
        }
        [TestMethod()]
        public void RouteTestInvalidDataEnd()
        {
            try
            {
                RouteValidator validator = new RouteValidator("RLFM");
                Assert.Fail();//route should not initialise without error if route invalid
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Route should only contain a combination of characters R,L or F");

            }
        }
        [TestMethod()]
        public void RouteTestInvalidDataMid()
        {
            try
            {
                RouteValidator validator = new RouteValidator("RLYF");
                Assert.Fail();//routevalidator should not initialise without error if route invalid
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Route should only contain a combination of characters R,L or F");

            }
        }

        [TestMethod()]
        public void RouteTestInvalidDataEmpty()
        {
            try
            {
                Route r = new Route("");
                Assert.Fail();//route should not initialise without error if route invalid
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Proposed route should not be empty");

            }
        }

    

        [TestMethod()]
        public void RouteTestValidData()
        {
          
            try
            {
                Route r = new Route("RFLFRLFRLFR");
                Assert.IsTrue(r != null);//route should not be null
            }
            catch 
            {
                Assert.Fail("Did not initialise even with valid data");

            }
    }
    }
}