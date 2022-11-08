
using UnityEngine;

public class InitializePlayer : MonoBehaviour, IInitializePlayer
{
    public Vector3 DefaultPosition => defaultPosition;
    public Vector3 DefaultRotation => defaultRotation;

    [SerializeField]
    private Vector3 defaultPosition;

    [SerializeField]
    private Vector3 defaultRotation;

    public void Initialize()
    {
        transform.position = defaultPosition;
        transform.rotation = Quaternion.Euler(defaultRotation);
    }
}
