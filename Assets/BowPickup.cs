using UnityEngine;

public class BowPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAttack attack = other.GetComponent<PlayerAttack>();
            if (attack != null)
            {
                attack.EquipBow();
            }

            Destroy(gameObject); // remove Bow
        }
    }
}
