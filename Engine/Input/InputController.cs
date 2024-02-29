public class InputController
{
    public static bool Left() => Globals.keyboard.GetPress("A") || Globals.keyboard.GetPress("Left");

    public static bool Right() => Globals.keyboard.GetPress("D") || Globals.keyboard.GetPress("Right");
    
    public static bool Up() => Globals.keyboard.GetPress("W") || Globals.keyboard.GetPress("Up");

    public static bool Down() => Globals.keyboard.GetPress("S") || Globals.keyboard.GetPress("Down");

    public static bool Confirm() => Globals.keyboard.GetSinglePress("Enter");

    public static bool Back() => Globals.keyboard.GetSinglePress("Back");
}