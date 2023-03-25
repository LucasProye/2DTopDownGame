using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class TimerGame : MonoBehaviour
{
    private GameManager _gm;
    public float _timeLeft;
    [SerializeField] private bool _timerOn = false;
    public Text _timerTxt;

    void Start()
    {
        _timerOn = true;
    }

    void Update()
    {
        if (_timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                updateTimer(_timeLeft);
            }
            else
            {
                _timeLeft = 0;
                _timerOn = false;
            }
        }

        if(_gm._level1IsPlay == true)
        {
            _timeLeft = 5;
        }

        if (_gm._level2IsPlay == true)
        {
            _timeLeft = 10;
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        _timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
