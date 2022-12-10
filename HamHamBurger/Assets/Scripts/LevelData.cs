using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Data", menuName = "LevelData")]
public class LevelData : ScriptableObject
{
    public int TableCount;
    public int CustomerCount;
    public float OrderTime;
    public float CustomerCameTime;
    public float CustomerWaitTime;

}
