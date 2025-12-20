using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public HealthUI healthUI;
    public float invincibleTime = 1f;

    private bool isInvincible;

    void Start()
    {
        if (healthUI == null)
            healthUI = FindObjectOfType<HealthUI>();
    }

    public void TakeDamage(int amount)
    {
        if (isInvincible) return;

        healthUI.TakeDamage(amount);

        if (healthUI.currentHearts <= 0)
        {
            Die();
        }

        StartCoroutine(Invincibility());
    }

    void Die()
    {
        Debug.Log("Player Dead");
        // TODO: Game over / respawn
    }

    System.Collections.IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }
}
