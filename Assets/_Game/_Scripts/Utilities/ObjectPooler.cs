using System.Collections.Generic;
using UnityEngine;

public static class ObjectPooler
{
    public static Queue<GameObject> objectPool = new Queue<GameObject>();

    public static readonly string defaultLayer = "Cube";
    private static GameObject poolObject;
    private static float poolCount;

    /// <summary>
    /// Generate a certain number membered pool queue.
    /// </summary>
    /// <param name="info">Pool scriptable object that contains data.</param>
    /// <param name="holder">Parent/holder of spawned cubes.</param>
    public static void GeneratePool(PoolInfo info, Transform holder)
    {
        poolCount = info.poolCount;
        poolObject = info.poolObject;

        for (int i = 0; i < poolCount; i++)
        {
            GameObject obj = MonoBehaviour.Instantiate(poolObject, holder);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }

    /// <summary>
    /// Get an object from pool and activate it.
    /// </summary>
    /// <returns>First member of pool queue.</returns>
    public static GameObject SpawnFromQueue()
    {
        GameObject obj = objectPool.Dequeue();
        ResetObject(obj);
        obj.SetActive(true);
        return obj;
    }

    /// <summary>
    /// Reset queue objects by setting them inactive and making their color as white again.
    /// </summary>
    public static void ResetQueue()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            GameObject obj = objectPool.Dequeue();
            ResetObject(obj);
        }
    }

    /// <summary>
    /// Returns object to it's default settings.
    /// </summary>
    /// <param name="queueObject">Object to reset.</param>
    public static void ResetObject(GameObject queueObject)
    {
        LayerMask layerIndex = LayerMask.NameToLayer(defaultLayer);
        queueObject.layer = layerIndex;
        queueObject.SetActive(false);
        queueObject.transform.localPosition = Vector3.zero;
        queueObject.GetComponent<Renderer>().material.color = Color.white;
        queueObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
        objectPool.Enqueue(queueObject);
    }
}
