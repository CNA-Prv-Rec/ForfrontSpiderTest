using Microsoft.VisualStudio.TestTools.UnitTesting;
using Forfront.Apps.Spiders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forfront.Apps.Spiders.Validators;
using Forfront.Apps.Spider.Common;

namespace Forfront.Apps.Spiders.Tests
{
    [TestClass()]
    public class SpiderInputValidatorTests
    {
        [TestMethod()]
        public void SpiderInputValidatorValidData()
        {
            string input = "5 2 Left";
            try
            {
                SpiderInputValidator validator = new SpiderInputValidator(input);
                Assert.IsTrue((validator.X == 5) && (validator.Y == 2) && validator.Orientation== OrientationEnum.LEFT);

            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void SpiderInputValidatorIncorrectNumberOfParams()
        {
            string input = "52 Left";
            try
            {
                SpiderInputValidator validator = new SpiderInputValidator(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Spider input should have two integers and an orientation, separated by spaces");

            }
        }

        [TestMethod()]
        public void SpiderInputValidatorNullParams()
        {
            string input="";
            try
            {
                SpiderInputValidator validator = new SpiderInputValidator(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Value cannot be null. (Parameter 'input')");

            }
        }


        [TestMethod()]
        public void SpiderInputValidatorFirstNotANumber()
        {
            string input = "a 2 Left";
            try
            {
                SpiderInputValidator validator = new SpiderInputValidator(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "a is not an integer");

            }
        }

        [TestMethod()]
        public void SpiderInputValidatorFirstNotAnInt()
        {
            string input = "7.4 2 Left";
            try
            {
                SpiderInputValidator validator = new SpiderInputValidator(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "7.4 is not an integer");

            }
        }

        [TestMethod()]
        public void SpiderInputValidatorSecondNotANumber()
        {
            string input = "3 t Left";
            try
            {
                SpiderInputValidator validator = new SpiderInputValidator(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "t is not an integer");

            }
        }

        [TestMethod()]
        public void SpiderInputValidatorSecondNotAnInt()
        {
            string input = "3 2.87 Left";
            try
            {
                SpiderInputValidator validator = new SpiderInputValidator(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "2.87 is not an integer");

            }
        }

      

        [TestMethod()]
        public void SpiderInputValidatorThirdNotValidOrientation()
        {
            string input = "3 2 Diagonal";
            try
            {
                SpiderInputValidator validator = new SpiderInputValidator(input);
                Assert.Fail();
            }
            catch(Exception ex)
            {
                Assert.IsTrue(ex.Message == "Orientation should be UP, DOWN, LEFT or RIGHT");

            }
        }

        [TestMethod()]
        public void SpiderInputValidatorThirdParamIsANumber()
        {
            string input = "3 2 5";
            try
            {
                SpiderInputValidator validator = new SpiderInputValidator(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Orientation should be UP, DOWN, LEFT or RIGHT");

            }
        }

    }
}