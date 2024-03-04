using UnityEngine;

public class DragCamera : MonoBehaviour
{
    public Camera targetCamera;
    private Vector3 previousPosition;

    private float minX = -14.5f;
    private float maxX = 25.3f;
    private float minY = -14f;
    private float maxY = 9f;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            previousPosition = targetCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(1)) 
        {
            Vector3 direction = previousPosition - targetCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPosition = targetCamera.transform.position + direction;

            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            targetCamera.transform.position = newPosition;

            previousPosition = targetCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
