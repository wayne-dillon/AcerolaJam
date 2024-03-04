using System;
using Microsoft.Xna.Framework;

public class UI
{
    private readonly Clickable homeBtn;
    private readonly Clickable settingsBtn;
    private RoundEndOverlay overlay;

    public UI()
    {
        homeBtn = new SpriteBuilder().WithPath("Home")
                                    .WithAbsolutePosition(new Vector2(50, 50))
                                    .WithDims(new Vector2(64, 64))
                                    .WithHoverScale(new(1.1f,1.1f))
                                    .WithButtonAction(TransitionManager.ChangeGameState)
                                    .WithButtonInfo(GameState.MAIN_MENU)
                                    .BuildClickable();
        settingsBtn = new SpriteBuilder().WithPath("Settings")
                                    .WithAbsolutePosition(new Vector2(1230, 50))
                                    .WithDims(new Vector2(64, 64))
                                    .WithHoverScale(new(1.1f, 1.1f))
                                    .WithButtonAction(TransitionManager.ChangeGameState)
                                    .WithButtonInfo(GameState.SETTINGS)
                                    .BuildClickable();

        overlay = new RoundEndOverlay();
    }

    public void Update()
    {
        if (Globals.gameState != GameState.MAIN_MENU)
        {
            homeBtn.Update();
        }
        if (Globals.gameState != GameState.SETTINGS)
        {
            settingsBtn.Update();
        }

        if (Globals.gameState == GameState.GAME_PLAY && !GameGlobals.gameInProgress)
        {
            overlay.Update();
        }
    }

    public void Draw()
    {
        if (Globals.gameState != GameState.MAIN_MENU)
        {
            homeBtn.Draw();
        }
        if (Globals.gameState != GameState.SETTINGS)
        {
            settingsBtn.Draw();
        }


        if (Globals.gameState == GameState.GAME_PLAY && !GameGlobals.gameInProgress)
        {
            overlay.Draw();
        }
    }
}