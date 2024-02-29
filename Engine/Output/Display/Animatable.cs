using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class Animatable
{
    public float rot;
    public Color color;
    private Vector2 pos;
    public Vector2 dims, baseDims;
    public Alignment alignment;
    public List<IAnimate> animations;
    public Effect effect;
    public bool isTransitionable;

    public Vector2 Pos 
    { 
        get { return pos; } 
        set {
            pos = value;
        }
    }

    public Animatable(Color COLOR, Vector2 POS, Vector2 DIMS, Alignment ALIGNMENT, List<IAnimate> ANIMATIONS, bool ISTRANSITIONABLE)
    {
        color = ISTRANSITIONABLE ? new Color(COLOR, 0) : COLOR;
        Pos = POS;
        dims = DIMS;
        baseDims = dims;
        alignment = ALIGNMENT;
        animations = ANIMATIONS ?? new();
        isTransitionable = ISTRANSITIONABLE;
    }

    public virtual void Update()
    {
        HandleTransitions();

        foreach (IAnimate animation in animations)
        {
            animation.Update();
            animation.Animate(this);
        }
        animations.RemoveAll(animation => animation.IsComplete());
    }

    private void HandleTransitions()
    {
        if (isTransitionable)
        {
            TransitionManager.animate?.Invoke(this);
        }
    }

    public virtual void Draw()
    {

    }
}