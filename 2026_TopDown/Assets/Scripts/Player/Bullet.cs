using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1;
    public float lifetime = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy1>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void IncreaseLifetime(float amount)
    {
        lifetime = Mathf.Max(0.05f, lifetime - amount); // 최소값 제한
    }

    public void IncreaseDamage(float amount)
    {
        damage += amount;
    }

}
