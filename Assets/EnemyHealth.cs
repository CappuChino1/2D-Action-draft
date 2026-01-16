using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [Header("加算スコア")] public int myScore;

    public int hp = 1;
    public float knockbackPower = 0.2f;
    //EnemyのHPが0になったら、消滅するアニメーション-----------------------
    public Sprite[] enemyDeath;
    float time = 0;
    int idx = 0;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update(){

        //アニメーション
        this.time += Time.deltaTime;

        if(hp <= 0){

            if(this.time > 0.03f){
                this.time = 0;
                this.spriteRenderer.sprite = this.enemyDeath[this.idx];
                this.idx = 1 + this.idx;

                if(this.idx > 5){
                    Destroy(gameObject);
                }
            }
        }
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


    public void TakeDamage(int amount)
    {
        hp -= amount;
        Debug.Log("Enemy HP: " + hp);

        if (hp <= 0)
        {
            //(仮)敵が消えたらscore+10点
            ScoreManager.instance.score += myScore;
            Destroy(gameObject);
        }
    }
    //-----------------------------------------------------------------

    /*
    public void TakeDamage(int amount)
    {
        hp -= amount;
        Debug.Log("Enemy HP: " + hp);

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    */
}
