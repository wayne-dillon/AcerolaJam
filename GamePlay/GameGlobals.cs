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
    public static int baseFallTime = 1000;
    public static int increaseThreshold = 10;
    public static int aberrationPerc = 30;

    public static List<TextComponent> scores;
}