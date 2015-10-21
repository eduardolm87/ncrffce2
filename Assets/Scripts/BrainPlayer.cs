using UnityEngine;
using System.Collections;

public class BrainPlayer : Brain
{
    public ControlScheme ControlScheme;


    float inputSensitivity = 0.25f;

    public override void Update()
    {
        base.Update();

        MoveWithPlayerInput();

        AttackWithPlayerInput();
    }

    public void MoveWithPlayerInput()
    {
        //Probably will need more work to make it compatible with many other devices
        float hAxis = ControlScheme.GetAxis(global::ControlScheme.Keys.HorizontalAxis); //Input.GetAxis("Horizontal");
        float vAxis = ControlScheme.GetAxis(global::ControlScheme.Keys.VerticalAxis);//Input.GetAxis("Vertical");



        if (Mathf.Abs(hAxis) > inputSensitivity || Mathf.Abs(vAxis) > inputSensitivity)
        {
            Vector3 movement = Vector3.zero;
            movement.x = hAxis * 2;
            movement.z = vAxis * 2;

            Character.Locomotor.Move(movement);
        }
    }

    public void AttackWithPlayerInput()
    {
        bool fire1 = ControlScheme.GetKey(ControlScheme.Keys.Fire1);
        bool fire2 = ControlScheme.GetKey(ControlScheme.Keys.Fire2);
        bool fire3 = ControlScheme.GetKey(ControlScheme.Keys.Fire3);

        if (fire1)
        {
            Character.Locomotor.Attack();
            Debug.Log("Attack 1");
        }
        else if (fire2)
        {
            Character.Locomotor.Attack();
            Debug.Log("Attack 2");
        }
        else if (fire3)
        {
            Character.Locomotor.Attack();
            Debug.Log("Attack 3");
        }
    }
}
