using System.Collections;
using System.Collections.Generic;
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

    public void Shoot(InputAction.CallbackContext context)
    {
        
    }

    private void Update()
    {
        //Vector3 _objectPos = Camera.main.WorldToScreenPoint(transform.position);
        //_rotateFire.x = _rotateFire.x - _objectPos.x;
        //_rotateFire.y = _rotateFire.y - _objectPos.y;

        //float _angle = Mathf.Atan2(_rotateFire.y, _rotateFire.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, _angle));
        var worldPosition = Camera.main.ScreenToWorldPoint(_rotateFire);
        var direction = worldPosition - transform.position;
        direction.z = 0f;
        direction.Normalize();
        if(direction.x > 0.5f)
            transform.right = direction;
    }
}