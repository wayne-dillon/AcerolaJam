using System.Collections.Generic;

public class GameGlobals
{
    public static Coordinate gridSize = new(12, 18);
    public static bool gameInProgress;

    public static Grid grid;
    public static int score;
    public static int highScore;
    public static int completedRows;

    public static bool animating;
    public static int fallTime;

    public static int aberrationPerc;
}