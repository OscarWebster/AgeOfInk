using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public float enemyHealth;
    public float enemyMaxHealth;

    public float enemySpeed = 10f;

    public bool isImmune = false;

    public float knockbackForce = 10f;
    public Rigidbody2D rb;
    private bool isKnockedBack = false;
    private float knockbackDuration;
    private float knockbackTimer;

    public gameManager GM;

    public HealthBarBehaviour HB;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        GM = GameObject.FindObjectOfType<gameManager>();
        enemyMaxHealth = enemyHealth;

        HB.SetHealth(enemyHealth, enemyMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            GM.Ink += 5;
        }

        
    }

    

    private void FixedUpdate()
    {
        if (isKnockedBack)
        {
            knockbackTimer -=Time.fixedDeltaTime;
            if (knockbackTimer <= 0)
            {
                isKnockedBack = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(enemySpeed, rb.velocity.y);

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
        if(collision.gameObject.tag == "weapon")
        {
            TakeDamage();
        }
        if(collision.gameObject.tag == "inkwell")
        {
            Destroy(gameObject);
        }
    }

    

    public void TakeDamage()
    {
        if (isImmune == false)
        {
            enemyHealth = enemyHealth - 1;
            isImmune = true;
            StartCoroutine("becomeVulnerable");
            Knockback();
            HB.SetHealth(enemyHealth, enemyMaxHealth);
        }
        

    }

    IEnumerator becomeVulnerable()
    {
        yield return new WaitForSeconds(0.5f);
        isImmune = false;
    }
}
