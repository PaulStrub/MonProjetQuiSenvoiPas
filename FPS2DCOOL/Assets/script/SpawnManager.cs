using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawns;

    public Transform getSpawn(int id)
    {
        return spawns[id - 1];
    }
}
