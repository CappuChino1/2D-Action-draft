using UnityEngine;

public enum WeaponType
{
    None,
    Sword,
    Bow
}

public class PlayerAttack : MonoBehaviour
{
    public WeaponType currentWeapon = WeaponType.None;

    [Header("Melee")]
    public GameObject fistAttackPoint;   // small hitbox
    public GameObject swordAttackPoint;  // wide hitbox
    public float attackDuration = 0.2f;

    [Header("Bow")]
    public GameObject arrowPrefab;
    public Transform shootPoint;
    public float arrowSpeed = 10f;

    private bool isAttacking;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();

        // Make sure everything starts disabled
        fistAttackPoint.SetActive(false);
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

        switch (currentWeapon)
        {
            case WeaponType.None:
                StartMelee(fistAttackPoint);
                break;

            case WeaponType.Sword:
                StartMelee(swordAttackPoint);
                break;

            case WeaponType.Bow:
                ShootArrow();
                EndAttack(); // no hitbox duration
                break;
        }
    }

    void StartMelee(GameObject attackPoint)
    {
        attackPoint.SetActive(true);
        Invoke(nameof(EndAttack), attackDuration);
    }

    void EndAttack()
    {
        fistAttackPoint.SetActive(false);
        swordAttackPoint.SetActive(false);
        isAttacking = false;
    }

    void ShootArrow()
    {
        float direction = transform.localScale.x > 0 ? 1 : -1;

        Vector3 spawnOffset = new Vector3(0.5f * direction, 0f, 0f);
        GameObject arrow = Instantiate(
            arrowPrefab,
            shootPoint.position + spawnOffset,
            Quaternion.identity
        );

        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(direction * arrowSpeed, 0);
    }

    // Called when picking up weapons
    public void EquipSword()
    {
        currentWeapon = WeaponType.Sword;
    }

    public void EquipBow()
    {
        currentWeapon = WeaponType.Bow;
    }

    public void UnequipWeapon()
    {
        currentWeapon = WeaponType.None;
    }
}
