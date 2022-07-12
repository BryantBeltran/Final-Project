using Byui.Games.Casting;
using Byui.Games.Directing;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Final.Project
{
    /// <summary>
    /// The entry point for the program.
    /// </summary>
    /// <remarks>
    /// The purpose of this program is to demonstrate how Actors, Actions, Services and a Director 
    /// work together to move an actor on the screen.
    /// </remarks>
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Instantiate a service factory for other objects to use.
            IServiceFactory serviceFactory = new RaylibServiceFactory();

            Image backg = new Image();
            backg.SizeTo(1280, 720);
            backg.MoveTo(0, 0);
            backg.Display("Assets/woods.png");


            // Instantiate the actors that are used in this example.
            Label label = new Label();
            label.Display("'w', 's', 'a', 'd' to move");
            label.MoveTo(25, 25);
            
            Actor actor = new Actor();
            actor.SizeTo(100, 100);
            actor.MoveTo(270, 190);
<<<<<<< HEAD
            actor.Tint(Color.White());

            Actor enemy = new Actor();
            enemy.SizeTo(200, 170);
            enemy.MoveTo(380, 190);
            enemy.Tint(Color.Red());

            Actor screen = new Actor();
            screen.SizeTo(1280, 720);
=======
            actor.Tint(Color.Blue());

            Actor screen = new Actor();
            screen.SizeTo(640, 480);
>>>>>>> 1de71cff9abcc213b0a3d9ce53f0d8b8e7181835
            screen.MoveTo(0, 0);


            // Instantiate the actions that use the actors.
            SteerActorAction steerActorAction = new SteerActorAction(serviceFactory);
            MoveActorAction moveActorAction = new MoveActorAction(serviceFactory);
            DrawActorAction drawActorAction = new DrawActorAction(serviceFactory);

            // Instantiate a new scene, add the actors and actions.
            Scene scene = new Scene();
            scene.AddActor("actors", actor);
<<<<<<< HEAD
            scene.AddActor("actors", enemy);
            scene.AddActor("background", backg);
=======
>>>>>>> 1de71cff9abcc213b0a3d9ce53f0d8b8e7181835
            scene.AddActor("labels", label);
            scene.AddActor("screen", screen);
            scene.AddAction(Phase.Input, steerActorAction);
            scene.AddAction(Phase.Update, moveActorAction);
            scene.AddAction(Phase.Output, drawActorAction);
            // scene.AddAction(Phase.Output, drawImageAction);

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}