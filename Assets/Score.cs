using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    private TMP_Text scoreText = null;
    private int oldScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        if(ScoreManager.instance != null)
        {
            scoreText.text = "Score " + ScoreManager.instance.score;
        }
        else
        {
            Debug.Log("スコアマネージャーがないです。");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(oldScore != ScoreManager.instance.score)
        {
            //スコアが変わった時だけ更新
            scoreText.text = "Score " + ScoreManager.instance.score;
            oldScore = ScoreManager.instance.score;
        }
    }
}
