using Microsoft.Xna.Framework.Audio;

public class SFXPlayer
{
    private static SoundEffect buttonClick = Globals.content.Load<SoundEffect>("Sound//buttonClick");
    private static SoundEffect move = Globals.content.Load<SoundEffect>("Sound//Move");
    private static SoundEffect invalid = Globals.content.Load<SoundEffect>("Sound//Invalid");
    public static float volume = 0.75f;

    public static void PlaySound(SoundEffects sound)
    {
        SoundEffectInstance instance = sound switch
        {
            SoundEffects.BUTTON_CLICK => buttonClick.CreateInstance(),
            SoundEffects.MOVE => move.CreateInstance(),
            SoundEffects.INVALID => invalid.CreateInstance(),
            _ => buttonClick.CreateInstance()
        };
        instance.Volume = volume;
        instance.Play();
    }
}