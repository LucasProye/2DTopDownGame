using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private TimerGame _timerGame;
    public Vector3 _placementLevel = new Vector3(0, 0, 0);
    public GameObject _loadedLevel;

    [Header ("Loading Screen")]
    [SerializeField] private GameObject _load;
    public bool _LoadRoom1 = false;
    public bool _LoadRoom2 = false;
    public bool _LoadRoom3 = false;
    public bool _LoadRoom4 = false;

    [Header("Level")]
    public GameObject[] _level;
    public bool _Room1 = false;
    public bool _Room2 = false;
    public bool _Room3 = false;
    public bool _Room4 = false;

    private void Start()
    {
        _timerGame = GetComponent<TimerGame>();
    }

    private void Update()
    {
        LevelUpdate(); 
    }

    private void LevelUpdate()
    {
        // Load1 actif
        if (_LoadRoom1)
        {
            _load.SetActive(true);
            _LoadRoom1 = false;
        }

        // Level1 Instantiate
        if (_Room1)
        {

            _load.SetActive(false);
            _Room1 = false;

            _loadedLevel = Instantiate(_level[0], _placementLevel, Quaternion.identity);
        }

        // Load2 Actif
        if (_LoadRoom2)
        {
            _load.SetActive(true);
            _LoadRoom2 = false;
            Destroy(_loadedLevel);
        }

        // Level2 Instantiate
        if (_Room2)
        {
            _load.SetActive(false);
            _Room2 = false;

            _loadedLevel = Instantiate(_level[1], _placementLevel, Quaternion.identity);
        }

        // Load3 Actif
        if (_LoadRoom3)
        {
            _load.SetActive(true);
            _LoadRoom3 = false;
            Destroy(_loadedLevel);
        }

        // Level2 Instantiate
        if (_Room3)
        {
            _load.SetActive(false);
            _Room3 = false;

            _loadedLevel = Instantiate(_level[2], _placementLevel, Quaternion.identity);
        }
    }
}
