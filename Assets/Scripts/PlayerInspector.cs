using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class PlayerInspector : MonoBehaviour
{
    public Image Portrait;
    public Text CharacterName;
    public Image ControlScheme;

    public Text ClosedText;
    public Image InsideFrame;

    [HideInInspector]
    public PlayerCharacter ChosenCharacter = null;

    [HideInInspector]
    public ControlScheme ChosenControlScheme = null;

    [SerializeField]
    CharacterSelectionScreen CharacterSelectionScreen;

    public void ChangeCharacterR()
    {
        ChangeCharacter(1);
    }

    public void ChangeCharacterL()
    {
        ChangeCharacter(-1);
    }

    public void ChangeCharacter(int zCount)
    {
        int currentIndex = CurrentCharacterIndex();

        if (currentIndex >= 0)
        {
            currentIndex += zCount;

            if (currentIndex >= GameManager.Instance.References.AvailableCharacters.Count)
            {
                ChooseNothing();
            }
            else if (currentIndex < 0)
            {
                ChooseNothing();
            }
            else
            {
                ChooseCharacter(GameManager.Instance.References.AvailableCharacters[currentIndex]);
            }
        }
        else
        {
            if (zCount > 0)
            {
                ChooseCharacter(GameManager.Instance.References.AvailableCharacters[0]);
                PutFirstAvailableControlScheme();
            }
            else
            {
                ChooseCharacter(GameManager.Instance.References.AvailableCharacters.Last());
                PutFirstAvailableControlScheme();
            }
        }
    }

    int CurrentCharacterIndex()
    {
        if (ChosenCharacter == null)
            return -1;

        return GameManager.Instance.References.AvailableCharacters.FindIndex(x => x == ChosenCharacter);
    }

    public void ChangeControlR()
    {
        int index = GameManager.Instance.ControlSchemes.FindIndex(x => x.Name == ChosenControlScheme.Name);

        index++;

        if (index >= GameManager.Instance.ControlSchemes.Count)
            index = 0;
        if (index < 0)
            index = GameManager.Instance.ControlSchemes.Count - 1;

        ChooseControl(GameManager.Instance.ControlSchemes[index]);
    }

    public void ChangeControlL()
    {
        int index = GameManager.Instance.ControlSchemes.IndexOf(ChosenControlScheme);

        index--;

        if (index >= GameManager.Instance.ControlSchemes.Count)
            index = 0;
        if (index < 0)
            index = GameManager.Instance.ControlSchemes.Count - 1;

        ChooseControl(GameManager.Instance.ControlSchemes[index]);
    }

    public void ChooseCharacter(PlayerCharacter zCharacter)
    {
        if (zCharacter == null)
        {
            ChooseNothing();
            return;
        }

        ChosenCharacter = zCharacter;

        ClosedText.gameObject.SetActive(false);
        InsideFrame.gameObject.SetActive(true);
        ControlScheme.transform.parent.gameObject.SetActive(true);
        Portrait.gameObject.SetActive(true);


        Portrait.sprite = zCharacter.Portrait;
        CharacterName.text = zCharacter.Name;
    }

    public void ChooseControl(ControlScheme zControlscheme)
    {
        if (zControlscheme == null)
        {
            ControlScheme.transform.parent.gameObject.SetActive(false);
            ControlScheme.sprite = null;
            return;
        }

        ChosenControlScheme = zControlscheme;

        ControlScheme.transform.parent.gameObject.SetActive(true);
        ControlScheme.sprite = zControlscheme.Icon;
    }

    public void ChooseNothing()
    {
        ChosenCharacter = null;
        ChosenControlScheme = null;

        Portrait.sprite = null;
        ControlScheme.transform.parent.gameObject.SetActive(false);
        ControlScheme.sprite = null;
        ClosedText.gameObject.SetActive(true);
        InsideFrame.gameObject.SetActive(false);
        Portrait.gameObject.SetActive(false);

        CharacterName.text = "NO PLAYER";
        ClosedText.text = "";
    }

    void PutFirstAvailableControlScheme()
    {
        int myIndex = CharacterSelectionScreen.Inspectors.IndexOf(this);
        if (myIndex < 0)
        {
            Debug.LogError("Unexpected error");
            return;
        }

        ChooseControl(GameManager.Instance.ControlSchemes[myIndex]);
    }
}
