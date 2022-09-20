using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCalculater : MonoBehaviour
{
    public Vector3 lastSpawnPos;
    public BoxCollider BoxCollider;
    private void Awake()
    {
        CalculateLastSpawnPos();
    }
    private void CalculateLastSpawnPos()
    {
        lastSpawnPos = BoxCollider.bounds.center+ BoxCollider.transform.forward*BoxCollider.bounds.extents.z* 1.5f;
    }
    private void OnDrawGizmos()
    {
        Color color = Color.magenta;
        color.a = 0.72F;
        Gizmos.color = color;
        Gizmos.DrawCube(BoxCollider.bounds.center,BoxCollider.bounds.size+Vector3.one*0.1f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(lastSpawnPos,0.2f);

    }
}
