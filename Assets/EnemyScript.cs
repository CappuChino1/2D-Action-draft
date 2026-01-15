using UnityEngine;

public class EnemyScript : MonoBehaviour, IDamageable
{
    public float knockbackPower = 0.2f;
    public int hp = 1;
    public int myScore;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit Player");

            //  Deal damage
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(1); // contact damage
            }

            // 2 Knockback
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 knockbackDir =
                    (collision.transform.position - transform.position).normalized;

                rb.AddForce(knockbackDir * knockbackPower, ForceMode2D.Impulse);
            }

            //  hit effect / sound here
        }
    }


    public class EnemyBehaviour : MonoBehaviour
    {
        public int contactDamage = 1;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            IDamageable target = collision.gameObject.GetComponent<IDamageable>();

            if (target != null)
            {
                target.TakeDamage(contactDamage);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        ScoreManager.instance.score += myScore;
        Destroy(gameObject);
    }


}
