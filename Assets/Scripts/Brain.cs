using UnityEngine;
using System.Collections;

public class Brain : MonoBehaviour
{
    [HideInInspector]
    public Character Character;

    void Awake()
    {
        Character = GetComponent<Character>();
    }

    public virtual void Update()
    {

    }
}
