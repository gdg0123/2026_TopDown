using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1f;
    public float lifetime = 2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy1>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    


}
