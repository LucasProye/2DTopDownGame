using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TimerGame _timerGame;

    [SerializeField] private GameObject[] _level;

    Vector3 _placementLevel = new Vector3(0, 0, 0);
    public bool _level1IsPlay = false;
    public bool _level2IsPlay = false;
    public bool _level3IsPlay = false;
    public bool _level4IsPlay = false;

    private void Start()
    {
        Instantiate(_level[0], _placementLevel, quaternion.identity);
        _level1IsPlay = true;
    }

    private void LevelUpdate()
    {
        if(_timerGame._timeLeft == 0 && _level1IsPlay == true)
        {
            _level1IsPlay = false;
            Debug.Log("level 1 is false");
            Instantiate(_level[1], _placementLevel, quaternion.identity);
            _level2IsPlay = true;
            Debug.Log("level 2 is true");
        }
    }
}
