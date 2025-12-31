using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject normalAttackPoint;
    public float attackDuration = 0.2f;
    public int damage = 1;
    public GameObject swordAttackPoint;

    private bool hasSword = false;
    private bool isAttacking;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();

        normalAttackPoint.SetActive(false);
        swordAttackPoint.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isAttacking)
        {
            Attack();
        }
    }

    void Attack()
    {
        isAttacking = true;

        if (animator != null)
            animator.SetTrigger("Attack");

        GameObject attackPoint = hasSword ? swordAttackPoint : normalAttackPoint;
        attackPoint.SetActive(true);
        Invoke(nameof(EndAttack), attackDuration);
    }

    void EndAttack()
    {
        normalAttackPoint.SetActive(false);
        swordAttackPoint.SetActive(false);
        isAttacking = false;
    }

    public void EquipSword()
    {
        hasSword = true;
        Debug.Log("Sword equipped!");
    }
}
