using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchMenusPC : MonoBehaviour
{
    public GameObject CMDGUI;
    public GameObject PCGUI;
    public GameObject EmailGUI;
    public GameObject fullPCGUI;

    public void goToCMD()
    {
        CMDGUI.active = true;
        PCGUI.active = false;
        EmailGUI.active = false;
    }
    public void goBacktoMain()
    {
        CMDGUI.active = false;
        PCGUI.active = true;
        EmailGUI.active = false;
    }

    public void goToEmail()
    {
        CMDGUI.active = false;
        PCGUI.active = false;
        EmailGUI.active = true;
    }

    public void closePCGUI()
    {
        fullPCGUI.active = false;
    }

    public void openFullGUI()
    {
        Debug.Log("Button pressed");
        fullPCGUI.active = true;
    }
}
