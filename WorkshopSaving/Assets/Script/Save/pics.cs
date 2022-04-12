using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pics : Item7
{

    protected override void comportement(Collider2D collision)
    {
        inventory.Instance.addDeath();
        this.uiManager.printDeath();
        collision.gameObject.transform.position = inventory.Instance.spawnV.transform.position;

    }

}
