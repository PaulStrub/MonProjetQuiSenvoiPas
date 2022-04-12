using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks
{

    [SerializeField] TMP_Text RoomNameText;
    public static Launcher Instance;
    [SerializeField] Transform RoomImage;
    [SerializeField] GameObject ButtonRoomJoin;
    [SerializeField] TMP_InputField roomNameImputField;
    [SerializeField] Transform PseudoImage;
    [SerializeField] GameObject PSeudoPrefab;
    [SerializeField] Button StartGameButton;
    [SerializeField] TMP_InputField userNameText;

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartGameButton.interactable = true;
        }
    }

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true; //si la scene change elle change pour tout les joueurs de la room
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        MenuManager.Instance2.openMenu("MainMenu");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform transform in RoomImage)
        {
            Destroy(transform.gameObject);
        }
        for (int i =0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList == true){
                continue;
            }
            else
            {
                Instantiate(ButtonRoomJoin, RoomImage).GetComponent<RoomItemButton>().SetupRoomButton(roomList[i]);
            }
        }
    }

    public void CreatRoom()
    {
        if (string.IsNullOrEmpty(roomNameImputField.text))
        {
            return;
        }
        MenuManager.Instance2.openMenu("LoadingMenu");
        PhotonNetwork.CreateRoom(roomNameImputField.text);
    }

    public void launchJoin()
    {
        if (string.IsNullOrEmpty(userNameText.text))
        {
            return;
        }
        MenuManager.Instance2.openMenu("JoinMenu");
    }

    public void launchCreate()
    {
        if (string.IsNullOrEmpty(userNameText.text))
        {
            return;
        }
        MenuManager.Instance2.openMenu("CreateRoom");
    }

    public override void OnJoinedRoom()
    {

        if (PhotonNetwork.IsMasterClient)
        {
            StartGameButton.interactable = true; 
        }
        RoomNameText.text = PhotonNetwork.CurrentRoom.Name;

        Player[] players = PhotonNetwork.PlayerList;//récupere tout les players 
        foreach (Transform transform in PseudoImage)//detruit tout les playres 
        {
            Destroy(transform.gameObject);
        }
        for (int i = 0; i < players.Length; i++)//on recréé tout les joueurs pour refaire l'image (on rafraichit tout le tab)
        {
            GameObject mypseudo = Instantiate(PSeudoPrefab, PseudoImage);
            mypseudo.GetComponent<roomPlayerList>().setup(players[i]);
        }
        MenuManager.Instance2.openMenu("JoinRoom");

    }

    public void setUsername(string actualUsername)     
    {
        PhotonNetwork.NickName = actualUsername;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(PSeudoPrefab, PseudoImage).GetComponent<roomPlayerList>().setup(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {

        Player[] players = PhotonNetwork.PlayerList;//récupere tout les players 
        foreach(Transform transform in PseudoImage)//detruit tout les playres 
        {
            Destroy(transform.gameObject);
        }
        for (int i = 0; i<players.Length; i++)//on recréé tout les joueurs pour refaire l'image (on rafraichit tout le tab)
        {
            GameObject mypseudo = Instantiate(PSeudoPrefab, PseudoImage);
            mypseudo.GetComponent<roomPlayerList>().setup(players[i]);
        }
    }

    public void leftRoom()
    {
        PhotonNetwork.LeaveRoom();
        StartGameButton.interactable = false;
        MenuManager.Instance2.openMenu("JoinMenu");
    }

    public void launchGame()
    {
        MenuManager.Instance2.openMenu("nothing");
        PhotonNetwork.LoadLevel(1);
    }


}
