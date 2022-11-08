using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fountain Settings", menuName = "Level/Fountain Settings")]
public class FountainInfo : ScriptableObject
{
    public List<Transform> SpawnPoints;
    public float throwForce;
    public float spawnDuration;
    public float fountainObjectSize;
}
