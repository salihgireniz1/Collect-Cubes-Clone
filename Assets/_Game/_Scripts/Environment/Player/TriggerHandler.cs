using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ITriggerPlayer triggerRespond))
        {
            triggerRespond.OnTrigger();
        }
    }
}
