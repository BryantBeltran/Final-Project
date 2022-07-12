using System;
using System.Runtime.Serialization.Formatters;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Final
{
    /// <summary>
    /// Plays background music for the example. Note the path to the music file comes from the
    /// program settings (see settings.json).
    /// </summary>
    public class PlayMusicAction : Byui.Games.Scripting.Action
    {
        private IAudioService _audioService;
        private ISettingsService _settingsService;
        
        private string musicBackroundString = "";
       

        public PlayMusicAction(IServiceFactory serviceFactory)
        {
            _audioService = serviceFactory.GetAudioService();
            _settingsService = serviceFactory.GetSettingsService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                
                string backgroundMusic = _settingsService.GetString(musicBackroundString);

                // start playing music if it isn't already
                if (!_audioService.IsPlayingMusic(backgroundMusic))
                {
                    _audioService.PlayMusic(backgroundMusic);
                }

                // update the audio buffer to keep playing it
                _audioService.UpdateMusic(backgroundMusic);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't play music.", exception);
            }
        }
    }
}