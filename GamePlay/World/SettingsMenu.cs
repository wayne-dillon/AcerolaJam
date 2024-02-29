using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

public class SettingsMenu
{
    private readonly List<LinkedButton> buttons = new();
    private Tab currentTab = Tab.OPTIONS;
    private readonly TextComponent howToPlayText;
    private readonly TextComponent creditsText;

    private readonly string story = "";

    private readonly string credits = "Design/Programming By\nWayne Dillon\n\n\n"
                                    + "Music/SFX by\nAlia Scott";

    private OptionsMenu options;

    private enum Tab
    {
        OPTIONS,
        HOW_TO_PLAY,
        CREDITS
    }

    public SettingsMenu()
    {
        howToPlayText = new TextComponentBuilder().WithText(story).WithOffset(new Vector2(-50, 0)).Build();
        creditsText = new TextComponentBuilder().WithText(credits).Build();

        SpriteBuilder buttonBuilder = new SpriteBuilder().WithPath("rect")
                                                        .WithDims(new Vector2(432, 96))
                                                        .WithScreenAlignment(Alignment.TOP_LEFT)
                                                        .WithHoverScale(new Vector2(1.01f, 1.01f))
                                                        .WithButtonAction(SwitchTabs);

        buttons.Add(buttonBuilder.WithText("How to Play").WithOffset(new Vector2(960, 82)).WithButtonInfo(Tab.HOW_TO_PLAY).BuildLinkedButton());
        buttons.Add(buttonBuilder.WithText("Credits").WithOffset(new Vector2(1460, 82)).WithButtonInfo(Tab.CREDITS).BuildLinkedButton());
        buttons.Add(buttonBuilder.WithText("Options").WithOffset(new Vector2(460, 82)).WithButtonInfo(Tab.OPTIONS).WithAvailable(false).BuildLinkedButton());

        foreach (LinkedButton button in buttons)
        {
            button.SetLinkedList(buttons);
        }

        options = new();
    }

    public void Update()
    {
        foreach (LinkedButton button in buttons)
        {
            button.Update();
        }

        switch (currentTab)
        {
            case Tab.OPTIONS:
                options.Update();
                break;
            case Tab.HOW_TO_PLAY:
                howToPlayText.Update();
                break;
            case Tab.CREDITS:
                creditsText.Update();
                break;
        }
    }

    public void SwitchTabs(object SENDER, object INFO)
    {
        if (INFO is Tab tab)
        {
            currentTab = tab;
        }
    }

    public void Draw()
    {
        foreach (LinkedButton button in buttons)
        {
            button.Draw();
        }

        switch (currentTab)
        {
            case Tab.OPTIONS:
                options.Draw();
                break;
            case Tab.HOW_TO_PLAY:
                howToPlayText.Draw();
                break;
            case Tab.CREDITS:
                creditsText.Draw();
                break;
        }
    }
}