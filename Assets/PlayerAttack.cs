using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackPoint;
    public float attackDuration = 0.2f;
    public int damage = 1;

    private bool isAttacking;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
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

        attackPoint.SetActive(true);
        Invoke(nameof(EndAttack), attackDuration);
    }

    void EndAttack()
    {
        attackPoint.SetActive(false);
        isAttacking = false;
    }
}
