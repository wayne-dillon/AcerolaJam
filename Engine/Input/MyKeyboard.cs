using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

public class MyKeyboard
{
    public KeyboardState newKeyboard, oldKeyboard;

    public List<MyKey> pressedKeys = new(), previousPressedKeys = new();
    public Dictionary<string, MyTimer> heldKeys = new();

    public int longPressTime = 250;

    public MyKeyboard()
    {
    }

    public virtual void Update()
    {
        newKeyboard = Keyboard.GetState();

        GetPressedKeys();
        foreach (var timer in heldKeys)
        {
            if (!pressedKeys.Exists(key => key.key == timer.Key)) timer.Value.ResetToZero();
        }
    }

    public void UpdateOld()
    {
        oldKeyboard = newKeyboard;

        previousPressedKeys = new List<MyKey>();
        foreach (MyKey key in pressedKeys)
        {
            previousPressedKeys.Add(key);
        }
    }


    public bool GetPress(string KEY)
    {

        foreach (MyKey key in pressedKeys)
        {
            if (key.key == KEY)
            {
                return true;
            }
        }

        return false;
    }


    public virtual void GetPressedKeys()
    {
        pressedKeys.Clear();
        foreach (Keys key in newKeyboard.GetPressedKeys())
        {
            MyKey current = new(key.ToString(), 1);
            pressedKeys.Add(current);

            heldKeys.TryAdd(current.key, new MyTimer(longPressTime));
            heldKeys[current.key].UpdateTimer();
        }
    }

    public bool GetSinglePress(string KEY)
    {
        foreach (MyKey key in pressedKeys)
        {
            bool isIn = false;

            foreach (MyKey prevKey in previousPressedKeys)
            {
                if (key.key == prevKey.key)
                {
                    isIn = true;
                    break;
                }
            }

            if (!isIn && (key.key == KEY || key.print == KEY))
            {
                return true;
            }
        }

        return false;
    }

    public bool GetSingleOrLongPress(string KEY)
    {
        if (GetSinglePress(KEY)) return true;

        MyTimer timer;
        if (heldKeys.TryGetValue(KEY, out timer) && timer.Test())
        {
            timer.ResetToZero();
            return true;
        }

        return false;
    }
}
