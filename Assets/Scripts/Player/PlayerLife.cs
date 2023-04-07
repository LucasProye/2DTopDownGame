using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class PlayerLife : MonoBehaviour
{
    private GameSave _gameSave;

    [SerializeField] private Animator _animator;

    [SerializeField] GameObject[] _spriteLife;

    private CinemachineImpulseSource _cinemachineImpulse;
    [SerializeField] private float _impulseForce = 1;

    bool _isAlive = true;
    bool _isTouch = false;

    private void Start()
    {
        _cinemachineImpulse = GetComponent<CinemachineImpulseSource>();
        _gameSave = GameSave.instance;
    }

    private void Update()
    {
        if (_gameSave._life == 6)
            _spriteLife[0].SetActive(true);
        else
            _spriteLife[0].SetActive(false);

        if (_gameSave._life == 5)
            _spriteLife[1].SetActive(true);
        else
            _spriteLife[1].SetActive(false);

        if (_gameSave._life == 4)
            _spriteLife[2].SetActive(true);
        else
            _spriteLife[2].SetActive(false);

        if (_gameSave._life == 3)
            _spriteLife[3].SetActive(true);
        else
            _spriteLife[3].SetActive(false);

        if (_gameSave._life == 2)
            _spriteLife[4].SetActive(true);
        else
            _spriteLife[4].SetActive(false);

        if (_gameSave._life == 1)
            _spriteLife[5].SetActive(true);
        else
            _spriteLife[5].SetActive(false);

        Life();
    }

    bool _touch = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && _gameSave._life > _gameSave._lifeMin && _touch == false)
        {
            _gameSave._life -= 1;
            _animator.SetBool("Hurt", true);
            _cinemachineImpulse.GenerateImpulseWithForce(_impulseForce);
            _touch = true;
        }

        if (_touch)
        {
            StartCoroutine(WaitForGiveDamageToPlayer());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            _touch = true;
    }   

    private void Life()
    {
        if(_gameSave._life < 1)
        {
            _isAlive = false;
        }

        if(!_isAlive)
        {
            //Animation de mort
        }
    }

    IEnumerator WaitForGiveDamageToPlayer()
    {
        if(_touch)
            yield return new WaitForSeconds(2);
            _touch = false;
            _animator.SetBool("Hurt", false);
    }
}
