using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    bool _attack;

    private Mouse _mouse;

    [SerializeField] Animator _bulletAnimation;

    [SerializeField] Transform _positionBullet;
    [SerializeField] Transform _bullet;
    [SerializeField] float _bulletSpeed = 20f;
    Vector2 _worldPosition;
    float _lookAngle;

    private void Awake()
    {
        _mouse = Mouse.current;
    }

    public void Attack(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            Vector2 direction = GetAim();

            if (direction.x < 0) return;

            Bullet newBullet = Instantiate(_bullet).GetComponent<Bullet>();
            newBullet.transform.position = _positionBullet.position;
            newBullet.SetDirection(direction);
        }
    }

    private Vector2 GetAim()
    {
        Resolution resolution = Screen.currentResolution;
        Vector2 screenSize = new Vector2(resolution.width, resolution.height);
        Vector2 sampleMousePosition = _mouse.position.ReadValue() - screenSize / 2;
        return sampleMousePosition.normalized;
    }
}
