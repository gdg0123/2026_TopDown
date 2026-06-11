using System.Collections;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public EnemyData data;

    public float currentHp;
    private float attackTimer = 0f;
    private Transform player;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Color originalColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = data.maxHp;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        originalColor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        attackTimer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * data.moveSpeed;
    }

    public void TakeDamage(float dmg)
    {
        currentHp -= dmg;
        StartCoroutine(FlashRed());

        if(currentHp <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        ExpManager.Instance?.AddExp(data.expReward);
        Destroy(gameObject);
    }

    IEnumerator FlashRed()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(data.flashDuration);
        sr.color = originalColor;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && attackTimer <= 0f)
        {
            other.GetComponent<PlayerHealth>()?.TakeDamage(data.damage);
            attackTimer = data.attackCooldown;
        }
    }
}
