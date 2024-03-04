using UnityEngine;

public class JetBoots : MonoBehaviour
{
    public float jetForce = 5f; // Adjustable force for the jet propulsion
    private Rigidbody2D rb;
    public ParticleSystem jetParticles; // Assign this in the inspector

    void Start()
    {
        // Attempt to get the Rigidbody2D component attached to the same GameObject
        rb = GetComponentInParent<Rigidbody2D>();
        // Optionally, find the ParticleSystem if not assigned. Remove if you're assigning it via the Inspector.
        if (jetParticles == null)
        {
            jetParticles = GetComponentInChildren<ParticleSystem>();
        }
    }

    void Update()
    {
        // Check if the space key is being held down
        if (Input.GetKey(KeyCode.G))
        {
            ApplyJetForce();
            PlayJetParticles();
        }
        else if (jetParticles != null && jetParticles.isPlaying)
        {
            // Stop the particle effect when the space bar is released
            jetParticles.Stop();
        }
    }

    void ApplyJetForce()
    {
        // Ensure there's a Rigidbody2D component to apply force to
        if (rb != null)
        {
            // Apply an upward force
            rb.AddForce(new Vector2(0, jetForce), ForceMode2D.Force);
        }
    }

    void PlayJetParticles()
    {
        jetParticles.Play();

    }
}