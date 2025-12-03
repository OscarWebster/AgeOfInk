using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfantryHealth : MonoBehaviour
{
    public int health = 100;
    public float knockbackForce = 10f;
    public Rigidbody2D rb;
    private bool isKnockedBack = false;
    private float knockbackDuration;
    private float knockbackTimer;

    public float infantrySpeed = 5f;

    public bool isImmune = false;

    private void FixedUpdate()
    {
        if (isKnockedBack)
        {
            knockbackTimer -= Time.fixedDeltaTime;
            if (knockbackTimer <= 0)
            {
                isKnockedBack = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(infantrySpeed, rb.velocity.y);

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * infantrySpeed * Time.deltaTime);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Knockback()
    {
        isKnockedBack = true;
        knockbackTimer = knockbackDuration;
        rb.velocity = new Vector2(-knockbackForce, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemyweapon")
        {
            TakeDamage();
        }
    }
    public void TakeDamage()
    {
        if (isImmune == false)
        {
            health = health - 1;
            isImmune = true;
            StartCoroutine("becomeVulnerable");
            Knockback();
        }
    }
    IEnumerator becomeVulnerable()
    {
        yield return new WaitForSeconds(0.1f);
        isImmune = false;
    }
}
