using Microsoft.Xna.Framework;

public class HorizontalShake : IAnimate
{
    
    private MyTimer timer;
    private float distance;
    private float speed;
    private bool positive;
    private Vector2 initPos;

    public HorizontalShake(Animatable TARGET, int TIME, float DISTANCE, float SPEED)
    {
        timer = new(TIME);
        distance = DISTANCE;
        speed = SPEED;
        initPos = TARGET.Pos;
    }

    public void Update()
    {
        timer.UpdateTimer();
    }

    public void Animate(Animatable TARGET)
    {
        if (IsComplete())
        {
            TARGET.Pos = initPos;
            return;
        }
        if (TARGET.Pos.X >= initPos.X + distance)
        {
            positive = false;
        }
        if (TARGET.Pos.X <= initPos.X - distance)
        {
            positive = true;
        }
        TARGET.Pos += new Vector2(speed * Globals.gameTime.ElapsedGameTime.Milliseconds * (positive ? 1 : -1), 0);
    }

    public bool IsComplete() => timer.Test();
}