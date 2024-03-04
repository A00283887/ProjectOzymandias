using UnityEngine;

public class LavaTextureScroll : MonoBehaviour
{
    public Vector2 scrollSpeed = new Vector2(0.1f, 0.5f); // Scroll speed for both x and y
    private Renderer rend;
    private Vector2 initialScale; // To store the initial scale of the GameObject

    void Start()
    {
        rend = GetComponent<Renderer>();
        initialScale = transform.localScale; // Store the initial scale
    }

    void Update()
    {
        // Adjust texture offset to make it scroll
        Vector2 offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = offset;

        // Adjust texture tiling based on GameObject's current scale
        Vector2 scale = new Vector2(transform.localScale.x / initialScale.x, transform.localScale.y / initialScale.y);
        rend.material.mainTextureScale = scale;
    }
}
