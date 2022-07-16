using System;
using System.Numerics;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;

namespace Final.Project 
{
    public class EnemyCollision : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;
        private IAudioService _audioService;
        private ISettingsService _settingsService;

        public EnemyCollision(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
            _audioService = serviceFactory.GetAudioService();
            _settingsService = serviceFactory.GetSettingsService();
            
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {  

            try
            {
                Random rnd = new Random();
                int numx = rnd.Next(100, 600);
                int numy = rnd.Next(50, 1200);
                // Actor actor = scene.GetFirstActor("actors");
                Image actor = (Image) scene.GetFirstActor("actors");
                foreach (Actor enemy in scene.GetAllActors("enemies"))
                {
                    if (actor.Overlaps(enemy))
                    {
                    enemy.MoveTo(numy, numx); 
                    // Tell it to randomly move to a location on the screen.
                    }
                }
                foreach (Actor fireball in scene.GetAllActors("fireballs"))
                {
                    if (actor.Overlaps(fireball))
                    { 
                    ; 
                    }
                

                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move actor.", exception);
            }
        }
    }
}