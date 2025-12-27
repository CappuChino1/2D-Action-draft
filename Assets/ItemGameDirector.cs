using UnityEngine;
using UnityEngine.UI; //UIを使うので忘れずに追加

/*
public class UsingItemEffect{
    
    void Update(){

        public void UsingItem_Effect(int Item){
        
            if(Item == 1){  //回復アイテム使用時の処理（効果発動）
                Debug.Log("回復アイテムを使用しました。");

            } else if(Item == 2){  //スピードアップアイテム使用時の処理（効果発動）
                Debug.Log("スピードアップアイテムを使用しました。");

            }
        }
    }
}
*/

public class ItemGameDirector : MonoBehaviour{

    GameObject ItemBox01;
    GameObject ItemIcon01;
    GameObject ItemIcon02;

    [SerializeField] PlayerMovement playerSpeed;

    float span = 10.0f;  //スピードアップの制限時間
    float delta = 0;

    bool isSpeedUp = false;  //false:スピードアップがない状態

    //画像を表示させるための変数宣言
    public Sprite HealingItem;
    public Sprite SpeedItem;

    //アイテムボックスの画像を格納するための配列
    public int[] ItemSlot = new int[2];  //０で初期化

    //各アイテムの定義（アイテムをナンバーで管理）
    public int heal = 1;
    public int speed = 2;

    void Start(){
        this.ItemIcon01 = GameObject.Find("ItemIcon01");
        this.ItemIcon02 = GameObject.Find("ItemIcon02");
    }

    void Update(){
        UsingItem();
        SpeedUpEffect();
    }

    public void HealingItemDisplay(){
        //アイテムボックスが埋まってなかったら回復アイテムを表示
        for(int i=0; i<ItemSlot.Length; i++){

            if(ItemSlot[i] == 0){
                //ItemSlot[i] = 1;  //i番目のアイテムスロットが埋まった事を表示
                                  //1の場合は回復アイテム            
                ItemSlot[i] = heal;

                if(i == 0 && ItemSlot[i] == 1){
                    this.ItemIcon01.GetComponent<Image>().sprite = HealingItem;
                    Debug.Log("スロット" + (i+1) + "にアイテムを格納しました。");
                    break;
                } else if(i == 1 && ItemSlot[i] == 1){
                    this.ItemIcon02.GetComponent<Image>().sprite = HealingItem;
                    Debug.Log("スロット" + (i+1) + "にアイテムを格納しました。");
                    break;
                }
            } else{
                Debug.Log("アイテムを取得できませんでした。");
            }
        }
    }

    public void SpeedItemDisplay(){
        for(int i=0; i<ItemSlot.Length; i++){

            if(ItemSlot[i] == 0){
                //ItemSlot[i] = 2;  //i番目のアイテムスロットが埋まった事を表示
                                  //2の場合はスピードアップアイテム
                ItemSlot[i] = speed;

                if(i == 0 && ItemSlot[i] == 2){
                    this.ItemIcon01.GetComponent<Image>().sprite = SpeedItem;
                    Debug.Log("スロット" + (i+1) + "にアイテムを格納しました。");
                    break;
                } else if(i == 1 && ItemSlot[i] == 2){
                    this.ItemIcon02.GetComponent<Image>().sprite = SpeedItem;
                    Debug.Log("スロット" + (i+1) + "にアイテムを格納しました。");
                    break;
                }
            } else{
                Debug.Log("アイテムを取得できませんでした。");
            }
        }
    }

    public void InvincibleState(){
        Debug.Log("無敵状態になりました。");
    }

    public void UsingItem(){

        if((ItemSlot[0] != 0) && (ItemSlot[1] != 0) ){  //スロット1,2：アイテムあり
            //1キーまたは2キーを押したとき
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                Debug.Log("アイテムスロット1のアイテムを使用しました。");
                this.ItemIcon01.GetComponent<Image>().sprite = null;

                UsingItem_Effect(ItemSlot[0]);
                //UsingItemEffect myItem = new UsingItemEffect();
                //myItem.UsingItem_Effect(ItemSlot[0]);

                ItemSlot[0] = 0;

            } else if(Input.GetKeyDown(KeyCode.Alpha2)){
                Debug.Log("アイテムスロット2のアイテムを使用しました。");
                this.ItemIcon02.GetComponent<Image>().sprite = null;

                UsingItem_Effect(ItemSlot[1]);
                //UsingItemEffect myItem = new UsingItemEffect();
                //myItem.UsingItem_Effect(ItemSlot[1]);
                

                ItemSlot[1] = 0;
            } 

        } else if((ItemSlot[0] != 0) && (ItemSlot[1] == 0)){  //スロット1：アイテムあり、スロット2：アイテムなし
            //1キーまたは2キーを押したとき
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                Debug.Log("アイテムスロット1のアイテムを使用しました。");
                this.ItemIcon01.GetComponent<Image>().sprite = null;

                UsingItem_Effect(ItemSlot[0]);

                ItemSlot[0] = 0;

            } else if(Input.GetKeyDown(KeyCode.Alpha2)){
                Debug.Log("アイテムスロット2にはアイテムはありません。");
                this.ItemIcon02.GetComponent<Image>().sprite = null;

                UsingItem_Effect(ItemSlot[1]);

                ItemSlot[1] = 0;
            } 

        } else if((ItemSlot[0] == 0) && (ItemSlot[1] != 0)){  //スロット1：アイテムなし、スロット2：アイテムあり
            //1キーまたは2キーを押したとき                      
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                Debug.Log("アイテムスロット1にはアイテムはありません。");
                this.ItemIcon01.GetComponent<Image>().sprite = null;

                UsingItem_Effect(ItemSlot[0]);

                ItemSlot[0] = 0;

            } else if(Input.GetKeyDown(KeyCode.Alpha2)){
                Debug.Log("アイテムスロット2のアイテムを使用しました。");
                this.ItemIcon02.GetComponent<Image>().sprite = null;

                UsingItem_Effect(ItemSlot[1]);

                ItemSlot[1] = 0;
            }

        } else {
            //アイテムスロットにアイテムがない状態で1 or 2キーを押したとき
            if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) ){
                Debug.Log("アイテムを所持していません。");
            }
        }
        

    }

    //アイテムの効果発動
    public void UsingItem_Effect(int Item){

        if(Item == 1){
            Debug.Log("回復アイテムを使用しました。");
        
        } else if(Item == 2){
            Debug.Log("スピードアップアイテムを使用しました。");
            playerSpeed.runSpeed *= 1.80f;
            isSpeedUp = true;
            SpeedUpEffect();
        }
    }

    //スピードアップアイテムの効果時間
    public void SpeedUpEffect(){

        if(isSpeedUp == true){
            this.delta += Time.deltaTime;

            if(this.delta > this.span){
                this.delta = 0;
                Debug.Log("スピードアップ効果が切れました。");
                playerSpeed.runSpeed = 40.0f;
                isSpeedUp = false;
            }
        }
    }

    
}

