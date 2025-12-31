using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAttack attack = other.GetComponent<PlayerAttack>();
            if (attack != null)
            {
                attack.EquipSword();
            }

            Destroy(gameObject); // remove sword
        }
    }
}
