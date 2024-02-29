using Microsoft.Xna.Framework;

public class LinearMove : IAnimate
{
    private MyTimer timer;
    private Vector2 direction;
    private float speed;

    public LinearMove(int MSEC, Vector2 DIRECTION, float SPEED)
    {
        timer = new MyTimer(MSEC);
        direction = DIRECTION;
        speed = SPEED;
    }

    public void Update()
    {
        timer.UpdateTimer();
    }

    public void Animate(Animatable TARGET)
    {
        TARGET.Pos += direction * speed * Globals.gameTime.ElapsedGameTime.Milliseconds;
    }

    public bool IsComplete() => timer.Test();
}