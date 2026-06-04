using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHp = 3;
    private int currentHp;

    public float invincibleTime = 1f;
    public float flashDuration = 0.1f;

    private bool isInvincible = false;
    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
        sr = GetComponent<SpriteRenderer>();

        PlayerHPManager.Instance?.UpdateHP(currentHp, maxHp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int dmg = 1)
    {
        if (isInvincible) return;

        currentHp -= dmg;

        PlayerHPManager.Instance?.UpdateHP(currentHp, maxHp);

        if (currentHp <= 0)
            Die();
        else
            StartCoroutine(InvincibleFlash());
    }

    IEnumerator InvincibleFlash()
    {
        isInvincible = true;

        float elapsed = 0f;
        while (elapsed < invincibleTime)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(flashDuration);
            sr.enabled = true;
            yield return new WaitForSeconds(flashDuration);
            elapsed += flashDuration * 2f;
        }

        sr.enabled = true;
        isInvincible = false;
    }

    void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
