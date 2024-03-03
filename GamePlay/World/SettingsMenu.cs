using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

public class SettingsMenu
{
    private readonly List<LinkedButton> buttons = new();
    private Tab currentTab = Tab.OPTIONS;
    private readonly TextComponent howToPlayText;
    private readonly TextComponent inputText;
    private readonly TextComponent controlText;

    private readonly string howToPlay = "Complete rows from the falling blocks to score points!";
    private readonly string inputs = "'A' / Left Arrow"
                                        + "\n'D' / Right Arrow"
                                        + "\n'S' / Down Arrow"
                                        + "\n'W' / Up Arrow"
                                        + "\n'Q' / 'X'"
                                        + "\n'E' / 'C'";
    private readonly string controls = "Move block left"
                                        + "\nMove block right"
                                        + "\nMove block down"
                                        + "\nDrop block"
                                        + "\nRotate block counter-clockwise"
                                        + "\nRotate block clockwise";

    private OptionsMenu options;

    private enum Tab
    {
        OPTIONS,
        HOW_TO_PLAY
    }

    public SettingsMenu()
    {
        howToPlayText = new TextComponentBuilder().WithText(howToPlay).WithScreenAlignment(Alignment.TOP).WithOffset(new Vector2(0, 220)).Build();
        inputText = new TextComponentBuilder().WithText(inputs).WithOffset(new Vector2(-340, 80)).Build();
        controlText = new TextComponentBuilder().WithText(controls).WithOffset(new Vector2(230, 80)).Build();

        SpriteBuilder buttonBuilder = new SpriteBuilder().WithPath("rect")
                                                        .WithDims(new Vector2(250, 64))
                                                        .WithScreenAlignment(Alignment.TOP)
                                                        .WithHoverScale(new Vector2(1.01f, 1.01f))
                                                        .WithButtonAction(SwitchTabs);

        buttons.Add(buttonBuilder.WithText("How to Play").WithOffset(new Vector2(130, 82)).WithButtonInfo(Tab.HOW_TO_PLAY).BuildLinkedButton());
        buttons.Add(buttonBuilder.WithText("Options").WithOffset(new Vector2(-130, 82)).WithButtonInfo(Tab.OPTIONS).WithAvailable(false).BuildLinkedButton());

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
                inputText.Update();
                controlText.Update();
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
                inputText.Draw();
                controlText.Draw();
                break;
        }
    }
}