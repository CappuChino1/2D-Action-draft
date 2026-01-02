using UnityEngine;

public class GameClearUIController : MonoBehaviour
{
    [SerializeField] private GameObject scoreTopRight;
    [SerializeField] private GameObject scoreCenter;

    public void ShowClearScore()
    {
        scoreTopRight.SetActive(false);
        scoreCenter.SetActive(true);
    }

    public void ResetScorePosition()
    {
        scoreTopRight.SetActive(true);
        scoreCenter.SetActive(false);
    }
}
