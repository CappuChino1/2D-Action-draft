using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    void Start()
    {
    }

    public void ShowGameOver()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f; // pause game

        //ゲームオーバー画面に来たら、scoreを0に→リトライを押したらスコアを0に変更する
        //ScoreManager.instance.score = 0;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}