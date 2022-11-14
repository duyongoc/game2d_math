using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TurnData
{
    [Space(10)]
    public int level;

    [Space(10)]
    public int maxLevelEasy = 10;
    public int maxLevelMedium = 50;
    public int maxLevelHigh = 100;
}


[CreateAssetMenu(fileName = "Setting", menuName = "Setting/Setting", order = 1)]
public class SettingSO : ScriptableObject
{

    [Space(10)]
    public List<TurnData> turnEasy;
    public List<TurnData> turnMedium;
    public List<TurnData> turnHard;
    public List<TurnData> turnHarder;
    public List<TurnData> nightmare;
}
