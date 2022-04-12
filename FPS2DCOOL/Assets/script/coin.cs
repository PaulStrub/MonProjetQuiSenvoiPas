using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //si player 
        {
            collision.gameObject.GetComponent<PlayerControler>().onCOin(gameObject.GetComponent<PhotonView>());
        }
    }
}
