using Microsoft.Xna.Framework.Media;

public class Music
{
    private static Song mainTheme;
    private static MyTimer fadeTime;
    private static Song currentSong;
    public static float volume = 0.0f;

    public Music()
    {
        mainTheme = Globals.content.Load<Song>("Sound//MainTheme");
        MediaPlayer.Volume = volume;
        //PlayOnRepeat(mainTheme);
    }

    public static void SetTrack()
    {
        switch (Globals.gameState)
        {
            case GameState.GAME_PLAY:
            default:
                PlayOnRepeat(mainTheme);
                break;
        }
    }

    private static void PlayOnRepeat(Song SONG)
    {
        currentSong = SONG; 
        MediaPlayer.IsRepeating = true;
        MediaPlayer.Play(currentSong);
    }

    public static void SetPreferredVolume(object SENDER, object INFO)
    {
        if (INFO is float value)
        {
            MediaPlayer.Volume = value;
        }
    }

    public static void SetCurrentVolume(object SENDER, object INFO)
    {
        if (INFO is float value)
        {
            volume = value;
            MediaPlayer.Volume = value;
        }
    }

    public static float GetVolume()
    {
        return MediaPlayer.Volume;
    }

    public static void SetFadeTime(int TIME)
    {
        fadeTime = new MyTimer(TIME);
    }

    public static void FadeDown()
    {
        fadeTime.UpdateTimer();
        float percentage = fadeTime.RemainingTime <= 0 ? 0 : (float)fadeTime.RemainingTime / (float)fadeTime.MSec;
        SetCurrentVolume(null, volume * percentage);
    }

    public static void FadeUp()
    {
        fadeTime.UpdateTimer();
        float percentage = fadeTime.RemainingTime <= 0 ? 1 : (float)fadeTime.Timer / (float)fadeTime.MSec;
        SetCurrentVolume(null, volume * percentage);
    }
}