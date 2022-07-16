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

        private int numFramesElapsed = 0;
        

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
                Actor actor = scene.GetFirstActor("actors");
                Actor enemy = scene.GetFirstActor("enemy");
                Actor screen = scene.GetFirstActor("screen");
                List<Actor> fireballs = scene.GetAllActors("fireballs");

                numFramesElapsed++;

                // 1. if there are less than 4 fireballs in the cast, do the following:
                //    a. if numFramesElapsed = 30, 
                //    a.     reset numFramesElapsed = 0
                //    a.     Determine the direction of the fireball using actors and enemy's position
                //    b.     Create the fireball 
                //    c.     Add to Cast in the FB's group

                // 2. Loop through all and tell them to move and BounceIn(screen)
                //    a. for example, bool hasBounced = fireball.BounceIn(screen)
                //    b. if the fireball has bounced 2 times, remove it from the cast
            

            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move actor.", exception);
            }
        }

     
    }
}