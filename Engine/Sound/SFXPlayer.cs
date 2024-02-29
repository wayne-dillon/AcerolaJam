using Microsoft.Xna.Framework.Audio;

public class SFXPlayer
{
    private static SoundEffect buttonClick = Globals.content.Load<SoundEffect>("Sound//buttonClick");

    public static void PlaySound(SoundEffects sound)
    {
        SoundEffectInstance instance = sound switch
        {
            SoundEffects.BUTTON_CLICK => buttonClick.CreateInstance(),
            _ => buttonClick.CreateInstance()
        };
        instance.Volume = Persistence.preferences.sfxVolume / 100f;
        instance.Play();
    }
}