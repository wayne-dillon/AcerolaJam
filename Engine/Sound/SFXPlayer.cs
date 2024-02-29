using Microsoft.Xna.Framework.Audio;

public class SFXPlayer
{
    private static SoundEffect buttonClick = Globals.content.Load<SoundEffect>("Sound//buttonClick");
    public static float volume = 0.5f;

    public static void PlaySound(SoundEffects sound)
    {
        SoundEffectInstance instance = sound switch
        {
            SoundEffects.BUTTON_CLICK => buttonClick.CreateInstance(),
            _ => buttonClick.CreateInstance()
        };
        instance.Volume = volume;
        instance.Play();
    }
}