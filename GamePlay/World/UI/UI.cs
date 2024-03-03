using System;
using Microsoft.Xna.Framework;

public class UI
{
    private readonly Clickable homeBtn;
    private RoundEndOverlay overlay;

    public UI()
    {
        homeBtn = new SpriteBuilder().WithPath("rect")
                                    .WithAbsolutePosition(new Vector2(50, 50))
                                    .WithDims(new Vector2(64, 64))
                                    .WithButtonAction(TransitionManager.ChangeGameState)
                                    .WithButtonInfo(GameState.MAIN_MENU)
                                    .BuildClickable();

        overlay = new RoundEndOverlay();
    }

    public void Update()
    {
        if (Globals.gameState != GameState.MAIN_MENU)
        {
            homeBtn.Update();
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

        if (Globals.gameState == GameState.GAME_PLAY && !GameGlobals.gameInProgress)
        {
            overlay.Draw();
        }
    }
}