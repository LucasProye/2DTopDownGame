using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    bool _attack;
    Vector2 _mousePosition;
    [SerializeField] Animator _bulletAnimation;
    [SerializeField] Transform[] _bullet;

    public void Attack(InputAction.CallbackContext callback)
    {
        _attack = callback.performed;
    }

    private void Update()
    {
        if (_attack)
        {
            Transform newProjectile = Instantiate(_bullet[0], transform.position, Quaternion.identity);

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(_mousePosition);
            Vector3 direction = worldPosition - transform.position;
            direction.z = 0;

            newProjectile.right = direction;
        }
    }

    public void Mouse(InputAction.CallbackContext callback)
    {
        _mousePosition = callback.ReadValue<Vector2>();
    }
}
