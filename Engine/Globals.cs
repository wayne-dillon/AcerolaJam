using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

public class Globals
{
    public static int screenHeight, screenWidth;

    public static GameState gameState = GameState.MAIN_MENU;
    public static Random random = new();
    public static SpriteFont defaultFont;
    public static FontSystem fontSystem;

    public static ContentManager content;
    public static GraphicsDeviceManager graphics;
    public static SpriteBatch spriteBatch;

    public static MyKeyboard keyboard;
    public static MyMouseControl mouse;

    public static GameTime gameTime;

    public static bool isNewGame;
    public static EventHandler<object> reset;

    public static float GetDistance(Vector2 pos, Vector2 target) =>
        (float)Math.Sqrt(Math.Pow(pos.X - target.X, 2) + Math.Pow(pos.Y - target.Y, 2));

    public static Vector2 RadialMovement(Vector2 focus, Vector2 pos, float speed)
    {
        speed *= gameTime.ElapsedGameTime.Milliseconds;
        float dist = GetDistance(focus, pos);

        if (dist <= speed)
        {
            return focus - pos;
        }
        else
        {
            return (focus - pos) * speed/dist;
        }
    }

    public static void ReopenSpriteBatch(Effect effect)
    {
        spriteBatch.End();
        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied, effect: effect);
    }

    public static float RotateTowards(Vector2 Pos, Vector2 focus)
    {

        float h, sineTheta, angle;
        if (Pos.Y - focus.Y != 0)
        {
            h = (float)Math.Sqrt(Math.Pow(Pos.X - focus.X, 2) + Math.Pow(Pos.Y - focus.Y, 2));
            sineTheta = (float)(Math.Abs(Pos.Y - focus.Y) / h);
        }
        else
        {
            h = Pos.X - focus.X;
            sineTheta = 0;
        }

        angle = (float)Math.Asin(sineTheta);

        // Drawing diagonial lines here.
        //Quadrant 2
        if (Pos.X - focus.X > 0 && Pos.Y - focus.Y > 0)
        {
            angle = (float)(Math.PI * 3 / 2 + angle);
        }
        //Quadrant 3
        else if (Pos.X - focus.X > 0 && Pos.Y - focus.Y < 0)
        {
            angle = (float)(Math.PI * 3 / 2 - angle);
        }
        //Quadrant 1
        else if (Pos.X - focus.X < 0 && Pos.Y - focus.Y > 0)
        {
            angle = (float)(Math.PI / 2 - angle);
        }
        else if (Pos.X - focus.X < 0 && Pos.Y - focus.Y < 0)
        {
            angle = (float)(Math.PI / 2 + angle);
        }
        else if (Pos.X - focus.X > 0 && Pos.Y - focus.Y == 0)
        {
            angle = (float)Math.PI * 3 / 2;
        }
        else if (Pos.X - focus.X < 0 && Pos.Y - focus.Y == 0)
        {
            angle = (float)Math.PI / 2;
        }
        else if (Pos.X - focus.X == 0 && Pos.Y - focus.Y > 0)
        {
            angle = 0;
        }
        else if (Pos.X - focus.X == 0 && Pos.Y - focus.Y < 0)
        {
            angle = (float)Math.PI;
        }

        return angle;
    }

    public static Vector2 ScalingFactor() => new((float)screenWidth / Coordinates.screenWidth, (float)screenHeight / Coordinates.screenHeight);
}
