using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLvl : MonoBehaviour
{
    public int coinToHave;
    public int lvl;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (inventory.Instance.coin == coinToHave)
        {
            inventory.Instance.level = lvl;
            inventory.Instance.SavePlayer();
            SceneManager.LoadScene("Menu");
        }
    }
}
