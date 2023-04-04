using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Kit : MonoBehaviour
{
    [SerializeField] private PlayerLife _playerLife;
    [SerializeField] private Items _items;
    [SerializeField] private Text _nbHeal;
    bool _heal = false;

    private void Start()
    {
        _items._nbKit = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") /*&& _playerLife._life > 0 && _playerLife._life < 5*/)
        {
            /*_playerLife._life++;
            _playerLife._lifeTxt.text = "" + _playerLife._life;*/
            _items._nbKit++;
            _nbHeal.text = "" + _items._nbKit;
            gameObject.SetActive(false);
        }
    }

    public void Heal(InputAction.CallbackContext context)
    {
        _heal = context.performed;

        if(_heal && _items._nbKit > 0 && _playerLife._life > 0 && _playerLife._life < 5)
        {
            _items._nbKit --;
            _playerLife._life ++;
            _playerLife._lifeTxt.text = "" + _playerLife._life;
            _nbHeal.text = "" + _items._nbKit;
            print("Player Heal = true");
        }
    }
}
