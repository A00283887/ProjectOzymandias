using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour
{
    public bool occupied = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetOccupied()
    {
        return occupied;
    }

    public void SetOccupied(bool o)
    {
        occupied = o;
    }
}
