using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TimerGame _timerGame;
    public Vector3 _placementLevel = new Vector3(0, 0, 0);
    GameObject loadedLevel;

    [Header("Player Infos")]
    //[SerializeField] private Transform _plTransform;
    /*Vector3 _positionR1 = new Vector3(0, 0, 0);
    Vector3 _positionR2 = new Vector3(0, 0, 0);
    Vector3 _positionR3 = new Vector3(0, 0, 0);*/

    [Header("Spawn Point")]
    /*[SerializeField] private Transform _spawnR1;
    [SerializeField] private Transform _spawnR2;
    [SerializeField] private Transform _spawnR3;*/

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
            //_positionR1 = _spawnR1.position;
            //_plTransform.position = _positionR1;
            _load.SetActive(false);
            _Room1 = false;
            //_level.SetActive(true);

            loadedLevel = Instantiate(_level[0], _placementLevel, Quaternion.identity);
        }

        // Load2 Actif
        if (_LoadRoom2)
        {
            _load.SetActive(true);
            _LoadRoom2 = false;
            Destroy(loadedLevel);
            //_level.SetActive(false);

        }

        // Level2 Instantiate
        if (_Room2)
        {
            //_positionR2 = _spawnR2.position;
            //_plTransform.position = _positionR2;
            _load.SetActive(false);
            _Room2 = false;
            //_level.SetActive(true);

            loadedLevel = Instantiate(_level[1], _placementLevel, Quaternion.identity);
        }

        // Load3 Actif
        if (_LoadRoom3)
        {
            _load.SetActive(true);
            _LoadRoom3 = false;
            Destroy(loadedLevel);
            //_level.SetActive(false);
        }

        // Level2 Instantiate
        if (_Room3)
        {
            //_positionR3 = _spawnR3.position;
            //_plTransform.position = _positionR3;
            _load.SetActive(false);
            _Room3 = false;
            //_level.SetActive(true);

            loadedLevel = Instantiate(_level[2], _placementLevel, Quaternion.identity);
        }
    }
}
