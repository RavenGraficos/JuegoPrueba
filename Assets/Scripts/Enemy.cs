using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;

    public Animator animator;
    public float startTimer = 3f;
    public float attackCooldown = 2f;
    private bool isMoving = false;
    private bool isAttacking = false;
    private bool isIdle = false;

    private Rigidbody rb;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator.SetBool("isMoving", false);
        animator.SetBool("isAttaking", false);
        animator.SetBool("isIdle", true);

    }

    void FixedUpdate()
    {
        startTimer -= Time.deltaTime;
        if (startTimer <= 0f)
        {
            startTimer = 0f;

            float distance = Vector3.Distance(transform.position, player.transform.position);   

            if (distance > 1.5f && distance <= 150f)
            {
                MoveTowardsPlayer();

            }
            else if (distance <= 1.8f)
            {

                Attack();
                attackCooldown -= Time.deltaTime;

                if (attackCooldown <= 0f)             
            {
                player.GetComponent<Player>().TakeDamage(30f);
                attackCooldown = 1f; 
            }
            }

            }
        }   
    
    void MoveTowardsPlayer()
{
    isMoving = true;
    isAttacking = false;

    animator.SetBool("isMoving", true);
    animator.SetBool("isAttaking", false);

    Vector3 direction = player.transform.position - transform.position;

    // Mantener el movimiento sobre el suelo
    direction.y = 0;

    direction.Normalize();

    rb.MovePosition(
        rb.position + direction * speed * Time.fixedDeltaTime
    );

    if (direction != Vector3.zero)
    {
        rb.rotation = Quaternion.LookRotation(direction);
    }
}

    void Attack()
    {
        isMoving = false;
        isAttacking = true;

        animator.SetBool("isMoving", false);
        animator.SetBool("isAttaking", true);

        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
    {
        rb.rotation = Quaternion.LookRotation(direction);
    }
            
    }
}