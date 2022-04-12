using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour

{
    public static MenuManager Instance2;
    [SerializeField] Menu[] menus;

    private void Awake()
    {

            Instance2 = this;

    }

    public void openMenu(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        { 
            if(menus[i].name == menuName)
            {
                menus[i].openMenu();
            }
            else
            {
                menus[i].closeMenu();
            }
        }
    }


}
