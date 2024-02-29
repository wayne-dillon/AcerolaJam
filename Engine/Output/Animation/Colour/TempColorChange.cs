using Microsoft.Xna.Framework;

public class TempColorChange : IAnimate
{
    private MyTimer timer;
    private Color tempColor;
    private Color originalColor;

    public TempColorChange(Animatable TARGET, int TIME, Color COLOR)
    {
        timer = new MyTimer(TIME);
        tempColor = COLOR;
        originalColor = TARGET.color;
    }

    public void Update()
    {
        timer.UpdateTimer();
    }  

    public void Animate(Animatable TARGET)
    {
        if (IsComplete())
        {
            TARGET.color = originalColor;
        } else {
            TARGET.color = tempColor;
        }
    }

    public bool IsComplete() => timer.Test();
}