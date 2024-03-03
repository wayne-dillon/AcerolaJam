using System;
using Microsoft.Xna.Framework;

public class RoundEndOverlay
{
    private readonly Button resetBtn;
    private readonly Button backBtn;

    public RoundEndOverlay()
    {
        SpriteBuilder buttonBuilder = new SpriteBuilder().WithPath("rect")
                                                        .WithDims(new Vector2(243, 37));
        resetBtn = buttonBuilder.WithOffset(new Vector2(0, -50))
                            .WithText("Play Again")
                            .WithButtonAction(Globals.reset)
                            .BuildButton();
        backBtn = buttonBuilder.WithOffset(new Vector2(0, 50))
                            .WithText("Main Menu")
                            .WithButtonAction(TransitionManager.ChangeGameState)
                            .WithButtonInfo(GameState.MAIN_MENU)
                            .BuildButton();
    }

    public void Update()
    {
        resetBtn.Update();
        backBtn.Update();
        if (InputController.Confirm()) Globals.reset(null, null);
        if (InputController.Back()) TransitionManager.ChangeGameState(null, GameState.MAIN_MENU);
    }

    public void Draw()
    {
        resetBtn.Draw();
        backBtn.Draw();
    }
}