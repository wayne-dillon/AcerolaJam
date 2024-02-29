public class EnumHelper
{
    public static Orientation RandomOrientation() => (Orientation)Globals.random.Next(0, 4);
}
