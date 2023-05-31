using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create MarimoData")]
public class M_St_database : ScriptableObject
{
    public string levelName;
    public int limitValue;
    public int startValue;
    public int clearValue;
    public int giveFoodValue;
}