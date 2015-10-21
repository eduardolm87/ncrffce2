using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameplayCamera : MonoBehaviour
{
    Vector3 LookatPoint = Vector3.zero;

    Vector3 zDistance = Vector3.zero;

    void Start()
    {
        zDistance = transform.position;
    }

    void Update()
    {
        if (GameManager.Instance.PlayerCharacters.Count < 1)
            return;

        CalculateLookatPoint();
        FollowLookatPoint();
    }

    void FollowLookatPoint()
    {
        Vector3 desiredPosition = LookatPoint + zDistance;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
    }

    void CalculateLookatPoint()
    {
        if (GameManager.Instance.PlayerCharacters.Count > 1)
        {
            float[] allX = GameManager.Instance.PlayerCharacters.ConvertAll(p => p.transform.position.x).ToArray();
            float[] allZ = GameManager.Instance.PlayerCharacters.ConvertAll(p => p.transform.position.z).ToArray();

            float minX = Mathf.Min(allX);
            float maxX = Mathf.Min(allX);
            float minZ = Mathf.Min(allZ);
            float maxZ = Mathf.Min(allZ);

            LookatPoint = new Vector3((maxX - minX) / 2f, 0, (maxZ - minZ) / 2f);
        }
        else
        {
            LookatPoint = GameManager.Instance.PlayerCharacters[0].transform.position;
            LookatPoint.y = 0;
        }
    }
}
