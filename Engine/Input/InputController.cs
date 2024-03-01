public class InputController
{
    public static bool RotateCW() => Globals.keyboard.GetSinglePress("E") || Globals.keyboard.GetSinglePress("C");

    public static bool RotateCCW() => Globals.keyboard.GetSinglePress("Q") || Globals.keyboard.GetSinglePress("X");

    public static bool Left() => Globals.keyboard.GetSingleOrLongPress("A") || Globals.keyboard.GetSingleOrLongPress("Left");

    public static bool Right() => Globals.keyboard.GetSingleOrLongPress("D") || Globals.keyboard.GetSingleOrLongPress("Right");
    
    public static bool Up() => Globals.keyboard.GetSingleOrLongPress("W") || Globals.keyboard.GetSingleOrLongPress("Up");

    public static bool Down() => Globals.keyboard.GetSingleOrLongPress("S") || Globals.keyboard.GetSingleOrLongPress("Down");

    public static bool Confirm() => Globals.keyboard.GetSinglePress("Enter");

    public static bool Back() => Globals.keyboard.GetSinglePress("Back");
}