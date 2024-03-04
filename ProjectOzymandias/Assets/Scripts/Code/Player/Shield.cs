using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private SpriteRenderer sr;
    private float shieldHealth;
    private float maxShield;
    private float alpha;
    public ShieldBar shieldBar;
    private bool ShieldReg;

    void Start()
    {
        shieldHealth = maxShield;
        sr = GameObject.Find("Shield").GetComponent<SpriteRenderer>();
        shieldBar.SetMaxShield(shieldHealth);
        sr.color = new Color(0, 255f, 255f, .25f);
    }

    // Update is called once per frame
    void Update()
    {
        sr.color = new Color(0, 255, 255, alpha);
        alpha = shieldHealth / 400;
        shieldBar.SetShield(shieldHealth);
        ShieldRegen();
        if (shieldHealth <= 0)
        {
            shieldHealth = 0;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        }
    }

    private void ShieldRegen()
    {
        
        if (ShieldReg == false)
        {
            StartCoroutine(ShieldRegenTimer());
            if (shieldHealth! <= maxShield)
            {
                shieldHealth += 5;
            }
            ShieldReg = true;
        }
    }
    IEnumerator ShieldRegenTimer()
    {
        yield return new WaitForSeconds(10f);
        ShieldReg = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
            shieldHealth -= 10f;
        }
    }

    public void setShieldLevel(float num)
    {
        maxShield = num;
        shieldHealth = maxShield;
    }
}
