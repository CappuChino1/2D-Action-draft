using UnityEngine;

public class SpeedItem : MonoBehaviour
{
    //public InventoryUI inventoryUI; // ←UIをドラッグして設定

    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // フレームごとに等速で落下させる
        transform.Translate(-0.01f, 0, 0);

        // 画面外に出たらオブジェクトを破棄する
        if(transform.position.x < -12.0f){
            Destroy(gameObject);
        }
        */

        //当たり判定
        Vector2 p1 = transform.position;  //アイテムの中心座標
        Vector2 p2 = this.player.transform.position;  //プレイヤーの中心座標
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.3f;  //アイテムの半径
        float r2 = 0.5f;  //pプレイヤーの半径

        /*
        if(d < r1 + r2){
            inventoryUI.AddItem("Healing"); // スロットに追加
            //InventoryUI inv = GameObject.Find("InventoryUI").GetComponent<InventoryUI>();
            //inv.AddItem("Healing"); // 取得したのでスロットに登録
            //衝突した場合はアイテムを消す
            Destroy(gameObject);
        }
        */

        if(d < r1 + r2){
            
            //監督スクリプトにプレイヤーと衝突したことを伝える
            GameObject director = GameObject.Find("ItemGameDirector");
            director.GetComponent<ItemGameDirector>().SpeedItemDisplay();
            //衝突した場合はアイテムを消す
            Destroy(gameObject);
        }
    }
}
