using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 
{
    public class EnemyCollision
    {
        
        public void CollideEnemies(Scene scene)
        {
            foreach (Actor enemy in scene.GetAllActors("enemies"))
            {
                if (actor.Overlaps(enemy))
                return true; // Tell it to randomly move to a location on the screen.
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