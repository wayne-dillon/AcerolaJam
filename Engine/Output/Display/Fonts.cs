using Microsoft.Xna.Framework.Graphics;

public class Fonts
{
    public static SpriteFont defaultFont12;
    public static SpriteFont defaultFont18;
    public static SpriteFont defaultFont24;
    public static SpriteFont defaultFont36;
    public static SpriteFont defaultFont54;
    public static SpriteFont defaultFont108;
    public static SpriteFont numberFont;

    public static void Init()
    {
        defaultFont12 = Globals.content.Load<SpriteFont>("Fonts//Bungee12");
        defaultFont18 = Globals.content.Load<SpriteFont>("Fonts//Bungee18");
        defaultFont24 = Globals.content.Load<SpriteFont>("Fonts//Bungee24");
        defaultFont36 = Globals.content.Load<SpriteFont>("Fonts//Bungee36");
        defaultFont54 = Globals.content.Load<SpriteFont>("Fonts//Bungee54");
        defaultFont108 = Globals.content.Load<SpriteFont>("Fonts//Bungee108");
        numberFont = Globals.content.Load<SpriteFont>("Fonts//Bungee18");
    }
}