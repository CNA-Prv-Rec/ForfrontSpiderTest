using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Forfront.Apps.Spiders
{
    public class Route
    {
        public string Path { get; set; }


        public Route(string proposedRoute) {

            Path = proposedRoute;
        }
        public char[] GetSteps()
        {
            return Path.ToCharArray();
        }
    }
}
