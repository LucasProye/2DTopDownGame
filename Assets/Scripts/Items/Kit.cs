using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Kit : MonoBehaviour
{
    [SerializeField] private PlayerLife _playerLife;
    [SerializeField] private Text _nbHeal;
    [SerializeField] AudioClip _audioClip;
    [SerializeField] private GameSave _gameSave;
    private void Start()
    {
        _gameSave = GameSave.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _gameSave._life > 0 && _gameSave._life < 6)
        {
            _gameSave._life++;
            AudioManager._instance.PlaySFX(_audioClip);
            gameObject.SetActive(false);
        }
    }
}
