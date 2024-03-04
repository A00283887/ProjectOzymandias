using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchematicSendToCrafting : MonoBehaviour
{
    public Schematic Schematic;
    public GameObject skillPointsGO;
    public GameObject researchPointsGO;
    public GameObject rareMaterialsGO;

    public int skillPoints;
    public int researchPoints;
    public int rareMaterials;

    private void Update()
    {
        skillPoints = skillPointsGO.GetComponent<SkillTreeUI>().SkillPoint;
        researchPoints = researchPointsGO.GetComponent<researchButton>().ResearchPoints;
        rareMaterials = rareMaterialsGO.GetComponent<displayRareMaterials>().rareMaterials;
    }
    void Pickup()
    {
        if (gameObject.name == "Tier1ArmorCraft")
        {
            if(skillPoints >= 1 && researchPoints >= 1 && rareMaterials >= 1)
            {
                Debug.Log("TIER1CLICKED");
                skillPointsGO.GetComponent<SkillTreeUI>().SkillPoint = skillPointsGO.GetComponent<SkillTreeUI>().SkillPoint - 1;
                researchPointsGO.GetComponent<researchButton>().ResearchPoints = researchPointsGO.GetComponent<researchButton>().ResearchPoints - 1;
                rareMaterialsGO.GetComponent<displayRareMaterials>().rareMaterials = rareMaterialsGO.GetComponent<displayRareMaterials>().rareMaterials - 1;
                InventoryManager.Instance.Add(Schematic);
                gameObject.active = false;

            }

        }

        else if (gameObject.name == "Tier2ArmorCraft")
        {
            if (skillPoints >= 3 && researchPoints >= 3 && rareMaterials >= 3)
            {
                skillPointsGO.GetComponent<SkillTreeUI>().SkillPoint = skillPointsGO.GetComponent<SkillTreeUI>().SkillPoint - 3;
                researchPointsGO.GetComponent<researchButton>().ResearchPoints = researchPointsGO.GetComponent<researchButton>().ResearchPoints - 3;
                rareMaterialsGO.GetComponent<displayRareMaterials>().rareMaterials = rareMaterialsGO.GetComponent<displayRareMaterials>().rareMaterials - 3;
                InventoryManager.Instance.Add(Schematic);
                gameObject.active = false;
            }
        }

        else
        {
            if (skillPoints >= 5 && researchPoints >= 5 && rareMaterials >= 5)
            {
                skillPointsGO.GetComponent<SkillTreeUI>().SkillPoint = skillPointsGO.GetComponent<SkillTreeUI>().SkillPoint - 5;
                researchPointsGO.GetComponent<researchButton>().ResearchPoints = researchPointsGO.GetComponent<researchButton>().ResearchPoints - 5;
                rareMaterialsGO.GetComponent<displayRareMaterials>().rareMaterials = rareMaterialsGO.GetComponent<displayRareMaterials>().rareMaterials - 5;
                InventoryManager.Instance.Add(Schematic);
                gameObject.active = false;
            }
                
        }
    }

    public void OnMouseDown()
    {
        Pickup();
    }
}
