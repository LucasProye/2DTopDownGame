using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
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
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        _rotateFire.x = _rotateFire.x - objectPos.x;
        _rotateFire.y = _rotateFire.y - objectPos.y;

        float _angle = Mathf.Atan2(_rotateFire.y, _rotateFire.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, _angle));
        print(transform.rotation);
    }
}