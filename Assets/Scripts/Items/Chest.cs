using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    [SerializeField] private GameObject _coins;

    bool _playerIsHere = false;

    public void Use(InputAction.CallbackContext context)
    {
        if(context.started && _playerIsHere == true)
        {
            _coins.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _playerIsHere = true;
            _text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerIsHere = false;
            _text.SetActive(false);
        }
    }
}
