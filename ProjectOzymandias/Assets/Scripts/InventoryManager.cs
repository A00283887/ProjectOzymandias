using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Schematic> Schematics = new List<Schematic>();

    public Transform SchematicContent;
    public GameObject InventorySchematic;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Schematic schematic)
    {
        Schematics.Add(schematic);
    }

    public void Remove(Schematic schematic)
    {
        Schematics.Remove(schematic);
    }

    public void ListItems()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        var objectsWithName = allObjects.Where(obj => obj.name == "CraftingItems(Clone)").ToArray();

        foreach (var obj in objectsWithName)
        {
            DestroyImmediate(obj);
        }
        foreach (var schematic in Schematics)
        {
            GameObject obj = Instantiate(InventorySchematic, SchematicContent);
            var schematicName = obj.transform.Find("schematicName").GetComponent<TextMeshProUGUI>();
            var schematicIcon = obj.transform.Find("schematicIcon").GetComponent<Image>();

            schematicName.text = schematic.schematicName;
            schematicIcon.sprite = schematic.icon;

        }
    }

    public void cleanSchematics()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        var objectsWithName = allObjects.Where(obj => obj.name == "CraftingItems(Clone)").ToArray();

        foreach (var obj in objectsWithName)
        {
            DestroyImmediate(obj);
        }
    }

    public List<Schematic> getListOfSchematics()
    {
        return Schematics;
    }
}
