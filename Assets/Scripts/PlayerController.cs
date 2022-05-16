using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public
    public bool reachedEndpoint;
    bool wasMovingVertical = false;

    // private
    private float moveSpeed = 3.5f;
    private Rigidbody2D rb;
    private Vector2 movement = new Vector2(0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        reachedEndpoint = false;
    }

    // Update is called once per frame
    void Update()
    {
        // get input if gamePlaying
        if (GameController.instance.gamePlaying)
        {
            GetPlayerInput();
        }
    }

    // get player input
    private void GetPlayerInput()
    {
        // input
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // movement flags
        bool isMovingHorizontal = Mathf.Abs(movement.x) > 0.5f;
        bool isMovingVertical = Mathf.Abs(movement.y) > 0.5f;

        // disable diagonal movement
        if (isMovingVertical && isMovingHorizontal)
        {
            if (wasMovingVertical)
            {
                movement.y = 0;
            }
            else
            {
                movement.x = 0;
            }
        }
        else if (isMovingHorizontal)
        {
            movement.y = 0;
            wasMovingVertical = false;
        }
        else if (isMovingVertical)
        {
            movement.x = 0;
            wasMovingVertical = true;
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }
    }

    // move player
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // player reached endpoint
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "EndPoint")
            reachedEndpoint = true;
    }
}