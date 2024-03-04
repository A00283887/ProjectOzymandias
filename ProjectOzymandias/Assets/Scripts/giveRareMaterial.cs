using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class giveRareMaterial : MonoBehaviour
{
    public GameObject Robot;
    private GameObject computer;
    private GameObject serverRoom;
    public displayRareMaterials rm;
    public bool hasRareMaterial = false;
    public int rareMaterials = 0;
    public int upgrade = 0;

    private void Start()
    {
        computer = GameObject.Find("ComputerFloor0");
        serverRoom = GameObject.Find("Floor2StorageRoom");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject == computer)
        {
            if (hasRareMaterial == true)
            {
                if (upgrade == 0)
                {
                    rm.setRareMaterials();
                    hasRareMaterial = false;
                }
                
                else if (upgrade == 1)
                {
                    rm.giveMultipleRareMaterials();
                    hasRareMaterial = false;
                }
            }
        }

        if (other.gameObject.name == serverRoom.name)
        {
            hasRareMaterial = true;
        }
    }
}
