using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BrainEnemy : Brain
{
    public float VisionRange = 10;
    [Range(0, 1)]
    public float AttackRange = 0.1f;

    void Start()
    {
        Character.OnSpawn();
    }

    void Update()
    {
        if (Character.isBusy)
            return;

        BehaviorController();
    }


    protected virtual void BehaviorController()
    {
        Character characterToFollow = GetNearestPlayer(VisionRange);
        if (characterToFollow != null)
        {
            float distanceToPlayer = DistanceToPlayer(characterToFollow);
            if (distanceToPlayer < (VisionRange * AttackRange))
            {
                //Distance to attack
                Character.Locomotor.LookAt(characterToFollow.transform.position);
                Character.Locomotor.Attack();
                return;
            }
            else if (distanceToPlayer < VisionRange)
            {
                //Distance to follow
                FollowPlayer(characterToFollow);
                return;
            }
        }

        Character.Locomotor.Stop();
    }

    float DistanceToPlayer(Character zPlayer)
    {
        return Vector3.Distance(transform.position, zPlayer.transform.position);
    }

    void FollowPlayer(Character zPlayer)
    {
        Vector3 direction = (zPlayer.transform.position - transform.position).normalized;
        direction *= Character.Attributes.Speed;
        Character.Locomotor.Move(direction);
    }

    Character GetNearestPlayer(float range = 0)
    {
        //todo: Fix!
        //List<Character> Players = range > 0 ? GameManager.Instance.PlayerCharacters.Where(x => Vector3.Distance(transform.position, x.transform.position) < range).ToList() : GameManager.Instance.PlayerCharacters;

        //Character nearest = Players[0]; // todo: FIX!

        //return nearest;

        return GameManager.Instance.PlayerCharacters[0];
    }


}
