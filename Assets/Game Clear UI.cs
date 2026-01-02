using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearUI : MonoBehaviour
{
    public GameObject gameClearPanel;
    public ScoreMover scoreMover;

    private GameClearUIController uiController;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("OnTriggerEnter2D");
            //scoreMover.MoveToClearPosition();
            gameClearPanel.SetActive(true);
            Time.timeScale = 0f; // pause game
            uiController.ShowClearScore();
        }
        
    }
}
