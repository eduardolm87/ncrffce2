using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour
{
    [SerializeField]
    CharacterSelectionScreen CharacterSelectionScreen;

    public void PressStart()
    {
        CharacterSelectionScreen.Open();
        Close();
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

}
