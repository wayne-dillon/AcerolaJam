using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class OptionsMenu
{
    private readonly TextComponent musicVolumeText, sfxVolumeText;
    private readonly Slider musicVolumeSlider;
    private readonly Slider sfxVolumeSlider;

    public OptionsMenu()
    {
        musicVolumeText = new TextComponentBuilder().WithText("Music Volume")
                                                .WithTextAlignment(Alignment.CENTER_LEFT)
                                                .WithOffset(new Vector2(-250, 0))
                                                .Build();
        sfxVolumeText = new TextComponentBuilder().WithText("SFX Volume")
                                                .WithTextAlignment(Alignment.CENTER_LEFT)
                                                .WithOffset(new Vector2(-250, 80))
                                                .Build();

        musicVolumeSlider = new Slider(Alignment.CENTER, new Vector2(150, 0), Music.GetVolume(), Music.SetPreferredVolume);
        sfxVolumeSlider = new Slider(Alignment.CENTER, new Vector2(150, 80), SFXPlayer.volume,
                                    (sender, info) => { SFXPlayer.volume = (float)info; });
    }

    public void Update()
    {
        sfxVolumeText.Update();
        sfxVolumeSlider.Update();
        musicVolumeText.Update();
        musicVolumeSlider.Update();
    }

    public void Draw()
    {
        sfxVolumeText.Draw();
        sfxVolumeSlider.Draw();
        musicVolumeText.Draw();
        musicVolumeSlider.Draw();
    }
}