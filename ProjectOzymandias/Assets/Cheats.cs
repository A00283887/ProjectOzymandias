using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    public SkillTreeUI sku;
    public researchButton researchButton;
    public displayRareMaterials reaMaterials;
    void Start()
    {
        // Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            reaMaterials.rareMaterials += 1;
            researchButton.ResearchPoints += 1;
            sku.SkillPoint += 1;
        }
    }
}