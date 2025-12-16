using UnityEngine;
using UnityEngine.UI; //UIを使うので忘れずに追加

public class ItemGameDirector : MonoBehaviour{

    GameObject ItemBox01;
    GameObject ItemIcon01;
    GameObject ItemIcon02;

    //画像を表示させるための変数宣言
    public Sprite HealingItem;
    public Sprite SpeedItem;

    //アイテムボックスの画像を格納するための配列
    public int[] ItemSlot = new int[2];  //０で初期化

    void Start(){
        this.ItemIcon01 = GameObject.Find("ItemIcon01");
        this.ItemIcon02 = GameObject.Find("ItemIcon02");
    }

    void Update(){
        UsingItem();
    }


    public void HealingItemDisplay(){
        //アイテムボックスが埋まってなかったら回復アイテムを表示
        for(int i=0; i<ItemSlot.Length; i++){

            if(ItemSlot[i] == 0){
                ItemSlot[i] = 1;  //i番目のアイテムスロットが埋まった事を表示
                                  //1の場合は回復アイテム
                
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
                ItemSlot[i] = 2;  //i番目のアイテムスロットが埋まった事を表示
                                  //2の場合はスピードアップアイテム
                
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

        if((ItemSlot[0] != 0) && (ItemSlot[1] != 0) ){
            //1キーまたは2キーを押したとき
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                Debug.Log("アイテムスロット1のアイテムを使用しました。");
                this.ItemIcon01.GetComponent<Image>().sprite = null;
                ItemSlot[0] = 0;

            } else if(Input.GetKeyDown(KeyCode.Alpha2)){
                Debug.Log("アイテムスロット2のアイテムを使用しました。");
                this.ItemIcon02.GetComponent<Image>().sprite = null;
                ItemSlot[1] = 0;
            } 

        } else if((ItemSlot[0] != 0) && (ItemSlot[1] == 0)){  //スロット1：アイテムあり、スロット2：アイテムなし
            //1キーまたは2キーを押したとき
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                Debug.Log("アイテムスロット1のアイテムを使用しました。");
                this.ItemIcon01.GetComponent<Image>().sprite = null;
                ItemSlot[0] = 0;

            } else if(Input.GetKeyDown(KeyCode.Alpha2)){
                Debug.Log("アイテムスロット2にはアイテムはありません。");
                this.ItemIcon02.GetComponent<Image>().sprite = null;
                ItemSlot[1] = 0;
            } 

        } else if((ItemSlot[0] == 0) && (ItemSlot[1] != 0)){  //スロット1：アイテムなし、スロット2：アイテムあり
            //1キーまたは2キーを押したとき                      
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                Debug.Log("アイテムスロット1にはアイテムはありません。");
                this.ItemIcon01.GetComponent<Image>().sprite = null;
                ItemSlot[0] = 0;

            } else if(Input.GetKeyDown(KeyCode.Alpha2)){
                Debug.Log("アイテムスロット2のアイテムを使用しました。");
                this.ItemIcon02.GetComponent<Image>().sprite = null;
                ItemSlot[1] = 0;
            }

        } else {
            //アイテムスロットにアイテムがない状態で1 or 2キーを押したとき
            if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) ){
                Debug.Log("アイテムを所持していません。");
            }
        }
        

    }
    
}

