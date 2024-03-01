﻿using Microsoft.Xna.Framework;

public class Tile
{
    private Coordinate coordinate;
    public Coordinate Coordinate { get { return coordinate; } set { coordinate = value; } }

    private bool isOccupied;
    public bool IsOccupied { get { return isOccupied; } set { isOccupied = value; } }

    private Sprite background;

    public Tile(Coordinate COORD, Color COLOR)
    {
        coordinate = COORD;

        background = new SpriteBuilder().WithPath("rect")
                                        .WithDims(new Vector2(32, 32))
                                        .WithAbsolutePosition(EnumHelper.ScreenPos(coordinate))
                                        .WithColor(COLOR)
                                        .Build();
    }

    public void Update()
    {
        background.Pos = EnumHelper.ScreenPos(coordinate);
        background.Update();
    }

    public void SetColor(Color COLOR)
    {
        background.color = COLOR;
    }

    public void Draw()
    {
        background.Draw();
    }
}