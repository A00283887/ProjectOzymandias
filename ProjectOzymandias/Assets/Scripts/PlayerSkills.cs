using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static SkillTreeUI;
using UnityEngine.UI;
using Pathfinding;

public class PlayerSkills : MonoBehaviour
{
    public int id;
    private bool speed1bool = false;
  

    public TMP_Text TitleText;
    public TMP_Text DescriptionText;

    public int[] ConnectedSkills;

    public void UpdateUI()
    {
        TitleText.text = $"{skillTree.SkillLevels[id]}/{skillTree.SkillCaps[id]}\n{skillTree.SkillNames[id]}";
        DescriptionText.text = $"{skillTree.SkillDescriptions[id]}\nCost: {skillTree.getSkillPointCount()}/1 SP";

        GetComponent<Image>().color = skillTree.SkillLevels[id] >= skillTree.SkillCaps[id] ? Color.cyan : skillTree.SkillPoint >= 1 ? Color.white : Color.gray;

        foreach (var connectedSkill in ConnectedSkills)
        {
            skillTree.SkillList[connectedSkill].gameObject.SetActive(skillTree.SkillLevels[id] > 0);
            skillTree.ConnectorList[connectedSkill].SetActive(skillTree.SkillLevels[id] > 0);
        }
    }

    public void Buy()
    {
        if (skillTree.SkillPoint < 1 || skillTree.SkillLevels[id] >= skillTree.SkillCaps[id]) return;
        skillTree.SkillPoint -= 1;
        skillTree.SkillLevels[id]++;
        skillTree.UpdateAllSkillUI();
    }
}
