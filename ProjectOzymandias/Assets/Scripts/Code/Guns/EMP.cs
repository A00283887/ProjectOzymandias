using UnityEngine;
using System.Collections;

public class EMP : MonoBehaviour
{
    public float maxPullRadius = 10f; // Maximum radius within which to affect objects
    public float expansionSpeed = 1f; // How fast the EMP effect expands

    void Start()
    {
        StartCoroutine(PulseEMP());
    }

    IEnumerator PulseEMP()
    {
        float currentRadius = 0f; // Current radius starts from 0
        while (currentRadius < maxPullRadius)
        {
            currentRadius += expansionSpeed * Time.deltaTime;
            // Visualize the EMP effect expansion here (optional)
            ApplyEMPEffect(currentRadius);
            yield return null; // Wait for the next frame
        }

        // Optionally destroy the EMP GameObject after full expansion
        Destroy(gameObject);

    }

    void ApplyEMPEffect(float radius)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (var collider in colliders)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                continue;

            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                DisableComponents(collider);
            }
        }
    }

    void DisableComponents(Collider2D collider)
    {
        var balanceComponent = collider.GetComponent<Balance>();
        if (balanceComponent != null)
        {
            balanceComponent.enabled = false;
        }

        var enemyGunComponent = collider.GetComponent<EnemyShooting>();
        if (enemyGunComponent != null)
        {
            enemyGunComponent.enabled = false;
        }

        if (collider.gameObject.name == "RightHandEnemy")
        {
            Destroy(collider.gameObject);
        }
    }
}