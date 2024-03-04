using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialLogic : MonoBehaviour
{
    public GameObject pt1;
    public GameObject pt2;
    public GameObject pt3;
    public GameObject pt4;
    public GameObject pt5;
    public GameObject pt6;
    public GameObject pt7;
    public GameObject pt8;
    public GameObject pt9;
    public GameObject pt10;
    public GameObject intro1;
    public GameObject intro2;

    public void continueTutorial()
    {
        pt1.active = false;
        intro1.active = true;
    }

    public void endTutorial()
    {
        pt1.active = false;
    }

    public void part3()
    {
        pt2.active = false;
        pt3.active = true;
    }

    public void part4()
    {
        pt3.active = false;
        pt4.active = true;
    }

    public void part5()
    {
        pt4.active = false;
        pt5.active = true;

    }
    public void part6()
    {
        pt5.active = false;
        pt6.active = true;
    }
    public void part7()
    {
        pt6.active = false;
        pt7.active = true;
    }
    public void part8()
    {
        pt7.active = false;
        pt8.active = true;
    }
    public void part9()
    {
        pt8.active = false;
        pt9.active = true;
    }
    public void part10()
    {
        pt9.active = false;
        pt10.active = true;
    }

    public void finishTutorial()
    {
        pt10.active = false;
    }
    public void introduction()
    {
        intro1.active = false;
        intro2.active = true;
    }
    public void introduction2()
    {
        intro2.active = false;
        pt2.active = true;
    }
}
