using UnityEngine;
using System.Collections;

public class Hitbox : MonoBehaviour
{
    public Rigidbody Rigidbody;

    public SphereCollider Collider;

    public Character Owner = null;

    public int Damage = 1;

    public static Hitbox CreateHitbox(Character zOwner, Vector3 zPosition, float zRadius = 0.5f, float zTime = 0)
    {
        GameObject hitboxObj = Instantiate(GameManager.Instance.References.Hitbox.gameObject, zPosition, Quaternion.identity) as GameObject;

        if (!GameManager.Instance.DebugHitbox)
        {
            Destroy(hitboxObj.GetComponent<MeshRenderer>());
        }

        Hitbox hitbox = hitboxObj.GetComponent<Hitbox>();

        hitbox.Owner = zOwner;

        hitboxObj.transform.localScale = Vector3.one * zRadius;
        hitbox.Collider.radius = zRadius;

        if (zTime > 0)
        {
            hitbox.Invoke("DieByTime", zTime);
        }

        return hitbox;
    }

    void DieByTime()
    {
        Destroy(gameObject);
    }
}
