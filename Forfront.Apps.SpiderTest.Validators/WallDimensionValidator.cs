using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Forfront.Apps.Spiders.Validators
{
    public class WallDimensionValidator
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public WallDimensionValidator(string input = "")
        {
            if (String.IsNullOrEmpty(input)) { throw new ArgumentNullException("input"); }

            string[] inputs = input.Split(" ".ToCharArray());
            if (inputs.Length !=2)
            {
                throw new InvalidDataException("Wall dimensions should have two integers, separated by a space");
            }
            foreach (string s in inputs)
            {
                try
                {
                    int integerResult = Convert.ToInt32(s); // will throw an error if an integer was not entered
                }
                catch 
                {
                    throw new InvalidDataException( s + " is not an integer");

                }

            }
            Width = Convert.ToInt32(inputs[0]);
            Height = Convert.ToInt32(inputs[1]);

        }
    }
}
