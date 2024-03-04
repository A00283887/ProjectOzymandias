using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class WeaponrySelector : MonoBehaviour
{
    public List<bool> weaponry = new List<bool>();
    public List<GameObject> weapons = new List<GameObject>();

    public bool grapplingHook = false;
    public bool emp = false;
    public bool pistol = false;
    public bool assaultRifle = false;
    public bool shotgun = false;
    public bool rocketBoots = false;
    public bool speedBoots = false;
    public bool rocketLauncher = false;
    public bool impulseLauncher = false;
    public bool blackHoleLauncher = false;
    public bool slowMo = false;
    public bool windGun = false;
    public bool armor1 = false;
    public bool armor2 = false;
    public bool armor3 = false;

    public GameObject[] rocketBootsGO;
    public GameObject[] speedBootsGO;
    public GameObject empGO;
    public GameObject slowMoGO;
    public GameObject grapplingHookGO;
    public GameObject pistolGO;
    public GameObject shotgunGO;
    public GameObject assaultRifleGO;
    public GameObject windGunGO;
    public GameObject rocketLauncherGO;
    public GameObject impulseLauncherGO;
    public GameObject blackHoldLauncherGO;
    public GameObject armor1GO;
    public GameObject armor2GO;
    public GameObject armor3GO;

    public GameObject pistolUI;
    public GameObject shotgunUI;
    public GameObject assaultRifleUI;
    public GameObject windGunUI;
    public GameObject rocketLauncherUI;
    public GameObject impulseLauncherUI;
    public GameObject blackHoldLauncherUI;

    public GetComponentOnSquare[] squares;

    public WeaponSwitch ws;
    public PlayerController pc;

    public WeaponUI wu1;
    public WeaponUI wu2;
    public WeaponUI wu3;
    public WeaponUI wu4;
    public WeaponUI wu5;
    public WeaponUI wu6;

    void Start()
    {
        weaponry.Add(grapplingHook);
        weaponry.Add(pistol);
        weaponry.Add(assaultRifle);
        weaponry.Add(shotgun);
        weaponry.Add(rocketBoots);
        weaponry.Add(rocketLauncher);
        weaponry.Add(impulseLauncher);
        weaponry.Add(blackHoleLauncher);
        weaponry.Add(slowMo);
        weaponry.Add(windGun);
        weaponry.Add(armor1); 
        weaponry.Add(armor2);
        weaponry.Add(armor3);
        weaponry.Add(speedBoots);
        weaponry.Add(emp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetGameobjects()
    {
        foreach(GetComponentOnSquare s in  squares) 
        { 
            weapons.Add(s.getObject());
        }
        wu1.showImage();
        wu2.showImage();
        wu3.showImage();
        wu4.showImage();
        wu5.showImage();
        wu6.showImage();
    }

    public void enableSpeedBoots()
    {
        speedBoots = true;
        foreach(GameObject g in speedBootsGO)
        {
            g.SetActive(true);
        }
        pc.setSpeedBoots();
    }

    public void startEscape()
    {
        foreach(GameObject g in weapons)
        {
            if(g != null)
            {
                string name = g.transform.GetChild(1).GetComponent<TMP_Text>().text;
                if (name == "Enhanced Perception")
                {
                    enableSlowMo();
                }
                else if (name == "Grapple Gun")
                {
                    enableGrapplingHook();
                }
                else if (name == "Repulse Grenade Gun")
                {
                    enableImpulseLauncher();
                }
                else if (name == "Black Hole Gun")
                {
                    enableBlackHoleLauncher();
                }
                else if (name == "EMP")
                {
                    enableEMP();
                }
                else if (name == "Machine Gun")
                {
                    enableAssaultRifle();
                }
                else if (name == "Pistol")
                {
                    enablePistol();
                }
                else if (name == "Rocket Boots")
                {
                    enableRocketBoots();
                }
                else if (name == "Rocket Launcher")
                {
                    enableRocketLauncher();
                }
                else if (name == "Shotgun")
                {
                    enableShotgun();
                }
                else if (name == "Speed Boots")
                {
                    enableSpeedBoots();
                }
                                
                else if (name == "Tier 1 Armor")
                {
                    enableArmor1();
                }

                else if (name == "Tier 2 Armor")
                {
                    enableArmor2();
                }

                else if (name == "Tier 3 Armor")
                {
                    enableArmor3();
                }     
                
                else if (name == "Wind Gun")
                {
                    enableWindGun();
                }

            }
        }    
    }

    public void enableEMP()
    {
        emp = true;
        empGO.SetActive(true);
    }

    public void enableGrapplingHook()
    {
        grapplingHook=true;
        grapplingHookGO.SetActive(true);
    }

    public void enablePistol()
    {
        pistol=true;
        pistolGO.SetActive(true);
        ws.AddWeapon(pistolGO, pistolUI);
    }

    public void enableAssaultRifle() 
    {
        assaultRifle=true;
        assaultRifleGO.SetActive(true);
        ws.AddWeapon(assaultRifleGO, assaultRifleUI);
    }
    public void enableShotgun()
    {
        shotgun = true;
        shotgunGO.SetActive(true);
        ws.AddWeapon(shotgunGO, shotgunUI);
    }
    public void enableRocketBoots()
    {
        rocketBoots=true;
        foreach (GameObject g in rocketBootsGO)
        {
            g.SetActive(true);
        }
    }

    public void enableRocketLauncher()
    {
        rocketLauncher=true;
        rocketLauncherGO.SetActive(true);
        ws.AddWeapon(rocketLauncherGO, rocketLauncherUI);
    }

    public void enableImpulseLauncher()
    {
        impulseLauncher=true;
        impulseLauncherGO.SetActive(true);
        ws.AddWeapon(impulseLauncherGO, impulseLauncherUI);
    }

    public void enableBlackHoleLauncher()
    {
        blackHoleLauncher=true;
        blackHoldLauncherGO.SetActive(true);
        ws.AddWeapon(blackHoldLauncherGO, blackHoldLauncherUI);
    }   

    public void enableSlowMo()
    {
        slowMo=true;
        slowMoGO.SetActive(true);
    }

    public void enableWindGun()
    {
        windGun=true;
        windGunGO.SetActive(true);
        ws.AddWeapon(windGunGO, windGunUI);
    }

    public void enableArmor1()
    {
        armor1 = true;
        armor1GO.SetActive(true);
        armor1GO.GetComponent<Shield>().setShieldLevel(25);
    }

    public void enableArmor2()
    {
        armor2 = true;
        armor2GO.SetActive(true);
        armor1GO.GetComponent<Shield>().setShieldLevel(50);
    }

    public void enableArmor3()
    {
        armor3 = true;
        armor3GO.SetActive(true);
        armor1GO.GetComponent<Shield>().setShieldLevel(100);
    }

    public List<GameObject> getWeapons()
    {
        return weapons;
    }
}
