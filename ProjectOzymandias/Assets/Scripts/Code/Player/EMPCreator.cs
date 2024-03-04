using System.Collections;
using UnityEngine;

public class EMPCreator : MonoBehaviour
{
    public GameObject empPrefab; // Assign your EMP prefab in the Inspector
    private float cooldownDuration = 30f; // Cooldown duration in seconds
    private bool isCooldown = false; // Tracks whether the EMP can be activated

    void Update()
    {
        // Check for Left Control press and cooldown status
        if (Input.GetKeyDown(KeyCode.LeftControl) && !isCooldown)
        {
            CreateEMP();
            StartCoroutine(Cooldown());
        }
    }

    void CreateEMP()
    {
        // Instantiate the EMP prefab at this object's position (or any desired location)
        Instantiate(empPrefab, transform.position, Quaternion.identity);
        isCooldown = true;
    }

    // Cooldown coroutine to manage EMP activation cooldown
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        isCooldown = false; // Allow EMP activation again
    }
}