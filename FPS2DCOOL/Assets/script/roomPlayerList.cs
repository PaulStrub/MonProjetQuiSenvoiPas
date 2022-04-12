using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;


public class roomPlayerList : MonoBehaviourPunCallbacks
{

    private Player player;
    [SerializeField] TMP_Text PlayerName;
    public void setup(Player _player)
    {
        player = _player;
        PlayerName.text = _player.NickName;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (player == newPlayer)
        {
            Destroy(gameObject);
        }
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }
}
