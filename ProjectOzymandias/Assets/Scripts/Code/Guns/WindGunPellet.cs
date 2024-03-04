using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGunBullet : MonoBehaviour
{
    public bool isDead = false;
    public ParticleSystem muzzleFlash;
    public ParticleSystem sparks;
    public ParticleSystem Blood;
    public PlayerController pc;
    public float pushForce = 500f;
    private float disableDuration = 1.5f;
    public ChaosController cc; // Reference to the ChaosController
    private HashSet<GameObject> processedEnemies = new HashSet<GameObject>(); // Track processed enemy GameObjects

    void Start()
    {
        StartCoroutine(destroyAfterTime());
        cc = GameObject.Find("EscController").GetComponent<ChaosController>();
        pc = GameObject.Find("Hips").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Disable the Balance component on every hit
            Balance balance = collision.GetComponent<Balance>();
            if (balance != null)
            {
                StartCoroutine(DisableComponent(balance, disableDuration));
            }

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Apply a force in the direction the wind gust is moving
                rb.AddForce(transform.right * pushForce);
            }

            if (collision.gameObject.name == "RightHandEnemy")
            {
                StartCoroutine(DestroyGameObjectAfterDelay(collision.gameObject, 2f)); ; // Destroy after 2 seconds
            }

            // Get the root GameObject of the enemy to ensure uniqueness for progress addition
            GameObject enemyGameObject = collision.transform.root.gameObject;

            if (!processedEnemies.Contains(enemyGameObject))
            {
                processedEnemies.Add(enemyGameObject); // Mark this enemy as processed

                // Add progress for this enemy using ChaosController, only once per enemy GameObject
                cc.removeProgress(0.05f); // Adjust the value as 
            }
        }
    }

    IEnumerator DisableComponent(Behaviour component, float duration)
    {
        component.enabled = false;
        yield return new WaitForSeconds(duration);
        // Optionally re-enable the component if needed
        // component.enabled = true;
    }

    IEnumerator DestroyGameObjectAfterDelay(GameObject objectToDestroy, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(objectToDestroy);
    }

    IEnumerator destroyAfterTime()
    {
        yield return new WaitForSeconds(3f); // Adjust the delay as needed
        Destroy(gameObject);
    }
}