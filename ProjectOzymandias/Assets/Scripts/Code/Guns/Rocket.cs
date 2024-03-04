using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rocket : MonoBehaviour
{
    public float pushRadius = 10f; // Radius within which to push objects away
    public float pushForce = 100f; // Strength of the push
    private bool hasPushed = false; // Ensures the push happens only once
    public GameObject particles;

    public ChaosController cc; // Reference to the ChaosController
    private HashSet<GameObject> processedEnemies = new HashSet<GameObject>(); // Track processed enemy GameObjects

    void Start()
    {
        cc = GameObject.Find("EscController").GetComponent<ChaosController>();
    }
    void ApplyRepulsionEffect()
    {
        if (!hasPushed)
        {
            // Find all colliders within the pushRadius
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pushRadius);

            foreach (var collider in colliders)
            {
                if (collider.gameObject.layer != LayerMask.NameToLayer("Player"))
                {
                    // Check if the collider has a Rigidbody2D to ensure we can apply force
                    Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        // Calculate direction from me to target
                        Vector2 forceDirection = collider.transform.position - transform.position;

                        // Apply force on target away from me
                        rb.AddForce(forceDirection.normalized * pushForce * Time.fixedDeltaTime);

                        // Check for and disable the Balance component for 3 seconds
                        DisableBalanceTemporarily(collider.gameObject);

                        // Disable the EnemyShooting component
                        var enemyGunComponent = collider.GetComponent<EnemyShooting>();
                        if (enemyGunComponent != null)
                        {
                            enemyGunComponent.enabled = false;
                        }

                        // Disable HingeJoint2D component, if present
                        var hingeJoint = collider.GetComponent<HingeJoint2D>();
                        if (hingeJoint != null)
                        {
                            hingeJoint.enabled = false;
                        }

                        if (collider.gameObject.name == "RightHandEnemy")
                        {
                            Destroy(collider.gameObject);
                        }

                        StartCoroutine(DestroyGameObjectAfterDelay(collider.gameObject, 2f));
                        GameObject enemyGameObject = collider.transform.root.gameObject;
                        if (!processedEnemies.Contains(enemyGameObject))
                        {
                            processedEnemies.Add(enemyGameObject); // Mark this enemy as processed
                            cc.addProgress(0.05f); // Add progress for this enemy   
                        }
                    }
                }
            }
            hasPushed = true; // Prevent further application of the force
            Instantiate(particles, transform.position, transform.rotation); // Instantiate particles at the position
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<SpriteRenderer>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            //Destroy(gameObject); // Destroy the current GameObject
        }
    }

    void DisableBalanceTemporarily(GameObject target)
    {
        var balanceComponent = target.GetComponent<Balance>();
        if (balanceComponent != null)
        {
            balanceComponent.enabled = false;
            StartCoroutine(ReEnableBalance(balanceComponent, 3f)); // Re-enable after 3 seconds
        }
    }

    IEnumerator ReEnableBalance(Balance balance, float delay)
    {
        yield return new WaitForSeconds(delay);
        balance.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ApplyRepulsionEffect();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ApplyRepulsionEffect();
    }

    IEnumerator DestroyGameObjectAfterDelay(GameObject objectToDestroy, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (objectToDestroy != null) // Check if the GameObject still exists
        {
            Destroy(objectToDestroy);
        }
    }
}