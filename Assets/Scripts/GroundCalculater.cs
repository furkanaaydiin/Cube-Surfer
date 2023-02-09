using UnityEngine;

public class GroundCalculater : MonoBehaviour
{
    public Vector3 lastSpawnPos;
    [SerializeField] private BoxCollider boxCollider;
    private void Awake()
    {
        CalculateLastSpawnPos();
    }
    private void CalculateLastSpawnPos()
    {
        lastSpawnPos = boxCollider.bounds.center+ boxCollider.transform.forward * boxCollider.bounds.extents.z* 1.5f;
    }
    private void OnDrawGizmos()
    {
        Color color = Color.magenta;
        color.a = 0.72F;
        Gizmos.color = color;
        Gizmos.DrawCube(boxCollider.bounds.center,boxCollider.bounds.size+Vector3.one*0.1f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(lastSpawnPos,0.2f);

    }
}
