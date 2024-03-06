using Microsoft.Xna.Framework.Audio;

public class SFXPlayer
{
    private static SoundEffect buttonClick = Globals.content.Load<SoundEffect>("Sound//buttonClick");
    private static SoundEffect move = Globals.content.Load<SoundEffect>("Sound//Move");
    private static SoundEffect invalid = Globals.content.Load<SoundEffect>("Sound//Invalid");
    private static SoundEffect gameOver = Globals.content.Load<SoundEffect>("Sound//GameOver");
    private static SoundEffect blockLands = Globals.content.Load<SoundEffect>("Sound//BlockLands");
    private static SoundEffect lineComplete = Globals.content.Load<SoundEffect>("Sound//LineComplete");
    private static SoundEffect glitch = Globals.content.Load<SoundEffect>("Sound//Glitch");
    public static float volume = 0.8f;

    public static void PlaySound(SoundEffects sound)
    {
        SoundEffectInstance instance = sound switch
        {
            SoundEffects.BUTTON_CLICK => buttonClick.CreateInstance(),
            SoundEffects.MOVE => move.CreateInstance(),
            SoundEffects.INVALID => invalid.CreateInstance(),
            SoundEffects.GAME_OVER => gameOver.CreateInstance(),
            SoundEffects.BLOCK_LANDS => blockLands.CreateInstance(),
            SoundEffects.LINE_COMPLETE => lineComplete.CreateInstance(),
            SoundEffects.GLITCH => glitch.CreateInstance(),
            _ => buttonClick.CreateInstance()
        };
        instance.Volume = sound == SoundEffects.BLOCK_LANDS ? volume / 4 : volume;
        instance.Play();
    }
}