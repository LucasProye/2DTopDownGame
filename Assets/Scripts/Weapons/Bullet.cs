using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 direction;
    private Animator _anim;

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 _dir) {
        transform.localRotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, _dir));
        direction = _dir; }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + _speed * Time.fixedDeltaTime * direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall") || collision.CompareTag("Enemy"))
        {
            _anim.SetBool("BulletTouch", true);
            StartCoroutine(WaitForDestroyBullet());
        }
    }

    IEnumerator WaitForDestroyBullet()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
