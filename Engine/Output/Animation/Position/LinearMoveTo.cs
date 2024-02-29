using Microsoft.Xna.Framework;

public class LinearMoveTo : IAnimate
{
    private MyTimer timer;
    private Vector2 start;
    private Vector2 end;
    private Vector2 difference;

    public LinearMoveTo(int MSEC, Vector2 START, Vector2 END)
    {
        timer = new MyTimer(MSEC);
        start = START;
        end = END;
        difference = end - start;
    }

    public void Update()
    {
        timer.UpdateTimer();
    }

    public void Animate(Animatable TARGET)
    {
        if (IsComplete())
        {
            TARGET.Pos = end;
        } else {
            TARGET.Pos = start + (difference * ((float)timer.Timer / (float)timer.MSec));
        }
    }

    public bool IsComplete() => timer.Test();
}