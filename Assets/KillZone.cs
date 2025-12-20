using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player fell Å® Game Over");

            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.Die(); // instant death
            }
        }
    }
}
