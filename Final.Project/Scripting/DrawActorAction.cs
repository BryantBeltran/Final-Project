using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Final.Project
{
    /// <summary>
    /// Draws the actors on the screen.
    /// </summary>
    public class DrawActorAction : Byui.Games.Scripting.Action
    {
        private IVideoService _videoService;

        public DrawActorAction(IServiceFactory serviceFactory)
        {
            _videoService = serviceFactory.GetVideoService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors from the cast
                Image backg = (Image) scene.GetFirstActor("background");
                Label label = (Label) scene.GetFirstActor("labels");
                Image actor = (Image) scene.GetFirstActor("actors");
                Actor enemy = scene.GetFirstActor("enemy");
                Actor ground = scene.GetFirstActor("ground");
                List <Image> platforms = scene.GetAllActors<Image>("platforms");
                

                
                // draw the actors on the screen using the video service
                _videoService.ClearBuffer();
 
                _videoService.Draw(backg);
                _videoService.Draw(label);
                _videoService.Draw(actor);
                _videoService.Draw(enemy);
                _videoService.Draw(platforms);



                

                
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw actors.", exception);
            }
        }
    }
}