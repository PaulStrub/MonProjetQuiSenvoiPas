using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D playerRigidbody;
    private PhotonView PV;
    private bool touchGround;
    public float jumpForce;
    public Transform spawn;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3 || collision.gameObject.layer == 6)
        {
            touchGround = true;
        }
        if(collision.gameObject.layer == 7)
        {
            death();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3) {
            touchGround = false;
        }
    }

    public void onCOin(PhotonView coinPv)
    {
        PV.RPC("tookCoin", RpcTarget.All, coinPv.ViewID);
    }

    [PunRPC]
    public void tookCoin (int viewId)
    {
        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.Destroy(FindObjectsOfType<coin>().Where(x => x.GetComponent<PhotonView>().ViewID == viewId).ToArray()[0].gameObject);
        FindObjectsOfType<PlayerManager>().Where(x => x.getPv().IsMine).ToArray()[0].addCoin();
    }

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        PV = GetComponent<PhotonView>();
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
    }

    private void Start()
    {
        if (!PV.IsMine)
            Destroy(playerRigidbody);  
    }

    private void Update()
    {
        if (!PV.IsMine)
            return;
        jump();
        MovePlayer();
        Animation();
    }

    public void Animation()
    {
        if (playerRigidbody.velocity.x == 0)
        {
            gameObject.transform.Find("woman-idle-1").gameObject.SetActive(true);
            gameObject.transform.Find("woman-walk-1").gameObject.SetActive(false);
        }
        else
        {
            gameObject.transform.Find("woman-idle-1").gameObject.SetActive(false);
            gameObject.transform.Find("woman-walk-1").gameObject.SetActive(true);
        }
    }

    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        playerRigidbody.velocity = new Vector2(horizontalInput * speed, playerRigidbody.velocity.y);
        if (playerRigidbody.velocity.x < 0)
        {
            gameObject.transform.Find("woman-idle-1").gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.transform.Find("woman-walk-1").gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (playerRigidbody.velocity.x > 0)
        {
            gameObject.transform.Find("woman-idle-1").gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.transform.Find("woman-walk-1").gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && touchGround ){

            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
        }
    }

    public void death()
    {
        transform.position = FindObjectOfType<SpawnManager>().getSpawn(PhotonNetwork.LocalPlayer.ActorNumber).position;
    }
}
