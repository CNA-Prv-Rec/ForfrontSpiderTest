using Forfront.Apps.Spider.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forfront.Apps.Spiders
{
    public class MovementResult
    {
        internal OrientationEnum CurrentOrientation { get; set; }
        internal OrientationEnum AfterGoingLeft { get; set; }
        internal OrientationEnum AfterGoingRight { get; set; }
        internal OrientationEnum AfterGoingForward { get; set; }


    }
}
