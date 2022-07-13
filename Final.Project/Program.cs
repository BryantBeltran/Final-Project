using Byui.Games.Casting;
using Byui.Games.Directing;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Example.Sounds;


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
            //Our Hero
            Actor actor = new Actor();
            actor.SizeTo(60, 60);
            actor.MoveTo(270, 190);
            actor.Tint(Color.Yellow());
            // Our Goal
            Actor enemy = new Actor();
            enemy.SizeTo(100, 100);
            enemy.MoveTo(980, 100);
            enemy.Tint(Color.Red());

            Actor screen = new Actor();
            screen.SizeTo(1280, 720);
            screen.MoveTo(0, 0);

            // Platforms
            Image plat1 = new Image();
            plat1.SizeTo(226, 52);
            plat1.MoveTo(280, 300);
            plat1.Display("Assets/platfo.png");

            Image plat2 = new Image();
            plat2.SizeTo(226, 52);
            plat2.MoveTo(680, 300);
            plat2.Display("Assets/platfo.png");

            Image plat3 = new Image();
            plat3.SizeTo(226, 52);
            plat3.MoveTo(450, 500);
            plat3.Display("Assets/platfo.png");

            Image ground = new Image();
            ground.SizeTo(1400, 100);
            ground.MoveTo(0, 635);

            // Instantiate the actions that use the actors.
            SteerActorAction steerActorAction = new SteerActorAction(serviceFactory);
            MoveActorAction moveActorAction = new MoveActorAction(serviceFactory);
            DrawActorAction drawActorAction = new DrawActorAction(serviceFactory);
            PlayMusicAction playMusicAction = new PlayMusicAction(serviceFactory);

            // Instantiate a new scene, add the actors and actions.
            Scene scene = new Scene();
            scene.AddActor("screen", screen);
            scene.AddActor("actors", actor);
            scene.AddActor("enemy", enemy);
            scene.AddActor("background", backg);
            scene.AddActor("platforms",plat1);
            scene.AddActor("platforms",plat2);
            scene.AddActor("platforms",plat3);
            scene.AddActor("platforms",ground);
            scene.AddActor("labels", label);
       
            scene.AddAction(Phase.Input, steerActorAction);
            scene.AddAction(Phase.Update, moveActorAction);
            scene.AddAction(Phase.Output, drawActorAction);
            scene.AddAction(Phase.Output, playMusicAction);

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}