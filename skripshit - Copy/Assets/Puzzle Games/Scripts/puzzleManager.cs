using UnityEngine;
using System.Collections;

public class puzzleManager : MonoBehaviour {

    public Menu1 currentMenu;

    public void Start()
    {
        ShowMenu(currentMenu);
    }

    public void ShowMenu(Menu1 menu)
    {

        if (currentMenu != null)
            currentMenu.IsOpen = false;


        currentMenu = menu;
        currentMenu.IsOpen = true;
    }
}
