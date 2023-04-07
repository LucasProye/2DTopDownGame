using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{
    public int _life;
    [SerializeField] private int _lifeMax = 6;
    [SerializeField] private int _lifeMin = 0;
    [SerializeField] private Animator _animator;
    [SerializeField] private MovementEnemy _enemyMovement;
    [SerializeField] GameObject[] _spriteLife;

    bool _touch = false;
    public bool _isAlive = true;

    private void Start()
    {
        _life = 4;
    }

    private void Update()
    {
        if (_life == 4)
            _spriteLife[0].SetActive(true);
        else
            _spriteLife[0].SetActive(false);

        if (_life == 3)
            _spriteLife[1].SetActive(true);
        else
            _spriteLife[1].SetActive(false);

        if (_life == 2)
            _spriteLife[2].SetActive(true);
        else
            _spriteLife[2].SetActive(false);

        if (_life == 1)
            _spriteLife[3].SetActive(true);
        else
            _spriteLife[3].SetActive(false);

        if(_life == 0)
        {
            _isAlive = false;
            _animator.SetBool("Dead", true);
        } 
        else
        {
            _animator.SetBool("Dead", false);
        }

        if (_touch)
            StartCoroutine(WaitForAnimation());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") && _life > _lifeMin && _touch == false)
        {
            _life -= 1;
            _animator.SetBool("HurtEnemy", true);
            _touch = true;
        }                
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool("HurtEnemy", false);
        _touch = false;
    }
}
