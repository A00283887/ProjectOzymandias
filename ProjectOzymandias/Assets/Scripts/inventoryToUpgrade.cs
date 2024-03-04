using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class inventoryToUpgrade : MonoBehaviour
{
    private GameObject T1Armor;
    private GameObject T2Armor;
    private GameObject T3Armor;
    public  GameObject EMP;
    private GameObject Grapple;
    private GameObject Grav;
    public GameObject Invis;
    private GameObject Laser;
    private GameObject MachineG;
    private GameObject RocketBoots;
    private GameObject RocketLauncher;
    private GameObject StunGun;
    private GameObject SpeedBoots;

    private InventoryManager inventoryManager;
    private List<Schematic> Schematics;

    private GameObject obj;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        Schematics = inventoryManager.getListOfSchematics();
        EMP = GameObject.Find("EMP");
        Invis = GameObject.Find("Invis");
    }

    public void moveToChip()
    {
        foreach (var schematic in Schematics)
        {
            Debug.Log(schematic.schematicName);
            if (schematic.schematicName == "Invisibility")
            {
                Debug.Log(schematic.schematicName);
                Invis.transform.localScale = Vector3.one;
            }
            else if (schematic.schematicName == "Emp Defense")
            {
                Debug.Log(schematic.schematicName);
                EMP.transform.localScale = Vector3.one;
            }
        }
    }
}
