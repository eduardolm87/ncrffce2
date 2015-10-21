using UnityEngine;
using System.Collections;

public class Attributes : MonoBehaviour
{
    public float Max_Speed = 4;
    public float Max_Attack = 2;
    public int Max_Life = 2;

    [HideInInspector]
    public float Speed = 2;

    [HideInInspector]
    public float Attack = 2;
    
    [HideInInspector]
    public float Life = 20;

    public void Refresh()
    {
        Speed = Max_Speed;
        Attack = Max_Attack;
        Life = Max_Life;
    }
}
