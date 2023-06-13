using Microsoft.VisualStudio.TestTools.UnitTesting;
using Forfront.Apps.Spiders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forfront.Apps.Spider.Common;
using Forfront.Apps.Spiders.Validators;

namespace Forfront.Apps.Spiders.Tests
{
    [TestClass()]
    public class SpiderTests
    {
     
       

        [TestMethod()]
        public void CrawlTestValidPath()
        {
            Wall wall = new Wall(10, 10);
            Spider spider = new Spider(2, 2, OrientationEnum.UP);
            Route route = new Route("FLFRFFFRFRF");
            StepController stepController = new StepController();
            try
            {
                string error = spider.Crawl(wall, route, stepController);
                Assert.IsTrue((spider.currentX == 2) && (spider.currentY == 5) && (spider.currentOrientation == OrientationEnum.DOWN) &&(error == ""));

            }
            catch (Exception ex) 
            {
                Assert.Fail(ex.Message);
            }

         
        }

        [TestMethod()]
        public void CrawlTestInvalidPath()
        {
            Wall wall = new Wall(10, 10);
            Spider spider = new Spider(2, 8, OrientationEnum.UP);
            Route route = new Route("FLFRFFFRFRF");// will hit an invalid path somewhere in the FFF region
            StepController stepController = new StepController();
            try
            {
                string error = spider.Crawl(wall, route, stepController);
                Assert.IsTrue((spider.currentX == 1) && (spider.currentY == 10) && (spider.currentOrientation == OrientationEnum.UP) && (error == "Error on step 6 of route: unable to move in direction specified"));

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

         
        }
    }
}