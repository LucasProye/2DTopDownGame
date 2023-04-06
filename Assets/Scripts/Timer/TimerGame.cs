using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class TimerGame : MonoBehaviour
{
    private GameManager _gm;
    [SerializeField] private GameObject _camera;
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

        TimeForRoom();
    }

    private void TimeForRoom()
    {
        StartCoroutine(WaitForPrintRoom());
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        _timerTxtGame.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        _timerTxtLoad.text = string.Format("{0:0}{1:0}", minutes, seconds);
    }

    void ConfigurationTimerLoad()
    {
        _timerOn = true;
        _timeLeftLoad = 1;
        _timeLeftGame = 1;
        _timerTxtLoad.text = "" + _timeLeftLoad;
    }

    void ConfigurationTimerGame()
    {
        _timerOn = true;
        _timeLeftGame = 280;
        _timeLeftLoad = 280;
        _timerTxtGame.text = "" + _timerTxtGame;
    }

    IEnumerator WaitForPrintRoom()
    {
        if(_goLoad1)
        {
            _camera.SetActive(true);

            _goLoad1 = false;
            _gm._LoadRoom1 = true;

            ConfigurationTimerLoad();

            yield return new WaitForSeconds(1);

            _goRoom1 = true;
        }

        if (_goRoom1)
        {
            _camera.SetActive(false);

            _goRoom1 = false;
            _gm._Room1 = true;

            ConfigurationTimerGame();

            yield return new WaitForSeconds(280);

            _goLoad2 = true;
        }

        if (_goLoad2)
        {
            _camera.SetActive(true);

            _goLoad2 = false;
            _gm._LoadRoom2 = true;

            ConfigurationTimerLoad();

            yield return new WaitForSeconds(1);

            _goRoom2 = true;
        }

        if (_goRoom2)
        {
            _camera.SetActive(false);

            _goRoom2 = false;
            _gm._Room2 = true;

            ConfigurationTimerGame();

            yield return new WaitForSeconds(280);

            _goLoad3 = true;
        }

        if (_goLoad3)
        {
            _camera.SetActive(true);

            _goLoad3 = false;
            _gm._LoadRoom3 = true;

            ConfigurationTimerLoad();

            yield return new WaitForSeconds(1);

            _goRoom3 = true;
        }

        if (_goRoom3)
        {
            _camera.SetActive(false);

            _goRoom3 = false;
            _gm._Room3 = true;

            ConfigurationTimerGame();

            yield return new WaitForSeconds(280);

            //MenuEndGame
        }
    }
}
