using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHandlePanel
{
    GameObject CurrentPanel { get; }
    void SwitchPanel(GameObject newPanel = null);    
}
