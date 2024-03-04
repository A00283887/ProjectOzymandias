using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class DoctorCollision : MonoBehaviour
{
    public Animator animator;
    public bool canCollide;
    void Start()
    {
        canCollide = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canCollide)
        {
            if (other.gameObject.tag.Equals("NPC"))
            {
                animator.SetBool("IsRunning", false);
                StartCoroutine(Dialogue());
                StartCoroutine(DialogueCooldown());
                canCollide = false;
            }
        }
    }

    IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(5);
        animator.SetBool("IsRunning", true);
    }

    IEnumerator DialogueCooldown()
    {
        yield return new WaitForSeconds(15);
        canCollide = true;
    }
}
