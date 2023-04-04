using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    bool _attack;
    Vector2 _mousePosition;
    [SerializeField] Animator _bulletAnimation;

    [SerializeField] Transform _positionBullet;
    [SerializeField] GameObject _bullet;
    float _bulletSpeed = 20f;
    Vector2 _worldPosition;
    float _lookAngle;

    /*[SerializeField] float timeBeforeAttack;
    [SerializeField] float maxTimeBeforeAttack = 1;
    [SerializeField] float minTimeBeforeAttack = 0;*/

    public void Attack(InputAction.CallbackContext callback)
    {
        _attack = callback.performed;
    }

    public void Mouse(InputAction.CallbackContext callback)
    {
        _mousePosition = callback.ReadValue<Vector2>();
    }

    private void Update()
    {
        _worldPosition = Camera.main.ScreenToWorldPoint(_mousePosition);
        _lookAngle = Mathf.Atan2(_mousePosition.y, _mousePosition.x) * Mathf.Rad2Deg;

        _positionBullet.rotation = Quaternion.Euler(0, 0, _lookAngle);

        if (_attack)
        {
            GameObject newBullet = Instantiate(_bullet);
            newBullet.transform.position = _positionBullet.position;
            newBullet.transform.rotation = Quaternion.Euler(0, 0, _lookAngle);

            newBullet.GetComponent<Rigidbody2D>().velocity = _positionBullet.right * _bulletSpeed;
        }
    }

















}
