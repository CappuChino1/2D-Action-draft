using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public int hp = 1;

    public void TakeDamage(int amount)
    {
        hp -= amount;
        Debug.Log("Enemy HP: " + hp);

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
