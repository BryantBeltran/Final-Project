using System;
using System.Numerics;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Final.Project
{
    /// <summary>
    /// Moves the actors and clamps them to the screen boundaries. The call to actor.Move() is what updates
    /// their position on the screen.
    /// </summary>
    public class ShootFireballsAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;
        private IAudioService _audioService;
        private ISettingsService _settingsService;

        private int fireballSize = 50;

        private int numFramesElapsed = 0;

        private int deletionFrames = 0;
        

        public ShootFireballsAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
            _audioService = serviceFactory.GetAudioService();
            _settingsService = serviceFactory.GetSettingsService();

           
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors from the scene
                string bounceSound = _settingsService.GetString("bounceSound");
                Image actor = (Image)scene.GetFirstActor("actors");
                Image enemy = (Image )scene.GetFirstActor("enemies");
                Actor screen = scene.GetFirstActor("screen");
                List<Actor> fireballs = scene.GetAllActors("fireballs");
                // Get Enemy's and Actor's Position
                Vector2 enemyPosition = enemy.GetPosition();
                Vector2 actorPosition = actor.GetPosition();
             
                numFramesElapsed++;

                // 1. if there are less than 3 fireballs in the cast, do the following:
                if (fireballs.Count() < 3) 
                {

                     //a. if numFramesElapsed = 90,
                    if (numFramesElapsed >= 90 )
                    {
                        //    b.     reset numFramesElapsed = 0
                        numFramesElapsed = 0;
                         //    c.     Create the fireball 
                        Actor fireball = new Actor();
                        fireball.SizeTo(fireballSize, fireballSize);
                        fireball.MoveTo(enemyPosition.X+10, enemyPosition.Y+50);
                        fireball.Steer(-1, 1);
                        fireball.Tint(Color.Red());
                         //    c.     Add to Cast in the FB's group
                        scene.AddActor("fireballs", fireball);
                        //    c.     Determine the direction of the fireball using actors and enemy's position

 
                    }
                }
                
                // 2. Loop through all and tell them to move and BounceIn(screen)
                
                deletionFrames ++;
                    // string fireballSound = _settingsService.GetString("fireballSound");
                    // _audioService.PlaySound(fireballSound);
                if (deletionFrames >= 300)
                {
                        Actor fireball = scene.GetFirstActor("fireballs");
                        scene.RemoveActor("fireballs", fireball);
                        deletionFrames = 0;
                }
            }

               

            catch (Exception exception)
            {
                callback.OnError("Couldn't move actor.", exception);
            }
        }

     
    }
}