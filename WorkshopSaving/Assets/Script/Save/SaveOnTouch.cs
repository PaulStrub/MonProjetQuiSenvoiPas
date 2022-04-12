using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface myLauncher
{
    abstract void changeLauncher();
}
public class SaveOnTouch : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            inventory.Instance.addCoin();
            Destroy(gameObject);
           
        }
    }
}

class mySave
{

}
