using Microsoft.Xna.Framework;

public class EnumHelper
{
    public static Orientation RandomOrientation() => (Orientation)Globals.random.Next(0, 4);

    public static Vector2 ScreenPos(Coordinate coordinate)
    {
        float x = 464 + (coordinate.X * 32);
        float y = 88 + (coordinate.Y * 32);
        return new Vector2(x, y);
    }

    public static TextComponent ScoreText(int score)
    {
        TextComponentBuilder builder = new TextComponentBuilder().WithText("+" + score)
                                                                .WithTransitionable(false)
                                                                .WithAnimation(new FadeOut(1500))
                                                                .WithAnimation(new LinearMove(1500, new(0, 1), 0.1f));

        if (score < 500)
        {
            return builder.WithAbsolutePosition(new(100, 420))
                        .WithFont(Fonts.defaultFont36)
                        .WithTextAlignment(Alignment.CENTER_LEFT)
                        .WithAnimation(new LinearMove(750, new(0,1), 0.1f))
                        .Build();
        }

        TextComponent ret =  builder.WithFont(Fonts.defaultFont108).Build();
        ret.effect = Effects.rainbow;
        return ret;
    }
}
