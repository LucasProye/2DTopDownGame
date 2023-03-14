using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;

    Rigidbody2D playerRigidbody2D;

    Vector2 direction;

    [SerializeField] float speed = 5f;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        playerRigidbody2D.velocity = direction * speed;
    }
}