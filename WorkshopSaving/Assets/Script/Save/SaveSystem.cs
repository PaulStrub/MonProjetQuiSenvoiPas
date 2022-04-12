using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveSystem 
{

    public int lvl;
    public SaveSystem()
    {
        lvl = inventory.Instance.level;
    }
}
