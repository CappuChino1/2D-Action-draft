using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public int maxHearts = 3;
    public int currentHearts;

    public Image heartPrefab;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        currentHearts = maxHearts;
        DrawHearts();
    }

    public void TakeDamage(int amount)
    {
        currentHearts -= amount;
        currentHearts = Mathf.Clamp(currentHearts, 0, maxHearts);
        DrawHearts();
    }

    void DrawHearts()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < maxHearts; i++)
        {
            Image heart = Instantiate(heartPrefab, transform);
            heart.gameObject.SetActive(true);

            if (i < currentHearts)
                heart.sprite = fullHeart;
            else
                heart.sprite = emptyHeart;
        }
    }
}
