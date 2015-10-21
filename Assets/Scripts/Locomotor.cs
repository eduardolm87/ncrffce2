using UnityEngine;
using System.Collections;

public class Locomotor : MonoBehaviour
{
    [HideInInspector]
    public Character Character;

    [HideInInspector]
    public Rigidbody Rigidbody;

    [HideInInspector]
    public CapsuleCollider Collider;

    Vector3 previousFrameVelocity = Vector3.zero;

    public enum FacingDirections { LEFT, RIGHT, UP, DOWN };




    void Awake()
    {
        Character = GetComponent<Character>();
        Rigidbody = GetComponent<Rigidbody>();
        Collider = GetComponent<CapsuleCollider>();
    }

    public virtual void Update()
    {
        CheckWalkingAnimation();
    }

    public void Move(Vector3 zDirection)
    {
        if (Character.isBusy)
            return;

        Rigidbody.velocity = zDirection;

        if (zDirection.x > 0 && previousFrameVelocity.x <= 0)
        {
            FaceDirection(FacingDirections.RIGHT);
        }
        else if (zDirection.x < 0 && previousFrameVelocity.x >= 0)
        {
            FaceDirection(FacingDirections.LEFT);
        }

        previousFrameVelocity = zDirection;
    }

    public void Attack()
    {
        if (Character.isBusy)
            return;

        Stop();

        Character.Status = global::Character.Statuses.ATTACKING;

        Character.Graphics.Animate(Graphics.Animations.MELEE_SLOW); //Depends on equipped weapon

        Invoke("AttackSpawnHitbox", 0.3f); //Time depends on equipped weapon
    }

    public void Stop()
    {
        Rigidbody.velocity = Vector3.zero;
    }

    public void FaceDirection(FacingDirections zDirection = FacingDirections.RIGHT)
    {
        switch (zDirection)
        {
            case FacingDirections.RIGHT:
                transform.rotation = Quaternion.Euler(0, 90, 0);

                break;

            case FacingDirections.LEFT:
                transform.rotation = Quaternion.Euler(0, -90, 0);
                break;
        }
    }

    public void LookAt(Vector3 zTarget)
    {
        if (zTarget.x < transform.position.x)
        {
            FaceDirection(FacingDirections.LEFT);
        }
        else if (zTarget.x > transform.position.x)
        {
            FaceDirection(FacingDirections.RIGHT);
        }
    }

    void CheckWalkingAnimation()
    {
        if (Mathf.Abs(Rigidbody.velocity.x) > 0.25f || Mathf.Abs(Rigidbody.velocity.z) > 0.25f)
        {
            Character.Graphics.Animate(Graphics.Animations.START_WALKING);
        }
        else
        {
            Character.Graphics.Animate(Graphics.Animations.IDLE);
        }
    }

    void AttackSpawnHitbox()
    {
        Hitbox hitbox = Hitbox.CreateHitbox(Character, transform.position + transform.forward + Vector3.up, 1.5f, 0.25f);
        hitbox.Rigidbody.velocity = transform.forward;
    }

    
}
