using System;
using System.Numerics;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;

namespace Final.Project 
{
    public class EnemyCollision 
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
        public void CollideEnemies(List<Actor> actors, Actor actor, Scene scene)
        {
            foreach (Actor enemy in scene.GetAllActors("enemies"))
            {
                if (actor.Overlaps(enemy))
                enemy.MoveTo(0, 0); // Tell it to randomly move to a location on the screen.
            }
        }
        
        
        private bool CheckCollision(List<Actor> actors, Actor actor)
        {
            foreach (Actor item in actors)
            {
                if (actor.Overlaps(item))
                return true;
            }
            return false;
        }
    }
}