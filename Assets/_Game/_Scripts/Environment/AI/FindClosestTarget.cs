using UnityEngine;

public class FindClosestTarget : MonoBehaviour, IGetTarget
{
    float distance;
    Transform closestCube;
    Collider[] cubesAround;
    private string targetLayerName = "Cube";
    public Transform FindTarget(Transform targetOf)
    {
        distance = Mathf.Infinity;
        cubesAround = Physics.OverlapSphere(targetOf.position, 100f, 1 << LayerMask.NameToLayer(targetLayerName));

        for (int i = 0; i < cubesAround.Length; i++)
        {
            float tempDist = Vector3.Distance(targetOf.position, cubesAround[i].transform.position);
            if (tempDist < distance)
            {
                distance = tempDist;
                closestCube = cubesAround[i].transform;
            }
        }
        return closestCube;
    }
}
