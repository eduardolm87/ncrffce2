using UnityEngine;
using System.Collections;

public class ControlScheme : MonoBehaviour
{
    public string Name = "Keyboard Right";

    public KeyCode Fire1 = KeyCode.I;
    public KeyCode Fire2 = KeyCode.O;
    public KeyCode Fire3 = KeyCode.P;

    public string VerticalAxis = "Vertical";
    public string HorizontalAxis = "Horizontal";


    public enum Keys { Fire1, Fire2, Fire3, HorizontalAxis, VerticalAxis };

    public float GetAxis(Keys zAxis)
    {
        switch (zAxis)
        {
            case Keys.HorizontalAxis:
                return Input.GetAxis(HorizontalAxis);

            case Keys.VerticalAxis:
                return Input.GetAxis(VerticalAxis);
        }

        return 0;
    }

    public bool GetKey(Keys zKey)
    {
        switch (zKey)
        {
            case Keys.Fire1:
                return Input.GetKey(Fire1);

            case Keys.Fire2:
                return Input.GetKey(Fire2);

            case Keys.Fire3:
                return Input.GetKey(Fire3);
        }

        return false;
    }

    public bool GetKeyDown(Keys zKey)
    {
        switch (zKey)
        {
            case Keys.Fire1:
                return Input.GetKeyDown(Fire1);

            case Keys.Fire2:
                return Input.GetKeyDown(Fire2);

            case Keys.Fire3:
                return Input.GetKeyDown(Fire3);
        }

        return false;
    }
}
