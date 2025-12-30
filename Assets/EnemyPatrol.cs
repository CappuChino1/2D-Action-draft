using UnityEngine;
using System.Collections;

public class FrogPatrolHop : MonoBehaviour
{

    [Header("Movement")]
    public float moveSpeed = 2f;
    public float hopUpForce = 6f;
    public float hopInterval = 0.6f;

    [Header("Patrol Range (local offsets)")]
    public float leftOffset = -2f;
    public float rightOffset = 2f;

    [Header("Stop")]
    public float stopTolerance = 0.05f;

    private Rigidbody2D rb;

    private Vector2 leftPoint;
    private Vector2 rightPoint;
    private Vector2 currentTarget;

    private int direction;
    private float hopTimer;
    public Animator animator;

    void Start()
    {
        // Choose initial target based on offsets
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        Vector2 startPos = rb.position;
        leftPoint = startPos + Vector2.right * leftOffset;
        rightPoint = startPos + Vector2.right * rightOffset;

        if (Mathf.Abs(rightOffset) >= Mathf.Abs(leftOffset))
        {
            currentTarget = rightPoint;
            direction = 1;
        }
        else
        {
            currentTarget = leftPoint;
            direction = -1;
        }
        hopTimer = hopInterval;


        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * -direction; // sprite faces left by default
        transform.localScale = scale;
    }

    void FixedUpdate()
    {
        hopTimer -= Time.fixedDeltaTime;

        CheckTargetReached();

        if (hopTimer <= 0f)
        {
            Hop();
            hopTimer = hopInterval;
        }
    }

    void Hop()
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed, hopUpForce);
        animator.SetTrigger("Jump");
    }


    void CheckTargetReached()
    {
        float x = rb.position.x;

        bool reached =
            (currentTarget == rightPoint && x >= currentTarget.x - stopTolerance) ||
            (currentTarget == leftPoint && x <= currentTarget.x + stopTolerance);

        if (reached)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);

        if (currentTarget == rightPoint)
        {
            currentTarget = leftPoint;
            direction = -1;
        }
        else
        {
            currentTarget = rightPoint;
            direction = 1;
        }

        // Optional sprite flip
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * -direction;
        transform.localScale = scale;
    }
  
}
