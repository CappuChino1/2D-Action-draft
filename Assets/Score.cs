/*using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance; //シングルトン

    public int score = 0;          //現在のスコア
    public float elapsedTime = 0f; //経過時間
    public bool isClear = false;   //クリアしたかどうか

    [Header("時間ボーナス設定")]
    public float bestTime = 30f;   //これより早くしたら最大ボーナス
    public int maxTimeBonus = 1000; // 最速クリア時にもらえる最大ボーナス

    private void Awake()
    {
        //シングルトンを簡易実装
        if(Instance = null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); //シーンをまたいでも使いたかったら使用

        }
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        //クリア前は時間をカウントし続ける
        if(!isClear)
            elapsedTime += Time.deltaTime;
    }

    //敵を倒したときに呼ぶメソッド
    public void AddScoreByEnemy(int enemyScore)
    {
        score += enemyScore;
        Debug.Log("Enemy defeated. Score ; " + score);
    }

    //クリアしたときに呼ぶスコア
    public void OnstageClear()
    {
        if(isClear) retuen; //二重呼び出し防止

        isClear = true;
        int timeBonus = CalculateTimeBonus();
        score += timeBonus;

        Debug.Log("Stage Clear!");
        Debug.Log("Time: " + elapsedTime.ToString("F2") + "秒");
        Debug.Log("Time Bonus: " + timeBonus);
        Debug.Log("Final Score: " + score);
    }

    //時間ボーナスの計算
    private int CalculateTimeBonus()
    {
        // 例えば、0秒クリアなら maxTimeBonus
        // bestTime 秒かかるとボーナス 0
        // それ以上だと 0 で頭打ち、というイメージ

        float t = Mathf.Clamp(elapsedTime, 0f, bestTime);
        float rate = 1f - (t / bestTime);
        int bonus = Mathf.RoundToInt(maxTimeBonus * rate);

        retuen bonus;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/