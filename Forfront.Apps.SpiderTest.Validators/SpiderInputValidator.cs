using Forfront.Apps.Spider.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Forfront.Apps.Spiders.Validators
{
    public class SpiderInputValidator
    {
        public int X { get; set; }
        public int Y { get; set; }

        public OrientationEnum Orientation { get; set; }

        public SpiderInputValidator(string input="" )
        {
            if (String.IsNullOrEmpty(input)) { throw new ArgumentNullException("input"); }


            string[] inputs = input.Split(" ".ToCharArray());
            if (inputs.Length != 3)
            {
                throw new InvalidDataException("Spider input should have two integers and an orientation, separated by spaces");
            }
            for (var x=0; x<2;x++)//validate numbers first
            {
                var s = inputs[x];
                try
                {
                    int integerResult = Convert.ToInt32(s); // will throw an error if an integer was not entered
                }
                catch
                {
                    throw new InvalidDataException(s + " is not an integer");

                }

            }
            X = Convert.ToInt32(inputs[0]);
            Y = Convert.ToInt32(inputs[1]);

            Match match = Regex.Match(inputs[2].ToUpper(), "^[A-Z]+$");// we don't want users to be able to add numbers in third param, they wil parse to an enum in some circumstances but it's ugly and not the specified behaviour so not allowing it

            if (!match.Success)
            {
                throw new InvalidDataException("Orientation should be UP, DOWN, LEFT or RIGHT");

            }

             bool parsedOrientation=  Enum.TryParse(inputs[2].ToUpper(), out OrientationEnum orientationRes);
           // bool parsedOrientation = Enum.TryParse(typeof(OrientationEnum), inputs[2].ToUpper(), out OrientationEnum orientationResult);



            if (parsedOrientation!=true)
            {
                throw new InvalidDataException("Orientation should be UP, DOWN, LEFT or RIGHT");
            }
            else
            {
                Orientation = orientationRes;
            }

        }
    }
}
