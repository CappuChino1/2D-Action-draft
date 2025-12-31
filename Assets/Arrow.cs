using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Don't hit the player
        if (other.CompareTag("Player"))
            return;

        IDamageable target = other.GetComponent<IDamageable>();
        if (target != null)
        {
            target.TakeDamage(damage);
            Destroy(gameObject); // destroy arrow on hit
        }
    }
}
