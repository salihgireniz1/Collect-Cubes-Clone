using UnityEngine;

interface IHandleMovement 
{
    MovementInfo MovementInfo { get; }
    Rigidbody Body { get; }
    bool CanMove { get; set; }
    void Move();
    void GetMovementInfo();
}
