using UnityEngine;
using System.Collections;

public class DwarfGraphics : Graphics
{
    public override void Animate(Animations zAnimation = Animations.MELEE_MID)
    {
        switch (zAnimation)
        {
            case Animations.RANGE_LEFT:
                Animator.SetTrigger("AttackRange");
                break;
            case Animations.RANGE_RIGHT:
                Animator.SetTrigger("AttackRangeB");
                break;
            case Animations.MELEE_QUICK:
                Animator.SetTrigger("AttackMelee");
                break;
            case Animations.MELEE_MID:
                Animator.SetTrigger("AttackMeleeB");
                break;
            case Animations.MELEE_SLOW:
                Animator.SetTrigger("AttackMeleeC");
                break;

            case Animations.START_WALKING:
                if (Animator.GetBool("StartWalking") == false)
                {
                    Animator.SetBool("StartWalking", true);
                }
                break;
            case Animations.IDLE:
                Animator.SetBool("StartWalking", false);
                break;
            case Animations.DAMAGED:
                Animator.SetTrigger("Damaged");
                break;
        }
    }
}
