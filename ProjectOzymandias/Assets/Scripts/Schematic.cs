using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Upgrade", menuName = "Upgrade/Create New Upgrade")]
public class Schematic : ScriptableObject
{
    public int id;
    public string schematicName;
    public int value;
    public Sprite icon;
    public schematicType SchematicType;

    public enum schematicType
    {
        head,
        chip,
        passiveArm,
        lethalArm,
        boots,
        paint,
        armor,
        TBD
    }


}
