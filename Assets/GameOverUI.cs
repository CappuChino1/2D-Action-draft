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
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}