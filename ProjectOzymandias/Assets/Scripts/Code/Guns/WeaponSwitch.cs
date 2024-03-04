using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public List<GameObject> guns = new List<GameObject>(); // Dynamic addition of guns
    public List<GameObject> weaponUI; // Corresponding UI elements for each weapon

    private int currentWeapon = 0; // Index of the currently active weapon

    void Start()
    {
        // Ensure only the first gun and its UI are active at the start, if any guns exist
        if (guns.Count > 0)
        {
            UpdateWeaponActiveState();
        }
    }

    void UpdateWeaponActiveState()
    {
        // Loop through all guns and activate only the current one
        for (int i = 0; i < guns.Count; i++)
        {
            bool isActive = i == currentWeapon;
            guns[i].SetActive(isActive);
            weaponUI[i].SetActive(isActive); // Activate the corresponding UI element
        }
    }

    public void change()
    {
        // Increment the current weapon index
        currentWeapon++;

        // Wrap around if we exceed the number of guns
        if (currentWeapon >= guns.Count)
        {
            currentWeapon = 0;
        }

        // Update the active state of all weapons and UI elements
        UpdateWeaponActiveState();
    }

    // New method to add weapons dynamically
    public void AddWeapon(GameObject newWeapon, GameObject newWeaponUI)
    {
        if (newWeapon != null && !guns.Contains(newWeapon))
        {
            guns.Add(newWeapon);
            weaponUI.Add(newWeaponUI); // Add the corresponding UI element

            // Optionally, deactivate the newly added weapon and its UI if not the first one
            if (guns.Count > 1)
            {
                newWeapon.SetActive(false);
                newWeaponUI.SetActive(false); // Also deactivate the new weapon's UI
            }
        }
    }
}