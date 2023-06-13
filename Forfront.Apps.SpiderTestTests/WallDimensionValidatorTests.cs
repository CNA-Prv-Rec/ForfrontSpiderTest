using Microsoft.VisualStudio.TestTools.UnitTesting;
using Forfront.Apps.Spiders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forfront.Apps.Spiders.Validators;

namespace Forfront.Apps.Spiders.Tests
{
    [TestClass()]
    public class WallDimensionValidatorTests
    {
        [TestMethod()]
        public void WallDimensionValidatorValidData()
        {
            string input= "15 27";
            try
            {
                WallDimensionValidator validator = new WallDimensionValidator(input);
                Assert.IsTrue((validator.Width == 15)&&(validator.Height == 27));   
            } 
            catch 
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        public void WallDimensionValidatorNoSpace()
        {
            string input = "1527";
            try
            {
                WallDimensionValidator validator = new WallDimensionValidator(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Wall dimensions should have two integers, separated by a space");
            }
        }

        [TestMethod()]
        public void WallDimensionValidatorEmpty()
        {
            string input = "";
            try
            {
                WallDimensionValidator validator = new WallDimensionValidator(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Wall dimensions should have two integers, separated by a space");
            }
        }

        [TestMethod()]
        public void WallDimensionValidatorFirstIsString()
        {
            string input = "blah 12";
            try
            {
                WallDimensionValidator validator = new WallDimensionValidator(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "blah is not an integer");
            }
        }

        [TestMethod()]
        public void WallDimensionValidatorSecondIsString()
        {
            string input = "23 blah";
            try
            {
                WallDimensionValidator validator = new WallDimensionValidator(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "blah is not an integer");
            }
        }

        [TestMethod()]
        public void WallDimensionValidatorFirstIsDouble()
        {
            string input = "15.26 8";
            try
            {
                WallDimensionValidator validator = new WallDimensionValidator(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "15.26 is not an integer");
            }
        }

        [TestMethod()]
        public void WallDimensionValidatorSecondIsDouble()
        {
            string input = "15 8.5";
            try
            {
                WallDimensionValidator validator = new WallDimensionValidator(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "8.5 is not an integer");
            }
        }

    }
}