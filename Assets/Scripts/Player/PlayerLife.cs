using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private GameSave _gameSave;

    [SerializeField] private Animator _animator;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] GameObject[] _spriteLife;
    [SerializeField] EnemyLife _enemy;
    private CinemachineImpulseSource _cinemachineImpulse;
    [SerializeField] private float _impulseForce = 1;
    [SerializeField] private AudioClip _audioClipHurt;

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

        if (_gameSave._life == 0)
        {
            _animator.SetBool("Dead", true);

            StartCoroutine(WaitForDeadPlayer());
        }

    }

    bool _touch = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.transform.TryGetComponent(out EnemyLife _zombie) && _gameSave._life > _gameSave._lifeMin && _touch == false && _enemy._life != 0)
        {
            _gameSave._life -= 1;
            _animator.SetBool("Hurt", true);
            AudioManager._instance.PlaySFX(_audioClipHurt);
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

    IEnumerator WaitForGiveDamageToPlayer()
    {
        if(_touch)
            yield return new WaitForSeconds(2);
            _touch = false;
            _animator.SetBool("Hurt", false);
    }

    IEnumerator WaitForDeadPlayer()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }
}
