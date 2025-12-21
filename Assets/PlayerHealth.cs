using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public HealthUI healthUI;
    public GameOverUI gameOverUI;
    public float invincibleTime = 1f;

    private bool isInvincible;
    private bool isDead;

    void Start()
    {
        if (healthUI == null)
            healthUI = FindAnyObjectByType<HealthUI>();

        if (gameOverUI == null)
            gameOverUI = FindAnyObjectByType<GameOverUI>();
    }

    public void TakeDamage(int amount)
    {
        if (isInvincible || isDead) return;

        healthUI.TakeDamage(amount);

        if (healthUI.currentHearts <= 0)
        {
            Die();
        }

        StartCoroutine(Invincibility());
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("Game Over");

        GetComponent<PlayerMovement>().enabled = false;

        if (gameOverUI != null)
        {
            gameOverUI.ShowGameOver();
        }
    }

    System.Collections.IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }
}
