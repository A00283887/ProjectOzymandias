using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool isDragging;
    private bool disableColliderSwitch = true;
    public Vector3 LastPosition;

    private Collider2D collider;

    private DragController dragController;

    private float movementTime = 15f;
    private System.Nullable<Vector3> movementDestination;
    void Start()
    {
        collider = GetComponent<Collider2D>();
        dragController = FindObjectOfType<DragController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isDragging) 
        {
            this.gameObject.transform.parent = GameObject.Find("UpgradeUI").transform;
            GameObject.Find("CANTDROP (2)").GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            if (disableColliderSwitch)
            {
                StartCoroutine(disableCollider());
                disableColliderSwitch = false;
            }
        }
        if (movementDestination.HasValue) 
        { 
            if(isDragging) 
            {
                this.gameObject.transform.parent = GameObject.Find("UpgradeUI").transform;
                movementDestination = null;
                return;
            }

            if(transform.position == movementDestination)
            {
                gameObject.layer = Layer.Default;
                movementDestination = null;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, movementDestination.Value, movementTime * Time.fixedDeltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Draggable collidedDraggable = other.GetComponent<Draggable>();

        if (collidedDraggable != null && dragController.LastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = other.Distance(collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff;
        }

        if(other.CompareTag("Drop Valid"))
        {
            movementDestination = other.transform.position;
            this.gameObject.transform.parent = GameObject.Find("UpgradeUI").transform;
        }
        else if (other.CompareTag("Drop Invalid"))
        {
            Debug.Log("COLLIDING");
            movementDestination = null;
            this.gameObject.transform.parent = GameObject.Find("Upgrades").transform;
        }
    }

    IEnumerator disableCollider()
    {
        yield return new WaitForSeconds(1);
        GameObject.Find("CANTDROP (2)").GetComponent<Collider2D>().enabled = false;
        disableColliderSwitch = true;
    }
}
