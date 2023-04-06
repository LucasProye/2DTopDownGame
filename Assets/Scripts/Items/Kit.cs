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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _playerLife._life > 0 && _playerLife._life < 5)
        {
            _playerLife._life++;
            _playerLife._lifeTxt.text = "" + _playerLife._life;
            gameObject.SetActive(false);
        }
    }
}
