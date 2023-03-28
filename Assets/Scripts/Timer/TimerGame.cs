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

    public bool _level1 = false;
    public bool _level2 = false;
    
    void Start()
    {
        _timerOn = true;
        _gm = GetComponent<GameManager>();
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

        if (_gm._level1IsPlay == true)
        {
            _timerOn = true;
            _timeLeft = 5;
            _level1 = true;
            _gm._level1IsPlay = false;
        }

        if (_gm._level2IsPlay == true)
        {
            _timerOn = true;
            _timeLeft = 10;
            _level2 = true;
            _gm._level2IsPlay = false;
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
