using UnityEngine;

public class Cube : MonoBehaviour, ICollectable
{
    public int Amount => amount;

    [SerializeField]
    private int amount;

    [SerializeField]
    private string layer;

    [SerializeField]
    private Color collectedColor;

    private Renderer rend;
    private Rigidbody body;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }
    public void Collect()
    {
        body.velocity = Vector3.zero;
        int layerIndex = LayerMask.NameToLayer(layer);
        gameObject.layer = layerIndex;
        rend.material.color = collectedColor;
        body.velocity = Vector3.zero;
    }
}
