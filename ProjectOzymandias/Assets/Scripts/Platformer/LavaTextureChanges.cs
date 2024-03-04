using UnityEngine;

public class LavaTextureChanges : MonoBehaviour
{
    private Vector3 originalScale;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalScale = transform.localScale;
        // Initialize with 1:1 tiling
        rend.material.mainTextureScale = new Vector2(1, 1);
    }

    void Update()
    {
        // Calculate the new scale factor based on the original scale
        Vector2 scale = new Vector2(transform.localScale.x / originalScale.x, transform.localScale.y / originalScale.y);

        // Adjust the texture tiling inversely to the GameObject's scale to maintain texture size
        // This means if the GameObject is scaled up, we reduce the tiling to make each tile bigger
        rend.material.mainTextureScale = new Vector2(1 / scale.x, 1 / scale.y);
    }
}
