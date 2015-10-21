using UnityEngine;
using System.Collections;

public class SkeletonGraphics : Graphics
{
    public override void Animate(Animations zAnimation = Animations.MELEE_MID)
    {
        switch (zAnimation)
        {
            case Animations.RANGE_LEFT:
            case Animations.RANGE_RIGHT:
            case Animations.MELEE_QUICK:
            case Animations.MELEE_MID:
            case Animations.MELEE_SLOW:
                Animator.SetTrigger("AttackMelee");
                break;

            case Animations.START_WALKING:
                Animator.SetBool("StartWalking", true);
                break;
            case Animations.IDLE:
                Animator.SetBool("StartWalking", false);
                break;
            case Animations.DAMAGED:
                Animator.SetTrigger("Damaged");
                break;
        }
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        Debug.Log("Walking");
    //        Animate(Animations.START_WALKING);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        Animate(Animations.IDLE);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Alpha3))
    //    {
    //        Animate(Animations.MELEE_MID);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Alpha4))
    //    {
    //        Animate(Animations.DAMAGED);
    //    }
    //}
}
