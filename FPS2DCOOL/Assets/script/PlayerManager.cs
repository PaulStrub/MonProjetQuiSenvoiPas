using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    private PhotonView pv;
    private GameObject Controller;
    private int coin = 0;

    public void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    public void addCoin()
    {
        coin++;
    }

    public PhotonView getPv()
    {
        return pv;
    }

    public void Start()
    {
        if (pv.IsMine)
            createControler();
    }

    public void createControler()
    {
        Transform mySpawn = FindObjectOfType<SpawnManager>().getSpawn(PhotonNetwork.LocalPlayer.ActorNumber);
        PhotonNetwork.Instantiate(Path.Combine("PlayerControler"), mySpawn.position, Quaternion.identity);
    }

    public void die()
    {
        return;
    }
}
