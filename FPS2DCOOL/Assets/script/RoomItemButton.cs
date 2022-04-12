using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;
using Photon.Pun;

public class RoomItemButton : MonoBehaviour
{
    [SerializeField] TMP_Text roomName;
    public RoomInfo roomInfo;

    public void SetupRoomButton(RoomInfo _info)
    {
        roomName.text = _info.Name;
        roomInfo = _info;
    }

    public void joinRoom()
    {
        MenuManager.Instance2.openMenu("LoadingMenu");
        PhotonNetwork.JoinRoom(roomInfo.Name);
    }
}
