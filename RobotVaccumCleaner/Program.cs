using Forfront.Apps.Spiders;
using Forfront.Apps.Spiders.Validators;

namespace RobotVaccumCleaner
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            try
            {
                Console.WriteLine("Enter wall dimensions, in the form 'X Y'");
                var dimensionInput = Console.ReadLine();
                WallDimensionValidator wallValidator = new WallDimensionValidator(dimensionInput??"");
                Wall wall = new Wall(wallValidator.Width, wallValidator.Height);
               
                Console.WriteLine("Enter spider start point, in the form 'X Y Orientation'. Orientation can be UP, DOWN, LEFT or RIGHT.");
                var spiderInput = Console.ReadLine();
                SpiderInputValidator spiderValidator = new SpiderInputValidator(spiderInput??"");
                Spider spider = new Spider(spiderValidator.X, spiderValidator.Y, spiderValidator.Orientation);

                // route
                Console.WriteLine("Enter route, as a mixture of the directions L (left), R (right) or F (forward), with no spaces.");
                var routeInput = Console.ReadLine();
                RouteValidator routeValidator = new RouteValidator(routeInput ?? "");
                Route route = new Route(routeValidator.Route);

                // crawl along the route
                StepController stepController = new StepController();
                try
                {
                    string error = spider.Crawl(wall, route, stepController);
                    if (error != null)
                    {
                        Console.WriteLine(error);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                // get output and display it
                Console.WriteLine("Final output:" + spider.currentX.ToString() + " " + spider.currentY.ToString() + " " + spider.currentOrientation.ToString());
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}