using UnityEngine;
using UnityEngine.InputSystem;

public class Weapons : MonoBehaviour
{
    PlayerInput _playerInput;
    Vector2 _rotateFire;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }
    public void Mouse(InputAction.CallbackContext context)
    {
        _rotateFire = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        var worldPosition = Camera.main.ScreenToWorldPoint(_rotateFire);
        var direction = worldPosition - transform.position;
        direction.z = 0f;
        direction.Normalize();
        if(direction.x > 0.5f)
            transform.right = direction;
    }
}