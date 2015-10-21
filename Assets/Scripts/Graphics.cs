using UnityEngine;
using System.Collections;

public class Graphics : MonoBehaviour
{
    [HideInInspector]
    public Character Character;

    public Animator Animator;
    public enum Animations { MELEE_QUICK, MELEE_MID, MELEE_SLOW, RANGE_LEFT, RANGE_RIGHT, START_WALKING, IDLE, DAMAGED };

    public virtual void Animate(Animations zAnimation = Animations.MELEE_MID)
    {

    }

    void Awake()
    {
        Character = GetComponent<Character>();
    }
}
