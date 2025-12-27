/*
using UnityEngine;

public class Chara_Enemy1 : MonoBehaviour
{
    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // フレームごとに等速で移動させる
        transform.Translate(-0.01f, 0, 0);

    }
}
*/


using UnityEngine;

public class Enemy1_1 : MonoBehaviour
{
    GameObject player;
    public float knockbackPower = 0.01f;
    public Sprite[] walkSprites;
    float time = 0;
    int idx = 0;
    SpriteRenderer spriteRenderer;
    public float speed = 0.015f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //this.player = GameObject.Find("Player");
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // フレームごとに等速で移動させる
        transform.Translate(-speed, 0, 0);

        /*j
        // 画面外に出たらオブジェクトを破棄する
        if(transform.position.x < -12.0f){
            Destroy(gameObject);
        }
        */

        /*
        //当たり判定
        Vector2 p1 = transform.position;  //敵キャラの中心座標
        Vector2 p2 = this.player.transform.position;  //プレイヤーの中心座標
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.2f;  //敵キャラの半径
        float r2 = 1.0f;  //プレイヤーの半径

        if(d < r1 + r2){
            //衝突した場合は矢を消す
            Destroy(gameObject);
        }
        */
        //アニメーション
        this.time += Time.deltaTime;
        if(this.time > 0.1f){
        
            this.time = 0;
            this.spriteRenderer.sprite = this.walkSprites[this.idx];
            //this.idx = 1 - this.idx;
            this.idx = 1 + this.idx;
                if(this.idx > 5){
                    this.idx = 0;
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

}
