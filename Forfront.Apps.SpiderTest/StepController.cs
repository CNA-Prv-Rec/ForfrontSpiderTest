using Forfront.Apps.Spider.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forfront.Apps.Spiders
{
    public class StepController
    {
        List<MovementResult> directionAdapter = new List<MovementResult>();
       
        public StepController() 
        {
            directionAdapter.Clear();
            directionAdapter.Add(new MovementResult() { CurrentOrientation=OrientationEnum.UP, AfterGoingForward = OrientationEnum.UP, AfterGoingLeft = OrientationEnum.LEFT, AfterGoingRight = OrientationEnum.RIGHT });
            directionAdapter.Add(new MovementResult() { CurrentOrientation=OrientationEnum.DOWN, AfterGoingForward = OrientationEnum.DOWN, AfterGoingLeft = OrientationEnum.RIGHT, AfterGoingRight = OrientationEnum.LEFT });
            directionAdapter.Add(new MovementResult() { CurrentOrientation=OrientationEnum.LEFT, AfterGoingForward = OrientationEnum.LEFT, AfterGoingLeft = OrientationEnum.DOWN, AfterGoingRight = OrientationEnum.UP });
            directionAdapter.Add(new MovementResult() { CurrentOrientation=OrientationEnum.RIGHT, AfterGoingForward = OrientationEnum.RIGHT, AfterGoingLeft = OrientationEnum.UP, AfterGoingRight = OrientationEnum.DOWN });
        }

        public OrientationEnum GetNextOrientation(OrientationEnum currentOrientation, char direction)
        {
            MovementResult movement = directionAdapter.Where(p => p.CurrentOrientation == currentOrientation).First();
            switch(direction.ToString())
            {
                case "R":
                    return movement.AfterGoingRight;
                case "L":
                    return movement.AfterGoingLeft;
                case "F":
                    return movement.AfterGoingForward;
                default:
                    throw new InvalidOperationException();
            }

            
        }

        public bool MoveForward(Wall wall, int currentX, int currentY,  OrientationEnum currentOrientation, out int futureX, out int futureY)
        {
            futureX = currentX;
            futureY = currentY;

            switch (currentOrientation)
            {
                case OrientationEnum.LEFT:
                    futureX = currentX - 1;
                    break;
                case OrientationEnum.RIGHT:
                    futureX = currentX + 1;
                    break;
                case OrientationEnum.UP:
                    futureY = currentY + 1;
                    break;
                case OrientationEnum.DOWN:
                    futureY = currentY - 1;
                    break;
                default:
                    throw new InvalidOperationException();
            }
            // is there a cell in the grid for future x/y?
           if (wall.HasCell(futureX,futureY))
            {
                return true; //able to move to new cell
            }
           else
            {
                // if there is nowhere to move to, reset x and y to old values and return an error
                futureX = currentX;
                futureY = currentY;
                throw new InvalidOperationException("Specified direction is outside the bounds of the wall");
            }

            
        }


    }


}
