using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class TimerGame : MonoBehaviour
{
    private GameManager _gm;
    public float _timeLeftGame;
    public float _timeLeftLoad;
    [SerializeField] private bool _timerOn = false;
    public Text _timerTxtGame;
    public Text _timerTxtLoad;

    public bool _goLoad1 = false;
    public bool _goLoad2 = false;
    public bool _goLoad3 = false;

    public bool _goRoom1 = false;
    public bool _goRoom2 = false;
    public bool _goRoom3 = false;

    void Start()
    {
        _gm = GetComponent<GameManager>();
        _goLoad1 = true;
    }

    void Update()
    {
        if (_timerOn)
        {
            if (_timeLeftGame > 0)
            {
                _timeLeftGame -= Time.deltaTime;
                updateTimer(_timeLeftGame);
            }
            else
            {
                _timeLeftGame = 0;
                _timerOn = false;
            }

            if (_timeLeftLoad > 0)
            {
                _timeLeftLoad -= Time.deltaTime;
                updateTimer(_timeLeftLoad);
            }
            else
            {
                _timeLeftLoad = 0;
                _timerOn = false;
            }
        }

        if(_goLoad1)
        {
            _timerOn = true;
            _timeLeftLoad = 5;
            _timeLeftGame = 5;
            _timerTxtLoad.text = "" + _timeLeftLoad;

            _gm._LoadRoom1 = true;
            _goLoad1 = false;
            
        }

        if (!_goLoad1 && _timeLeftLoad == 0)
        {
            _timerOn = true;
            _timeLeftGame = 10;
            _timeLeftLoad = 10;
            _timerTxtGame.text = "" + _timerTxtGame;

            _gm._Room1 = true;
            _goLoad2 = true;
        }

        if(_goLoad2 && _timeLeftGame == 0)
        {
            _timerOn = true;
            _timeLeftGame = 5;
            _timeLeftLoad = 5;
            _timerTxtLoad.text = "" + _timeLeftLoad;

            _gm._LoadRoom2 = true;
            _goLoad2 = false;
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        _timerTxtGame.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        _timerTxtLoad.text = string.Format("{0:0}{1:0}", minutes, seconds);
    }
}
