using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LineRenderer))]
public class SnakeTrailMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float updateInterval = 0.5f;
    public Vector2 direction = Vector2.right;
    private LineRenderer lineRenderer;
    private float timeSinceLastUpdate = 0.0f;
    public Vector2 lastDirection = Vector2.right;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    void Update()
    {
        HandleInput();

        timeSinceLastUpdate += Time.deltaTime;
        if (timeSinceLastUpdate > updateInterval)
        {
            UpdateTrail();
            timeSinceLastUpdate = 0.0f;
        }

        Move();
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (lastDirection != Vector2.down) // Prevent reversing direction
                direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (lastDirection != Vector2.up) // Prevent reversing direction
                direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (lastDirection != Vector2.right) // Prevent reversing direction
                direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (lastDirection != Vector2.left) // Prevent reversing direction
                direction = Vector2.right;
        }
    }

    private void Move()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
        lastDirection = direction; // Update lastDirection after moving

    }

    private void UpdateTrail()
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);
    }
}