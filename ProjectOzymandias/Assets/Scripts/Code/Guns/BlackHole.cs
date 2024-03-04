using System.Collections;
using System.Collections.Generic; // For HashSet
using UnityEngine;

public class BlackHoleEffect : MonoBehaviour
{
    public float pullRadius = 10f; // Radius within which to pull objects
    public float pullForce = 100f; // Strength of the pull
    private bool isActivated = false; // Track whether the effect is activated
    public GameObject particles;
    private bool blackholecreated = false;
    public ChaosController cc;
    private HashSet<GameObject> processedEnemies = new HashSet<GameObject>(); // Track processed enemies

    private void Start()
    {
        cc = GameObject.Find("EscController").GetComponent<ChaosController>();
    }

    void FixedUpdate()
    {
        if (isActivated)
        {
            if (!blackholecreated)
            {
                Instantiate(particles, this.transform);
                blackholecreated = true;
            }
            StartCoroutine(destroyThis());
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pullRadius);

            foreach (var collider in colliders)
            {
                if (collider.gameObject.layer != LayerMask.NameToLayer("Player"))
                {
                    Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        Vector2 forceDirection = transform.position - collider.transform.position;
                        rb.AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);

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
                            StartCoroutine(DestroyObjectDelayed(collider.gameObject, 0.1f)); // Destroy the collider object after 5 seconds
                        }

                        // New logic to add progress for each enemy once
                        GameObject enemyParent = collider.transform.parent.gameObject; // Get the parent GameObject of the collider
                        if (!processedEnemies.Contains(enemyParent)) // Check if the enemy has not been processed
                        {
                            processedEnemies.Add(enemyParent); // Mark this enemy as processed
                            cc.removeProgress(0.05f); // Add progress for this enemy
                            StartCoroutine(DestroyObjectDelayed(enemyParent, 5f));
                        }
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            isActivated = true;
            StickToObject(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            isActivated = true;
            StickToObject(other.gameObject);
        }
    }

    void StickToObject(GameObject target)
    {
        transform.parent = target.transform;
        var rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.simulated = false;
        }
    }

    IEnumerator destroyThis()
    {
        yield return new WaitForSeconds(7f);
        Destroy(this.gameObject);
    }

    // New method for delayed destruction of objects
    IEnumerator DestroyObjectDelayed(GameObject objectToDestroy, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(objectToDestroy);
    }
}