using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NightTimeLights : MonoBehaviour
{
    public SpriteRenderer[] objects;
    public TilemapRenderer[] tiles;
    public Material day;
    public Material night;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNightTimeLight()
    {
        foreach (SpriteRenderer s in objects)
        {
           s.material = night;
        }

        foreach (TilemapRenderer s in tiles)
        {
            s.material = night;
        }
    }

    public void SetDayTimeLight()
    {
        foreach (SpriteRenderer s in objects)
        {
            s.material = day;
        }

        foreach (TilemapRenderer s in tiles)
        {
            s.material = day;
        }
    }
}
