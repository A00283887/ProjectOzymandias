using UnityEngine;

public class GetComponentOnSquare : MonoBehaviour
{
    public GameObject selectedItem;

    void Start()
    {
    }

    private void Update()
    {
        // Small radius to effectively find objects at the same position
        float radius = 0.01f;
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (var hitCollider in hitColliders)
        {
            // Ensure not to include this object
            if (hitCollider.gameObject != gameObject && hitCollider.gameObject.name == "CraftingItems(Clone)")
            {
                Debug.Log("Found an object at the same position: " + hitCollider.gameObject.name);
                selectedItem = hitCollider.gameObject;
            }
        }
    }

    public GameObject getObject()
    {
        return selectedItem;
    }
}
