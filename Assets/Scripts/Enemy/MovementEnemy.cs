using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceBetween;
    [SerializeField] private float _distance;

    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _distance = Vector2.Distance(transform.position, _player.transform.position);
        /*Vector2 _direction = _player.transform.position - transform.position;
        _direction.Normalize();*/

        if(_distance < _distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, _player.transform.position, _speed * Time.deltaTime);
            _animator.SetBool("Run", true);
        }

        if(_distance > _distanceBetween)
        {
            _animator.SetBool("Run", false);
        }
    }

    
}
