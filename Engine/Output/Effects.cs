using Microsoft.Xna.Framework.Graphics;

public class Effects
{
    public static Effect lines;
    public static Effect bkg;
    public static Effect block;
    public static Effect glitch;
    public static Effect rainbow;
    private float time;

    public Effects()
    {
        lines = Globals.content.Load<Effect>("Effects//Lines");
        bkg = Globals.content.Load<Effect>("Effects//Background");
        block = Globals.content.Load<Effect>("Effects//Block");
        glitch = Globals.content.Load<Effect>("Effects//Glitch");
        rainbow = Globals.content.Load<Effect>("Effects//Rainbow");
    }

    public void Update()
    {
        time++;
        time %= 100000;
        lines.Parameters["time"]?.SetValue(time / 100000);
        bkg.Parameters["time"]?.SetValue(time / 200);
        glitch.Parameters["time"]?.SetValue(time);
        rainbow.Parameters["time"]?.SetValue(time / 20);
    }
}
