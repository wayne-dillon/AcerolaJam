using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class MainMenu
{
    public List<Button> buttons = new();
    public Button continueButton;

    public MainMenu()
    {
        SpriteBuilder buttonBuilder = new SpriteBuilder().WithScreenAlignment(Alignment.CENTER)
                                                        .WithPath("rect")
                                                        .WithDims(new Vector2(200, 64));

        buttons.Add(buttonBuilder.WithOffset(new Vector2(0, 100))
                                .WithText("New Game")
                                .WithButtonAction(Play)
                                .BuildButton());

        buttons.Add(buttonBuilder.WithOffset(new Vector2(0, 200))
                                .WithText("Customise")
                                .WithButtonAction(TransitionManager.ChangeGameState)
                                .WithButtonInfo(GameState.CUSTOM)
                                .BuildButton());

        continueButton = buttonBuilder.WithOffset(new Vector2(0, 0))
                                    .WithText("Continue")
                                    .WithAvailable(GameGlobals.gameInProgress)
                                    .WithButtonInfo(GameState.GAME_PLAY)
                                    .BuildButton();
    }

    public virtual void Update()
    {
        foreach (Button button in buttons)
        {
            button.Update();
        }
        continueButton.isAvailable = GameGlobals.gameInProgress;
        continueButton.Update();
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
    }
}