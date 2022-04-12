using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
        public static inventory Instance;
        public int coin = 0;
        public int death = 0;
        public GameObject spawnV;
        public int level = 1;
    public bool Inlvl = false;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        inventory.Instance.LoadData();
    }

    public void addCoin()
    {
        coin++;
    }

    public void addDeath()
    {
        death++;
    }

    public void addLvl()
    {
        level++;
    }

    public void switchSapwn(GameObject newSpawn)
    {
        spawnV = newSpawn;
    }
    public void SavePlayer()
    {
        Saving.SaveFunction();
    }

    public void LoadData()
    {
        SaveSystem data = Saving.LoadSave();

        level = data.lvl;

    }
}
