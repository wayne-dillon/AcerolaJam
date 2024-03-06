using System.Collections.Generic;

public class GamePlay
{
    private List<Sprite> backdrops;

    private Grid grid;
    private BasePiece currentPiece;
    private BasePiece nextPiece;
    private List<TextComponent> text;
    private TextComponent scoreDisplay;
    private TextComponent highScoreDisplay;
    private MyTimer fallTimer;

    public GamePlay()
    {
    }

    private void Init()
    {
        GameGlobals.gameInProgress = true;
        GameGlobals.scores = new();

        GameGlobals.grid = grid = new Grid();
        GameGlobals.score = 0;
        GameGlobals.fallTime = GameGlobals.baseFallTime;
        fallTimer = new(GameGlobals.fallTime);

        currentPiece = BlockMaker.RandomPiece();
        currentPiece.MoveToGrid();
        nextPiece = BlockMaker.RandomPiece();

        highScoreDisplay = new TextComponentBuilder().WithFont(Fonts.defaultFont36).WithAbsolutePosition(new(100, 180)).WithTextAlignment(Alignment.CENTER_LEFT).Build();
        scoreDisplay = new TextComponentBuilder().WithFont(Fonts.defaultFont36).WithAbsolutePosition(new(100, 360)).WithTextAlignment(Alignment.CENTER_LEFT).Build();
        text = new()
        {
            scoreDisplay,
            highScoreDisplay
        };
        text.Add(new TextComponentBuilder().WithText("Hi-Score:").WithAbsolutePosition(new(100, 120)).WithTextAlignment(Alignment.CENTER_LEFT).Build());
        text.Add(new TextComponentBuilder().WithText("Score:").WithAbsolutePosition(new(100, 300)).WithTextAlignment(Alignment.CENTER_LEFT).Build());

        backdrops = new();
        backdrops.Add(new SpriteBuilder().WithPath("rect").WithDims(new(384,576)).WithColor(Colors.Black).Build());
        backdrops.Add(new SpriteBuilder().WithPath("Panel160x160").WithDims(new(160,160)).WithColor(Colors.Black).WithAbsolutePosition(EnumHelper.ScreenPos(new(18, 5))).Build());
    }

    public void Update()
    {
        if (currentPiece.placed)
        {
            currentPiece = nextPiece;
            currentPiece.MoveToGrid();
            if (currentPiece.CheckForCollision(new(0,0)))
            {
                GameGlobals.gameInProgress = false;
                SFXPlayer.PlaySound(SoundEffects.GAME_OVER);
            }

            nextPiece = BlockMaker.RandomPiece();
        }

        if (GameGlobals.gameInProgress && !GameGlobals.animating)
        {
            fallTimer.UpdateTimer();
            if (InputController.RotateCW()) currentPiece.RotateClockwise();
            if (InputController.RotateCCW()) currentPiece.RotateCounterClockwise();
            if (InputController.Left()) currentPiece.MoveLeft();
            if (InputController.Right()) currentPiece.MoveRight();
            if (InputController.Up())
            {
                bool moved = true;
                while (moved)
                {
                    moved = currentPiece.MoveDown();
                }
                fallTimer.Reset(GameGlobals.fallTime);
            }
            if (InputController.Down() || (GameGlobals.fallTime != 0 && fallTimer.Test()))
            {
                fallTimer.Reset(GameGlobals.fallTime);
                currentPiece.MoveDown();
            }
        }

        grid.Update();
        currentPiece.Update();
        nextPiece.Update();
        highScoreDisplay.Update("" + GameGlobals.highScore);
        scoreDisplay.Update("" + GameGlobals.score);

        foreach (var textItem in text)
        {
            if (textItem != highScoreDisplay && textItem != scoreDisplay) textItem.Update();
        }

        foreach (var drop in backdrops)
        {
            drop.Update();
        }


        foreach (var score in GameGlobals.scores)
        {
            score.Update();
        }
        GameGlobals.scores.RemoveAll(score => score.animations.Count == 0);
    }

    public void Reset(object SENDER, object INFO)
    {
        Init();
    }

    public void Draw()
    {
        foreach (var drop in backdrops)
        {
            drop.Draw();
        }
        grid.Draw();
        currentPiece.Draw();
        nextPiece.Draw();
        foreach (var textItem in text)
        {
            textItem.Draw();
        }

        foreach (var score in GameGlobals.scores)
        {
            score.Draw();
        }
    }
}