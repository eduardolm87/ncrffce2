using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour
{
    void Update()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            GameManager.Instance.StartGame();
        }
    }

    
}
