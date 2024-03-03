using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class CustomGameMenu
{
    private readonly List<TextComponent> text = new();
    private readonly List<LinkedCheckbox> speedBoxes = new(), increaseBoxes = new(), aberrationBoxes = new();

    private enum Level
    {
        OFF,
        LOW,
        MEDIUM,
        HIGH
    }

    private Dictionary<Level, int> speeds = new()
    {
        { Level.OFF, 0 },
        { Level.LOW, 1500 },
        { Level.MEDIUM, 1000 },
        { Level.HIGH, 750 }
    };

    private Dictionary<Level, int> increases = new()
    {
        { Level.OFF, 0 },
        { Level.LOW, 15 },
        { Level.MEDIUM, 10 },
        { Level.HIGH, 5 }
    };

    private Dictionary<Level, int> aberrations = new()
    {
        { Level.OFF, 0 },
        { Level.LOW, 10 },
        { Level.MEDIUM, 30 },
        { Level.HIGH, 70 }
    };

    public CustomGameMenu()
    {
        text.Add(new TextComponentBuilder().WithText("Block Fall Speed")
                                            .WithTextAlignment(Alignment.CENTER_LEFT)
                                            .WithOffset(new Vector2(-450, -50))
                                            .Build());
        text.Add(new TextComponentBuilder().WithText("Speed Increase Rate")
                                            .WithTextAlignment(Alignment.CENTER_LEFT)
                                            .WithOffset(new Vector2(-450, 50))
                                            .Build());
        text.Add(new TextComponentBuilder().WithText("Aberration Frequency")
                                            .WithTextAlignment(Alignment.CENTER_LEFT)
                                            .WithOffset(new Vector2(-450, 150))
                                            .Build());

        text.Add(new TextComponentBuilder().WithText("Off")
                                            .WithTextAlignment(Alignment.CENTER)
                                            .WithOffset(new Vector2(100, -100))
                                            .Build());
        text.Add(new TextComponentBuilder().WithText("Low")
                                            .WithTextAlignment(Alignment.CENTER)
                                            .WithOffset(new Vector2(200, -100))
                                            .Build());
        text.Add(new TextComponentBuilder().WithText("Mid")
                                            .WithTextAlignment(Alignment.CENTER)
                                            .WithOffset(new Vector2(300, -100))
                                            .Build());
        text.Add(new TextComponentBuilder().WithText("High")
                                            .WithTextAlignment(Alignment.CENTER)
                                            .WithOffset(new Vector2(400, -100))
                                            .Build());

        speedBoxes.Add(new SpriteBuilder().WithOffset(new(100, -50))
                                        .WithButtonAction((sender, info) => { GameGlobals.baseFallTime = speeds[Level.OFF]; })
                                        .WithChecked(GameGlobals.baseFallTime == speeds[Level.OFF])
                                        .BuildLinkedCheckbox());
        speedBoxes.Add(new SpriteBuilder().WithOffset(new(200, -50))
                                        .WithButtonAction((sender, info) => { GameGlobals.baseFallTime = speeds[Level.LOW]; })
                                        .WithChecked(GameGlobals.baseFallTime == speeds[Level.LOW])
                                        .BuildLinkedCheckbox());
        speedBoxes.Add(new SpriteBuilder().WithOffset(new(300, -50))
                                        .WithButtonAction((sender, info) => { GameGlobals.baseFallTime = speeds[Level.MEDIUM]; })
                                        .WithChecked(GameGlobals.baseFallTime == speeds[Level.MEDIUM])
                                        .BuildLinkedCheckbox());
        speedBoxes.Add(new SpriteBuilder().WithOffset(new(400, -50))
                                        .WithButtonAction((sender, info) => { GameGlobals.baseFallTime = speeds[Level.HIGH]; })
                                        .WithChecked(GameGlobals.baseFallTime == speeds[Level.HIGH])
                                        .BuildLinkedCheckbox());
        foreach (var speed in speedBoxes)
        {
            speed.SetLinkedList(speedBoxes);
        }

        increaseBoxes.Add(new SpriteBuilder().WithOffset(new(100, 50))
                                        .WithButtonAction((sender, info) => { GameGlobals.increaseThreshold = increases[Level.OFF]; })
                                        .WithChecked(GameGlobals.increaseThreshold == increases[Level.OFF])
                                        .BuildLinkedCheckbox());
        increaseBoxes.Add(new SpriteBuilder().WithOffset(new(200, 50))
                                        .WithButtonAction((sender, info) => { GameGlobals.increaseThreshold = increases[Level.LOW]; })
                                        .WithChecked(GameGlobals.increaseThreshold == increases[Level.LOW])
                                        .BuildLinkedCheckbox());
        increaseBoxes.Add(new SpriteBuilder().WithOffset(new(300, 50))
                                        .WithButtonAction((sender, info) => { GameGlobals.increaseThreshold = increases[Level.MEDIUM]; })
                                        .WithChecked(GameGlobals.increaseThreshold == increases[Level.MEDIUM])
                                        .BuildLinkedCheckbox());
        increaseBoxes.Add(new SpriteBuilder().WithOffset(new(400, 50))
                                        .WithButtonAction((sender, info) => { GameGlobals.increaseThreshold = increases[Level.HIGH]; })
                                        .WithChecked(GameGlobals.increaseThreshold == increases[Level.HIGH])
                                        .BuildLinkedCheckbox());
        foreach (var increase in increaseBoxes)
        {
            increase.SetLinkedList(increaseBoxes);
        }

        aberrationBoxes.Add(new SpriteBuilder().WithOffset(new(100, 150))
                                        .WithButtonAction((sender, info) => { GameGlobals.aberrationPerc = aberrations[Level.OFF]; })
                                        .WithChecked(GameGlobals.aberrationPerc == aberrations[Level.OFF])
                                        .BuildLinkedCheckbox());
        aberrationBoxes.Add(new SpriteBuilder().WithOffset(new(200, 150))
                                        .WithButtonAction((sender, info) => { GameGlobals.aberrationPerc = aberrations[Level.LOW]; })
                                        .WithChecked(GameGlobals.aberrationPerc == aberrations[Level.LOW])
                                        .BuildLinkedCheckbox());
        aberrationBoxes.Add(new SpriteBuilder().WithOffset(new(300, 150))
                                        .WithButtonAction((sender, info) => { GameGlobals.aberrationPerc = aberrations[Level.MEDIUM]; })
                                        .WithChecked(GameGlobals.aberrationPerc == aberrations[Level.MEDIUM])
                                        .BuildLinkedCheckbox());
        aberrationBoxes.Add(new SpriteBuilder().WithOffset(new(400, 150))
                                        .WithButtonAction((sender, info) => { GameGlobals.aberrationPerc = aberrations[Level.HIGH]; })
                                        .WithChecked(GameGlobals.aberrationPerc == aberrations[Level.HIGH])
                                        .BuildLinkedCheckbox());
        foreach (var aberration in aberrationBoxes)
        {
            aberration.SetLinkedList(aberrationBoxes);
        }
    }

    public void Update()
    {
        foreach (var line in text)
        {
            line.Update();
        }
        foreach (var box in speedBoxes)
        {
            box.Update();
        }
        foreach (var box in increaseBoxes)
        {
            box.Update();
        }
        foreach (var box in aberrationBoxes)
        {
            box.Update();
        }
    }

    public void Draw()
    {
        foreach (var line in text)
        {
            line.Draw();
        }
        foreach (var box in speedBoxes)
        {
            box.Draw();
        }
        foreach (var box in increaseBoxes)
        {
            box.Draw();
        }
        foreach (var box in aberrationBoxes)
        {
            box.Draw();
        }
    }
}