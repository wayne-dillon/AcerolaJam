using Microsoft.Xna.Framework.Graphics;

public class Effects
{
    public static Effect lines;
    public static Effect bkg;
    public static Effect glitch;
    private float time;

    public Effects()
    {
        lines = Globals.content.Load<Effect>("Effects//Lines");
        bkg = Globals.content.Load<Effect>("Effects//Background");
        glitch = Globals.content.Load<Effect>("Effects//Glitch");
    }

    public void Update()
    {
        time++;
        time %= 100000;
        lines.Parameters["time"]?.SetValue(time / 100000);
        bkg.Parameters["time"]?.SetValue(time / 200);
        glitch.Parameters["time"]?.SetValue(time);
    }
}
