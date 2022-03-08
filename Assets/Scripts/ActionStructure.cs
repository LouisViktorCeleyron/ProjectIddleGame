using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


[System.Serializable]
public struct ActionStructure
{
    public string actionName;
    public int diamondCost,goldCost;
    public UnityEvent action;
}
