using System.Collections.Generic;

public class GamePlay
{
    private List<LinkedButton> panels;
    private Sprite backdrop;

    private Grid grid;
    private BasePiece currentPiece;
    private Dictionary<int, BasePiece> nextPieces;
    private List<TextComponent> text;
    private TextComponent scoreDisplay;
    private TextComponent highScoreDisplay;
    private TextComponent speedLevelDisplay;
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
        GameGlobals.speedLevel = 1;
        GameGlobals.fallTime = GameGlobals.baseFallTime;
        fallTimer = new(GameGlobals.fallTime);

        currentPiece = BlockMaker.RandomPiece(0);
        currentPiece.MoveToGrid();
        nextPieces = new();
        for (int i = 0; i < 3; i++)
        {
            nextPieces.Add(i, BlockMaker.RandomPiece(i));
        }

        highScoreDisplay = new TextComponentBuilder().WithFont(Fonts.defaultFont36).WithAbsolutePosition(new(100, 180)).WithTextAlignment(Alignment.CENTER_LEFT).Build();
        scoreDisplay = new TextComponentBuilder().WithFont(Fonts.defaultFont36).WithAbsolutePosition(new(100, 360)).WithTextAlignment(Alignment.CENTER_LEFT).Build();
        speedLevelDisplay = new TextComponentBuilder().WithFont(Fonts.defaultFont36).WithAbsolutePosition(new(100, 540)).WithTextAlignment(Alignment.CENTER_LEFT).Build();
        text = new()
        {
            scoreDisplay,
            highScoreDisplay,
            speedLevelDisplay
        };
        text.Add(new TextComponentBuilder().WithText("Hi-Score:").WithAbsolutePosition(new(100, 120)).WithTextAlignment(Alignment.CENTER_LEFT).Build());
        text.Add(new TextComponentBuilder().WithText("Score:").WithAbsolutePosition(new(100, 300)).WithTextAlignment(Alignment.CENTER_LEFT).Build());
        text.Add(new TextComponentBuilder().WithText("Level:").WithAbsolutePosition(new(100, 480)).WithTextAlignment(Alignment.CENTER_LEFT).Build());

        panels = new();
        SpriteBuilder panelBuilder = new SpriteBuilder().WithPath("Panel160x160")
                                                        .WithDims(new(160, 160))
                                                        .WithButtonAction(SetNextIndex)
                                                        .WithColor(Colors.Black);

        panels.Add(panelBuilder.WithAbsolutePosition(EnumHelper.ScreenPos(new(18, 9))).WithButtonInfo(1).BuildLinkedButton());
        panels.Add(panelBuilder.WithAbsolutePosition(EnumHelper.ScreenPos(new(18, 15))).WithButtonInfo(2).BuildLinkedButton());
        panels.Add(panelBuilder.WithAbsolutePosition(EnumHelper.ScreenPos(new(18, 3))).WithButtonInfo(0).WithAvailable(false).BuildLinkedButton());
        foreach (LinkedButton button in panels)
        {
            button.SetLinkedList(panels);
        }

        backdrop = new SpriteBuilder().WithPath("rect").WithDims(new(384, 576)).WithColor(Colors.Black).Build();
    }

    public void Update()
    {
        if (currentPiece.placed)
        {
            currentPiece = nextPieces[GameGlobals.nextPieceIndex];
            currentPiece.MoveToGrid();
            if (currentPiece.CheckForCollision(new(0,0)))
            {
                GameGlobals.gameInProgress = false;
                SFXPlayer.PlaySound(SoundEffects.GAME_OVER);
            }

            nextPieces[GameGlobals.nextPieceIndex] = BlockMaker.RandomPiece(GameGlobals.nextPieceIndex);
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
        for (int i = 0; i < 3; i++)
        {
            nextPieces[i].Update();
        }
        highScoreDisplay.Update("" + GameGlobals.highScore);
        scoreDisplay.Update("" + GameGlobals.score);
        speedLevelDisplay.Update("" + GameGlobals.speedLevel);

        foreach (var textItem in text)
        {
            if (textItem != highScoreDisplay && textItem != scoreDisplay && textItem != speedLevelDisplay) 
                textItem.Update();
        }

        foreach (var panel in panels)
        {
            panel.Update();
        }
        backdrop.Update();

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

    public void SetNextIndex(object SENDER, object INFO)
    {
        if (INFO is int index)
        {
            GameGlobals.nextPieceIndex = index;
        }
    }

    public void Draw()
    {
        foreach (var panel in panels)
        {
            panel.Draw();
        }
        backdrop.Draw();
        grid.Draw();
        currentPiece.Draw();
        for (int i = 0; i < 3; i++)
        {
            nextPieces[i].Draw();
        }
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