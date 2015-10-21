using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    public Graphics Graphics;
    public Brain Brain;
    public Locomotor Locomotor;
    public Attributes Attributes;

    public enum Statuses { READY, ATTACKING, DAMAGED, DISABLED };
    [HideInInspector]
    public Statuses Status = Statuses.DISABLED;

    [HideInInspector]
    public int playerID = -1;


    public bool isBusy { get { return (Status != Statuses.READY); } }
    public bool isPlayer { get { return playerID > -1; } }



    void Start()
    {
        Attributes.Refresh();
    }

    public virtual void OnSpawn()
    {
        Status = Statuses.READY;
    }

    void OnTriggerEnter(Collider zCollider)
    {
        Hitbox hitbox = zCollider.GetComponent<Hitbox>();
        if (hitbox != null)
        {
            if (hitbox.Owner != this)
            {
                OnHitboxEnter(hitbox);
            }
        }
    }

    void OnHitboxEnter(Hitbox zHitbox)
    {
        Debug.Log(name + " recibe un golpe de " + zHitbox.Owner.name);

        Damage(zHitbox);
    }

    public void Damage(Hitbox zHitboxSource)
    {
        Locomotor.Stop();

        Attributes.Life -= zHitboxSource.Damage;

        if (Attributes.Life < 1)
        {
            Attributes.Life = 0;
            Die();
        }
        else
        {
            Graphics.Animate(Graphics.Animations.DAMAGED);
        }
    }

    public void Die()
    {
        if (isPlayer)
        {
            //todo: player death
            Debug.Log("Player " + playerID + " Killed!");
            return;
        }

        Status = Statuses.DISABLED;
        iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.zero, "time", 0.5f, "easetype", iTween.EaseType.easeInOutQuart, "oncompletetarget", gameObject, "oncomplete", "DieAfterAnimation"));
    }

    void DieAfterAnimation()
    {
        Destroy(gameObject);
    }

}
