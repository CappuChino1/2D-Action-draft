using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public HealthUI healthUI;
    public float invincibleTime = 1f;

    private bool isInvincible;
    private bool isDead = false;

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
            return;
        }

        StartCoroutine(Invincibility());
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("Game Over");

        GetComponent<PlayerMovement>().enabled = false;

        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }

    System.Collections.IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }
}
