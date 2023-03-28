using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    Rigidbody2D playerRigidbody2D;
    [SerializeField] Animator _animator;
    Vector2 direction;
    [SerializeField] float speed = 5f;
    [SerializeField] Text _scoring;
    int _score = 0;
    bool _isRunning;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        _isRunning = context.performed;
        if(_isRunning)
        {
            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
        }
    }

    void FixedUpdate()
    {
        playerRigidbody2D.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Coins"))
        {
            _score += 1;
            _scoring.text = "" + _score;
        }
    }
}