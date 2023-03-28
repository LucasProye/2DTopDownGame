using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TimerGame _timerGame;
    public GameObject[] _level;
    public Vector3 _placementLevel = new Vector3(0, 0, 0);

    [Header("Bool pour timer")]
    public bool _level1IsPlay = false;
    public bool _level2IsPlay = false;
    public bool _level3IsPlay = false;
    public bool _level4IsPlay = false; 

    private void Awake()
    {
        _level1IsPlay = true;
    }

    private void Start()
    {
        _timerGame = GetComponent<TimerGame>();
        Instantiate(_level[0], _placementLevel, Quaternion.identity);
        print("Level 1 = true");
    }

    private void Update()
    {
        LevelUpdate();
    }

    private void LevelUpdate()
    {
        if (_timerGame._timeLeft == 0 && _timerGame._level1 == true)
        {
            _level2IsPlay = true;
            Instantiate(_level[1], _placementLevel, Quaternion.identity);
            print("Level 2 = true");
            _timerGame._level1 = false;
        }

        if (_timerGame._timeLeft == 0 && _timerGame._level2 == true)
        {
            _level3IsPlay = true;
            Instantiate(_level[2], _placementLevel, Quaternion.identity);
            print("Level 3  = true");
            _timerGame._level2 = false;
        }
    }
}
