using System.Text.RegularExpressions;

namespace Forfront.Apps.Spiders.Validators
{
    public class RouteValidator
    {
        public string Route { get; set; }
        public RouteValidator(string input = "")
        {
            if (String.IsNullOrEmpty(input)) { throw new ArgumentNullException("input"); }

            Match match = Regex.Match(input, "^[R|L|F]+$");

            if (match.Success)
            {
                Route = input;
               
            }
            else
            {
                Route = "";
                throw new InvalidDataException("Route should only contain a combination of characters R,L or F");

            }

        }
    }
}