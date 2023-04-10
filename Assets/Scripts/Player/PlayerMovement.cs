using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    Rigidbody2D playerRigidbody2D;
    [SerializeField] Animator _animator;
    private GameSave _gameSave;
    Vector2 _direction;
    [SerializeField] float speed = 5f;
    [SerializeField] AudioClip _audioClip;

    bool _isRunning;

    public Text _scoring;

    void Start()
    {
        _gameSave = GameSave.instance;

        _scoring.text = "" + _gameSave._score;

        playerInput = GetComponent<PlayerInput>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
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
        playerRigidbody2D.velocity = _direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Coins"))
        {
            _gameSave._score += 1;
            _scoring.text = "" + _gameSave._score;
            AudioManager._instance.PlaySFX(_audioClip);
        }
    }
}