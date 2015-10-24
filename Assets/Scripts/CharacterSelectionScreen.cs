using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class CharacterSelectionScreen : MonoBehaviour
{
    [SerializeField]
    TitleScreen TitleScreen;

    public List<PlayerInspector> Inspectors = new List<PlayerInspector>();

    public void Open()
    {
        gameObject.SetActive(true);
        OpenDefaultOptions();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void BackButton()
    {
        GameObject.FindObjectOfType<TitleScreen>().Open();
        Close();
    }

    public void StartButton()
    {
        //todo
    }


    public void OpenDefaultOptions()
    {
        int numberOfJoysticks = Input.GetJoystickNames().Length;

        if (numberOfJoysticks < 1)
        {
            //One player
            for (int i = 1; i < Inspectors.Count; i++)
            {
                Inspectors[i].ChooseNothing();
            }

            Inspectors[0].ChooseControl(GameManager.Instance.GetControlScheme("Keyboard Right"));
            Inspectors[0].ChooseCharacter(GameManager.Instance.References.AvailableCharacters[0]);
        }
        else if (numberOfJoysticks == 1)
        {
            //Two players
            
            Inspectors[0].ChooseControl(GameManager.Instance.GetControlScheme("Keyboard Right"));
            Inspectors[0].ChooseCharacter(GameManager.Instance.References.AvailableCharacters[0]);

            if (Inspectors.Count > 1)
            {
                Inspectors[1].ChooseControl(GameManager.Instance.GetControlScheme("Joystick 1"));
                Inspectors[1].ChooseCharacter(GameManager.Instance.References.AvailableCharacters[1]);
            }

            for (int i = 2; i < Inspectors.Count; i++)
            {
                Inspectors[i].ChooseNothing();
            }
        }
        else if (numberOfJoysticks >= 2)
        {
            //Four players
            for (int i = 0; i < Inspectors.Count; i++)
            {
                Inspectors[i].ChooseControl(GameManager.Instance.ControlSchemes[i]);
                Inspectors[i].ChooseCharacter(GameManager.Instance.References.AvailableCharacters[0]);
            }
        }
    }

}
