using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
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

    private void Awake()
    {
        _level1IsPlay = true;
    }

    private void Start()
    {
        _timerGame = GetComponent<TimerGame>();
        Instantiate(_level[0], _placementLevel, quaternion.identity);
    }
    private void Update()
    {
        LevelUpdate();
    }

    private void LevelUpdate()
    {
        if(_timerGame._timeLeft == 0 && _level1IsPlay == false)
        {
            _level2IsPlay = true;
            Instantiate(_level[1], _placementLevel, quaternion.identity);
            Debug.Log("level 2 is true");
        }
    }
}
