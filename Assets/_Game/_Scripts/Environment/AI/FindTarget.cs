using UnityEngine;

public class FindTarget : MonoBehaviour, IGetTarget
{
    Collider[] cubesAround;
    private string targetLayerName = "Cube";
    Transform IGetTarget.FindTarget(Transform targetOf)
    {
        cubesAround = Physics.OverlapSphere(targetOf.position, 100f, 1 << LayerMask.NameToLayer(targetLayerName));
        if (cubesAround.Length == 0) return null;
        int targetIndex = (int)(cubesAround.Length / 2f) - 1;
        return cubesAround[targetIndex].transform;
    }
}
