using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchingSapwn : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        inventory.Instance.switchSapwn(gameObject);
    }
}
