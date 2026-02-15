using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearUI : MonoBehaviour
{
    public GameObject gameClearPanel;
    public ScoreMover scoreMover;
    [Header("â¡éZÉXÉRÉA")] public int myScore;
    private GameClearUIController uiController;
    private Score showScore;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("OnTriggerEnter2D");
            //scoreMover.MoveToClearPosition();
            gameClearPanel.SetActive(true);
            Time.timeScale = 0f; // pause game
            //showScore,SetActive(true);
            //uiController.ShowClearScore();
        }
        
    }
}
