using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMultiplyTargets : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;
    public Transform playerPos;
    private Vector3 velocity;
    public float SmoothTime;
     void LateUpdate()
    {
        if (targets.Count == 0)
        {
            Vector3 newPosition = new Vector3(playerPos.position.x, playerPos.position.x, playerPos.position.x) + offset;
            transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, SmoothTime);

        }
        else
        {
            Vector3 centerPoint = GetCenterPoint();
            Vector3 newPosition = centerPoint + offset;
            transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, SmoothTime);

        }
    }
    Vector3 GetCenterPoint()
    {
        if(targets.Count == 1)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}
