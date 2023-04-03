using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public int _life;
    [SerializeField] private int _lifeMax = 5;
    [SerializeField] private int _lifeMin = 0;
    public Text _lifeTxt;

    bool _isAlive = true;
    bool _isTouch = false;


    private void Start()
    {
        _life = 5;
        _lifeTxt.text = "" + _life;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && _life != _lifeMin)
        {
            _life--;
            _lifeTxt.text = "" + _life;
        }
    }

    private void Life()
    {
        if(_life == 0)
        {
            _isAlive = false;
        }
    }
}
