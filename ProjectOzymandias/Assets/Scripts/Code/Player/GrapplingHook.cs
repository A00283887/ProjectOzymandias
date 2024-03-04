using UnityEngine;

public class PlayerGrapplingHook : MonoBehaviour
{
    public Transform firePoint; // Assign the arm or hand where the grappling hook originates
    public LayerMask grappleableLayer; // Set the layer that the hook can attach to
    private Vector2 grapplePoint;
    private LineRenderer lineRenderer;
    private bool isGrappling = false;
    public DistanceJoint2D joint;
    public Rigidbody2D bodyRb; // Rigidbody attached to the "Body"

    [SerializeField] private float pullForceMultiplier = 50f; // Adjust this value as needed

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void FixedUpdate() // Use FixedUpdate for Physics updates
    {
        if (isGrappling && joint != null)
        {
            // Calculate the direction from the player to the grapple point
            Vector2 pullDirection = (grapplePoint - (Vector2)transform.position).normalized;

            // Apply an additional pulling force towards the grapple point
            bodyRb.AddForce(pullDirection * pullForceMultiplier * bodyRb.mass, ForceMode2D.Force);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartGrapple();
        }

        if (Input.GetKeyUp(KeyCode.E) && isGrappling)
        {
            StopGrapple();
        }

        if (isGrappling)
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, grapplePoint);
        }

        if (joint != null)
        {
            if (Input.GetKey(KeyCode.W)) // Key to shorten the rope
            {
                joint.distance = Mathf.Max(joint.distance - Time.deltaTime * 4f, 1f);
            }
            else if (Input.GetKey(KeyCode.S)) // Key to extend the rope
            {
                joint.distance += Time.deltaTime * 2f;
            }
        }
    }

    void StartGrapple()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, 100f, grappleableLayer);
        if (hit.collider != null)
        {
            isGrappling = true;
            grapplePoint = hit.point;

            // Make sure the Rigidbody2D component exists on the "Body" GameObject
            if (bodyRb == null)
            {
                Debug.LogError("Rigidbody2D on the Body is missing!");
                return;
            }

            // Add the joint to the "Body"'s Rigidbody2D
            joint = bodyRb.gameObject.AddComponent<DistanceJoint2D>();
            joint.connectedAnchor = grapplePoint;
            joint.autoConfigureDistance = false;
            joint.distance = Vector2.Distance(bodyRb.position, grapplePoint);
            joint.enableCollision = true;


            lineRenderer.positionCount = 2; // Enable the line renderer
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, grapplePoint);
        }
    }

    void StopGrapple()
    {
        isGrappling = false;
        lineRenderer.positionCount = 0; // Disable the line renderer
        Destroy(joint);
    }
}
