using Byui.Games.Casting;
using Byui.Games.Directing;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Sounds;


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
            label.Display("'a', 'd' to move 'space' jump");
            label.MoveTo(25, 25);
            //Our Hero
            float durationInSeconds = 0.4f;
            int framesPerSecond = 60;
            string[] filePaths = new string[4];
            filePaths[0] = "Assets/idle (1).png";
            filePaths[1] = "Assets/idle (2).png";
            filePaths[2] = "Assets/idle (3).png";
            filePaths[3] = "Assets/idle (4).png";

            Image actor = new Image();
            actor.SizeTo(60, 90);
            actor.MoveTo(270, 120);
            actor.Animate(filePaths,durationInSeconds,framesPerSecond);

            

            int enemyx = 1080;
            int enemyy = 40;
            int fireballSize = 50;
            // Our Goal
            float durationInSecondsEne = 1.2f;
            int framesPerSecondEne = 60;
            string [] filePathsEne = new string[12];
            filePathsEne[0] = "Assets/B Flame 1.png";
            filePathsEne[1] = "Assets/B Flame 2.png";
            filePathsEne[2] = "Assets/B Flame 3.png";
            filePathsEne[3] = "Assets/B Flame 4.png";
            filePathsEne[4] = "Assets/B Flame 5.png";
            filePathsEne[5] = "Assets/B Flame 6.png";
            filePathsEne[6] = "Assets/B Flame 7.png";
            filePathsEne[7] = "Assets/B Flame 8.png";
            filePathsEne[8] = "Assets/B Flame 9.png";
            filePathsEne[9] = "Assets/B Flame 10.png";
            filePathsEne[10] = "Assets/B Flame 11.png";
            filePathsEne[11] = "Assets/B Flame 12.png";
            Image enemy = new Image();
            enemy.SizeTo(150, 150);
            enemy.MoveTo(enemyx, enemyy);
            enemy.Animate(filePathsEne,durationInSecondsEne,framesPerSecondEne);

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
            plat3.MoveTo(450, 480);
            plat3.Display("Assets/platfo.png");
            //Screen Borders
            Image ground = new Image();
            ground.SizeTo(1400, 100);
            ground.MoveTo(0, 635);
            Image lBorder = new Image();
            lBorder.SizeTo(2, 800);
            lBorder.MoveTo(0, 0);
            lBorder.Tint(Color.Red());
            Image rBorder = new Image();
            rBorder.SizeTo(2, 800);
            rBorder.MoveTo(1278, 0);
            rBorder.Tint(Color.Red());
            Image topBorder = new Image();
            topBorder.SizeTo(1400, 2);
            topBorder.MoveTo(0, 0);
            topBorder.Tint(Color.Red());
            //Fireballs
            Actor Fb1 = new Actor();
            Fb1.SizeTo(fireballSize,fireballSize);
            Fb1.MoveTo(enemyx + 20, enemyy- 20);
            Fb1.Tint(Color.Red());
            Actor Fb2 = new Actor();
            Fb2.SizeTo(fireballSize,fireballSize);
            Fb2.MoveTo(enemyx - 40, enemyy + 40);
            Fb2.Tint(Color.Red());
            Actor Fb3 = new Actor();
            Fb3.SizeTo(fireballSize,fireballSize);
            Fb3.MoveTo(enemyx - 100, enemyy + 100);
            Fb3.Tint(Color.Red());



            // Instantiate the actions that use the actors.
            SteerActorAction steerActorAction = new SteerActorAction(serviceFactory);
            MoveActorAction moveActorAction = new MoveActorAction(serviceFactory);
            EnemyCollision enemyCollision = new EnemyCollision(serviceFactory);
            DrawActorAction drawActorAction = new DrawActorAction(serviceFactory);
            PlayMusicAction playMusicAction = new PlayMusicAction(serviceFactory);

            // Instantiate a new scene, add the actors and actions.
            Scene scene = new Scene();
            scene.AddActor("screen", screen);
            scene.AddActor("actors", actor);
            scene.AddActor("enemies", enemy);
            scene.AddActor("background", backg);
            scene.AddActor("platforms",plat1);
            scene.AddActor("platforms",plat2);
            scene.AddActor("platforms",plat3);
            scene.AddActor("platforms",ground);
            scene.AddActor("platforms",lBorder);
            scene.AddActor("platforms",rBorder);
            scene.AddActor("platforms",topBorder);
            scene.AddActor("labels", label);
            scene.AddActor("fireballs", Fb1);
            scene.AddActor("fireballs", Fb2);
            scene.AddActor("fireballs", Fb3);
            

            

            scene.AddAction(Phase.Input, steerActorAction);
            scene.AddAction(Phase.Update, moveActorAction);
            scene.AddAction(Phase.Update, enemyCollision);
            scene.AddAction(Phase.Output, drawActorAction);
            scene.AddAction(Phase.Output, playMusicAction);
            
            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}