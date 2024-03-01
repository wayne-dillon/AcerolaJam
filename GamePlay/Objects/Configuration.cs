using System.Collections.Generic;

public struct Configuration
{
    public Dictionary<Coordinate, bool> coordinates;
    public int originDepth;
    public int originLeft;
    public int originRight;

    public Configuration(Dictionary<Coordinate, bool> COORDS, int DEPTH, int LEFT, int RIGHT)
    {
        coordinates = COORDS;
        originDepth = DEPTH;
        originLeft = LEFT;
        originRight = RIGHT;
    }
}
