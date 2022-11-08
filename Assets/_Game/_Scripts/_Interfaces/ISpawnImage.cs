using UnityEngine;

public interface ISpawnImage
{
    public GameObject Image { get; }
    GameObject SpawnImage(Vector3 spawnPosition);
}
