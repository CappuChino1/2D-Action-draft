using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;
    public int score;
    public int stageNum;
    public int continueNum;
    
    //Start()より先に動くメソッド
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);//シーンを移動しても指定されたオブジェクトは破棄されない
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
    }
}
