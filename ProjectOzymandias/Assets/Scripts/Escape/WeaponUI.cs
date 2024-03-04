using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;


public class WeaponUI : MonoBehaviour
{
    public GameObject escC;
    public WeaponrySelector weaponSelector;
    public List<GameObject> weapons;
    private Image thisImage;
    private TMP_Text nameText;
    private TMP_Text description;
    private string descriptionText;
    private TMP_Text chaos;
    private string chaosText;

    public int index;
    void Start()
    {
        weaponSelector = escC.GetComponent<WeaponrySelector>();
        thisImage = transform.GetChild(0).GetComponent<Image>();
        nameText = transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>();
        description = transform.GetChild(1).transform.GetChild(0).GetComponent<TMP_Text>();
        chaos = transform.GetChild(2).transform.GetChild(0).GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        weapons = weaponSelector.weapons;
    }

    public void showImage()
    {
        if (weapons[index] != null)
        {
            thisImage.sprite = weapons[index].transform.GetChild(0).GetComponent<Image>().sprite;
            nameText.text = weapons[index].transform.GetChild(1).GetComponent<TMP_Text>().text;
            string name = weapons[index].transform.GetChild(1).GetComponent<TMP_Text>().text;
            if (name == "Enhanced Perception")
            {
                description.text = "Slows down time when activated.\r\n\r\nAim (Right Click) + Shoot (Left Click)";
                chaos.text = "Ability";
            }
            else if (name == "Grapple Gun")
            {
                description.text = "Allows you to use the grapple hook.\r\n\r\nAim (Left Click) + E (Press W to reel in)";
                chaos.text = "Ability";
            }
            else if (name == "Black Hole Gun")
            {
                description.text = "Shoots a grenade, pulling nearby enemies into it.\r\n\r\nAim (Right Click) + Shoot (Left Click)";
                chaos.text = "5- Chaos p/hit";
            }
            else if (name == "Repulse Grenade Gun")
            {
                description.text = "Shoots a greande which creates a shockwave, launching enemies.\r\n\r\nAim (Right Click) + Shoot (Left Click)";
                chaos.text = "5- Chaos p/hit";
            }
            else if (name == "EMP")
            {
                description.text = "Activates a EMP, disabling enemies in the area.\r\n\r\nPress Q";
                chaos.text = "5- Chaos p/hit";
            }
            else if (name == "Machine Gun")
            {
                description.text = "Shoots multiple bullets, killing any enemy on impact.\r\n\r\nAim (Right Click) + Shoot (Left Click)";
                chaos.text = "5+ Chaos p/kill";
            }
            else if (name == "Pistol")
            {
                description.text = "Shoots a lethal bullet, killing any enemy on impact.\r\n\r\nAim (Right Click) + Shoot (Left Click)";
                chaos.text = "5+ Chaos p/kill";
            }
            else if (name == "Rocket Boots")
            {
                description.text = "Allows you to fly.\r\n\r\nHold G";
                chaos.text = "Ability";
            }
            else if (name == "Rocket Launcher")
            {
                description.text = "Shoots an Rocket Propelled Grenade.\r\n\r\nAim (Right Click) + Shoot (Left Click)";
                chaos.text = "5+ Chaos p/kill";
            }
            else if (name == "Shotgun")
            {
                description.text = "Shoots multiple lethal, killing any enemy on impact.\r\n\r\nAim (Right Click) + Shoot (Left Click)";
                chaos.text = "5+ Chaos p/kill";
            }
            else if (name == "Speed Boots")
            {
                description.text = "Increases your speed.\r\n\r\nWalk forward";
                chaos.text = "Ability";
            }

            else if (name == "Tier 1 Armor")
            {
                description.text = "Offers light defence.\r\n\r\nIncreased Armor";
                chaos.text = "Armor";
            }

            else if (name == "Tier 2 Armor")
            {
                description.text = "Offers medium defence.\r\n\r\nIncreased Armor";
                chaos.text = "Armor";
            }

            else if (name == "Tier 3 Armor")
            {
                description.text = "Offers maximum defence.\r\n\r\nnIncreased Armor";
                chaos.text = "Armor";
            }

            else if (name == "Wind Gun")
            {
                description.text = "Sends enemies back by a lot.\r\n\r\nAim (Right Click) + Shoot (Left Click)";
                chaos.text = "5- Chaos p/hit";
            }
        }
        else
        {
            description.text = "";
            chaos.text = "";
            thisImage.sprite = null;
            nameText.text = "Empty Slot";
        }
    }
}
