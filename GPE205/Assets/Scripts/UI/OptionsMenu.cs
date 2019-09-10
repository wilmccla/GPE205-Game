using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject Startmenu;
    public GameObject OptionMenu;

    public void Back()
    {
        OptionMenu.SetActive(false);
        Startmenu.SetActive(true);
    }
}
