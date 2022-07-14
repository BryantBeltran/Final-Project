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
    public class MoveActorAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;

        public MoveActorAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors from the scene
                Actor actor = scene.GetFirstActor("actors");
                Actor screen = scene.GetFirstActor("screen");
                
                // move the actor and restrict it to the screen boundaries
                // actor.Move(20); // use a constant pull of 5 in the downward direction
                actor.ClampTo(screen); // keep actor inside screen.
                MovePlayer(actor, scene);
                

            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move actor.", exception);
            }
        }

        private void MoveGround(Actor actor)
        {
            actor.Move();
        }

        private void MovePlayer(Actor actor, Scene scene) 
        {

            Vector2 change = actor.GetVelocity();
            MoveX(actor, change, scene.GetAllActors("platforms"));
            MoveY(actor, change, scene.GetAllActors("platforms"));

        }
        private void MoveX(Actor actor, Vector2 change, List<Actor> solids)
        {
            int move = Convert.ToInt32(Math.Round(change.X));

            int sign = Math.Sign(move);

            while (move != 0)
            {
                if (!CheckCollision(solids, actor, actor.GetPosition() + new Vector2 (sign, 0)))
                {
                    actor.MoveTo(actor.GetPosition() + new Vector2 (sign, 0));
                    move -= sign;
                }
                else
                {
                    actor.Steer(0, change.Y);
                    break;
                }
            }
        }

        private void MoveY(Actor actor, Vector2 change, List<Actor> solids)
        {
            int move = Convert.ToInt32(Math.Round(change.Y));

            int sign = Math.Sign(move);

            while (move != 0)
            {
                if (!CheckCollision(solids, actor, actor.GetPosition() + new Vector2 (0, sign)))
                {
                    actor.MoveTo(actor.GetPosition() + new Vector2 (0, sign));
                    move -= sign;
                }
                else
                {
                    actor.Steer(change.X, 0);
                    break;
                }
            }
        }

        private bool CheckCollision(List<Actor> actors, Actor actor, Vector2 point)
        {

            Actor check = new Actor();
            check.SizeTo(actor.GetSize());

            check.MoveTo(point);

            foreach (Actor item in actors)
            {
                if (item.Overlaps(check))
                {
                    return true;
                }
            }
            return false;
        }
    }
}