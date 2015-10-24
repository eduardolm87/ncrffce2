using UnityEngine;
using System.Collections;

public class ControlScheme : MonoBehaviour
{
    public string Name = "Keyboard Right";
    public Sprite Icon = null;

    public string Fire1 = "Fire1_KeyboardR";
    public string Fire2 = "Fire2_KeyboardR";
    public string Fire3 = "Fire3_KeyboardR";

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
                return Input.GetAxis(Fire1) > 0;

            case Keys.Fire2:
                return Input.GetAxis(Fire2) > 0;

            case Keys.Fire3:
                return Input.GetAxis(Fire3) > 0;
        }

        return false;
    }



    bool Fire1Down = false;
    bool Fire2Down = false;
    bool Fire3Down = false;
    public bool GetKeyDown(Keys zKey)
    {
        switch (zKey)
        {
            case Keys.Fire1:

                if (Fire1Down) return false;
                else if (Input.GetAxis(Fire1) > 0)
                {
                    Fire1Down = true;
                    return true;
                }

                break;

            case Keys.Fire2:

                if (Fire2Down) return false;
                else if (Input.GetAxis(Fire2) > 0)
                {
                    Fire2Down = true;
                    return true;
                }

                break;

            case Keys.Fire3:

                if (Fire3Down) return false;
                else if (Input.GetAxis(Fire3) > 0)
                {
                    Fire3Down = true;
                    return true;
                }

                break;
        }

        return false;
    }


    void LateUpdate()
    {
        if (Fire1Down && Input.GetAxis(Fire1) <= 0) { Fire1Down = false; }
        if (Fire2Down && Input.GetAxis(Fire2) <= 0) { Fire2Down = false; }
        if (Fire3Down && Input.GetAxis(Fire3) <= 0) { Fire3Down = false; }
    }
}
