using UnityEngine;

public class Lava : MonoBehaviour
{
    public float spreadSpeed = 0.1f; // Speed at which the lava spreads

    void Update()
    {
        // Increase the lava's width over time
        transform.localScale += new Vector3(spreadSpeed * Time.deltaTime * 10, spreadSpeed * Time.deltaTime, 0f);
    }
}