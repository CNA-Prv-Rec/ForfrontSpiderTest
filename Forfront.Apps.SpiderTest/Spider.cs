using Forfront.Apps.Spider.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forfront.Apps.Spiders
{
    public class Spider
    {
        public int currentX { get; set; }
        public int currentY { get; set; }

        public OrientationEnum currentOrientation { get; set; }

        int degreesOrientation { get; set; }

        public Spider(int x, int y, OrientationEnum orientation)
        {

            currentX = x;
            currentY= y;
            currentOrientation = orientation;

        }

        public string Crawl(Wall wall, Route route, StepController directionChanger)
        {
           
            char[] steps = route.GetSteps();
            char step;
            int x = 0;

            try
            {
                for (x=0;x< steps.Length;x++)
                {
                    step = steps[x];
                    Move(wall, step, directionChanger);
                }
                return "";//successful
            }
            catch(Exception ex)
            {
                return "Error on step " + (x+1).ToString() + " of route: unable to move in direction specified";
            }

        }

        public void Move(Wall wall, char step, StepController stepController)
        {
            // if left or right, get dir from direction changer.
            //  if forward, add 1 to the position, see if there's a cell there for the wall, and move to it set current pos. if not throw an error'
            int futureX = currentX;
            int futureY = currentY;

            switch(step.ToString())
            {
                case "F":
                    // the next line will generate an error if the cell to move to doesn't exist
                   bool success= stepController.MoveForward(wall, this.currentX, this.currentY, this.currentOrientation, out futureX, out futureY);
                    if (success)
                    {
                        this.currentX = futureX;
                        this.currentY = futureY;
                    }
                    break;
                case "L":
                case "R":
                    this.currentOrientation= stepController.GetNextOrientation(this.currentOrientation, step);
                    break;
                default:
                    throw new InvalidOperationException();
                    
            }


        }

    }
}
