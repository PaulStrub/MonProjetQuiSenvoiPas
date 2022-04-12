using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : Item7
{
    protected override void comportement(Collider2D collision)
    {
        inventory.Instance.addCoin();
        this.uiManager.changeCoin();
        Destroy(gameObject);
    }

}
