using Unity.VisualScripting;
using UnityEngine;


[SelectionBase]
public class player_controller : MonoBehaviour
{
    [Header("Properties")]
    public float speed = 4f;
    public Rigidbody2D rb;
    private float horizontalMovement;
    private float verticalMovement;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //speed = GetComponent<float>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal"); // exact
        verticalMovement = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        var horizontalSpeed = horizontalMovement * speed;
        var verticalSpeed = verticalMovement * speed;
        rb.linearVelocity = new Vector2(horizontalSpeed, verticalSpeed);
        animator.SetFloat("horizontalSpeed", horizontalMovement);
        animator.SetFloat("verticalSpeed", verticalSpeed);

        //animator.horizontalSpeed = horizontalSpeed;
        //animator.verticalSpeed = verticalSpeed;

        //Debug.Log(animator.speed);
    }
}
