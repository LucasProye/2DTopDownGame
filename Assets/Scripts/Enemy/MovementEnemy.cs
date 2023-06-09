using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    public float _speed;
    [SerializeField] private float _distanceBetween;
    [SerializeField] private float _distance;

    [SerializeField] private EnemyLife _enemyLife;
    [SerializeField] Animator _animator;

    private void Update()
    {
        _distance = Vector2.Distance(transform.position, _player.transform.position);

        if(_distance < _distanceBetween)
        {
            Vector2 velocity = new Vector2((transform.position.x - _player.transform.position.x) * _speed, (transform.position.y - _player.transform.position.y) * _speed);
            GetComponent<Rigidbody2D>().velocity = -velocity;
            _animator.SetBool("Run", true);
        }


        if(_distance > _distanceBetween)
        {
            _animator.SetBool("Run", false);
        }

        if(_enemyLife._isAlive == false)
        {
            _speed = 0;
        }
    }
}
