using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILvl : MonoBehaviour
{


    public void launchLvl(int lvl)
    {
        inventory.Instance.coin = 0;
        inventory.Instance.death = 0;
        inventory.Instance.Inlvl = true;
        SceneManager.LoadScene("Lvl" + lvl);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void ResetData()
    {
        inventory.Instance.level = 1;
        inventory.Instance.SavePlayer();

        SceneManager.LoadScene("Loading");
    }

    private void Start()
    {
        Button buttonLvl2 = GameObject.Find("Button (1)").GetComponent<Button>();
        Button buttonLvl3 = GameObject.Find("Button (2)").GetComponent<Button>();
        if (inventory.Instance.level == 1)
        {
            Debug.Log("je met en false");
            buttonLvl2.interactable = false;
            buttonLvl3.interactable = false;
        }
        else if(inventory.Instance.level == 2)
        {
            buttonLvl2.interactable = true;
            buttonLvl3.interactable = false;
        }
        else
        {
            buttonLvl2.interactable = true;
            buttonLvl3.interactable = true;
        }
    }
}

