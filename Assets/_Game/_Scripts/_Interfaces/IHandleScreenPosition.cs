using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandleScreenPosition
{
    public Camera Cam { get; }
    Vector3 GetScreenPositionOfObject(Vector3 worldPosition);
}
