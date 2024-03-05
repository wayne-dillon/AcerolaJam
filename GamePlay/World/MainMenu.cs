using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class MainMenu
{
    public List<Button> buttons = new();
    public Button continueButton;
    private TextComponent title;

    public MainMenu()
    {
        SpriteBuilder buttonBuilder = new SpriteBuilder().WithScreenAlignment(Alignment.CENTER)
                                                        .WithPath("Button250x64")
                                                        .WithDims(new Vector2(250, 64));

        buttons.Add(buttonBuilder.WithOffset(new Vector2(0, 200))
                                .WithText("New Game")
                                .WithButtonAction(Play)
                                .BuildButton());

        buttons.Add(buttonBuilder.WithOffset(new Vector2(0, 280))
                                .WithText("Customise")
                                .WithButtonAction(TransitionManager.ChangeGameState)
                                .WithButtonInfo(GameState.CUSTOM)
                                .BuildButton());

        continueButton = buttonBuilder.WithOffset(new Vector2(0, 120))
                                    .WithText("Continue")
                                    .WithAvailable(GameGlobals.gameInProgress)
                                    .WithButtonInfo(GameState.GAME_PLAY)
                                    .BuildButton();

        title = new TextComponentBuilder().WithTextList(new() { "A Chip Off", "The Old Blocks"} ).WithFont(Fonts.defaultFont108).WithOffset(new(0,-100)).BuildMultiLine();
        title.effect = Effects.rainbow;
    }

    public virtual void Update()
    {
        foreach (Button button in buttons)
        {
            button.Update();
        }
        continueButton.isAvailable = GameGlobals.gameInProgress;
        continueButton.Update();
        title.Update();
    }

    private void Play(object SENDER, object INFO)
    {
        Globals.reset(null, null);
        TransitionManager.ChangeGameState(null, GameState.GAME_PLAY);
    }

    public virtual void Draw()
    {
        foreach (Button button in buttons)
        {
            button.Draw();
        }
        continueButton.Draw();
        title.Draw();
    }
}