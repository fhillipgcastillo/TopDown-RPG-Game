using UnityEngine;


[SelectionBase]
public class player_controller : MonoBehaviour
{
    [Header("Properties")]
    public float speed = 3f;
    public Rigidbody2D rb;
    private float horizontalMovement;
    private float verticalMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //speed = 5;
        speed = GetComponent<float>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal"); // exact
        verticalMovement = Input.GetAxis("Vertical");
        Debug.Log("horizontalMovement: " + horizontalMovement);
        Debug.Log("verticalMovement: " + verticalMovement);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * speed, verticalMovement * speed);
    }
}
