using UnityEngine;

internal interface IInitializePlayer
{
    Vector3 DefaultPosition { get; }
    Vector3 DefaultRotation { get; }
    void Initialize();
}
