using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 direction;

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 _dir) {
        transform.localRotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, _dir));
        direction = _dir; }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + speed * Time.fixedDeltaTime * direction);
    }
    /*[Header("Set up")]
    [SerializeField] int damage;

    [SerializeField] float speed;

    private void Start()
    {
        Destroy(gameObject, 2);
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            *//*var target = other.GetComponent<Life>();*/
    /*target.Damage(damage);*//*
}
}*/
}
