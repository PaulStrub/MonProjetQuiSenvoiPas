using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class doorButtonReverse : MonoBehaviour
{
    [SerializeField] PhotonView door;
    private PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PV.RPC("openDoor", RpcTarget.AllBuffered);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PV.RPC("closeDoor", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    private void openDoor()
    {
        door.gameObject.SetActive(true);
    }

    [PunRPC]
    private void closeDoor()
    {
        door.gameObject.SetActive(false);
    }
}
