using UnityEngine;

public class Enemy1_2 : MonoBehaviour
{
    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //this.player = GameObject.Find("player_0");
    }

    float span = 1.0f;
    float delta = 0;
    int direction = 1;
    float speed = 0.01f;

    // Update is called once per frame
    void Update()
    {
        //時間経過のカウント
        this.delta += Time.deltaTime;

        // span秒ごとに方向転換させる
        if(this.delta > this.span){
            this.delta = 0;
            direction *= -1;
        }

        // フレームごとに等速で移動させる
        transform.Translate(speed * direction, 0, 0);

        /*
        // 画面外に出たらオブジェクトを破棄する
        if(transform.position.x < -12.0f){
            Destroy(gameObject);
        }

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
    }
}

