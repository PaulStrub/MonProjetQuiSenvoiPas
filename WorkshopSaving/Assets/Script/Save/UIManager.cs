using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public TMP_Text textDeath;
    public TMP_Text textCoin;
    private void Start()
    {
        textCoin.text = inventory.Instance.coin.ToString();
        //textCoin.SetText(System.Convert.ToString(inventory.Instance.coin));

        textDeath.text = inventory.Instance.death.ToString();
        //textDeath.SetText(System.Convert.ToString(stats.Instance.death));
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && inventory.Instance.Inlvl)
        {
            inventory.Instance.Inlvl = false;
            SceneManager.LoadScene("Menu");
        }
    }
    public void changeCoin()
    {
        textCoin.SetText(System.Convert.ToString(inventory.Instance.coin));
    }

    public void printDeath()
    {
        textDeath.SetText(System.Convert.ToString(inventory.Instance.death));
    }

}
