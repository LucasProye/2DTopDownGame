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

    //[Header("Bool pour timer")]
    /*public bool _level1IsPlay = false;
    public bool _level2IsPlay = false;
    public bool _level3IsPlay = false;
    public bool _level4IsPlay = false;*/

    private void Awake()
    {
        //_level1IsPlay = true;
    }

    private void Start()
    {
        _timerGame = GetComponent<TimerGame>();
        
        /*loadedLevel = Instantiate(_level[0], _placementLevel, Quaternion.identity);
        print("Level 1 = true");*/
    }

    private void Update()
    {
        LevelUpdate(); 
    }

    private void LevelUpdate()
    {

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
            loadedLevel = Instantiate(_level[0], _placementLevel, Quaternion.identity);
        }

        if(_LoadRoom2)
        {
            _load.SetActive(true);
            _LoadRoom2 = false;
            Destroy(loadedLevel);
        }







        /*// LoadingScreen 1 Instantiate
        if(_LoadRoom1)
        {
            _load[0].SetActive(true);
            print(_LoadRoom1);
        }

        // Level1 Instantiate
        if(_Room1)
        {
            _load[0].SetActive(false);
            _LoadRoom1 = false;
            loadedLevel = Instantiate(_level[0], _placementLevel, Quaternion.identity);
            print(_Room1);
            _Room1 = false;
            _LoadRoom2 = true;
        }

        if (_LoadRoom2)
        {
            _load[0].SetActive(true);
            print(_LoadRoom2);
        }*/

        /*//Level 2 instantiate
        if (_timerGame._timeLeft == 0 && _timerGame._level1 == true)
        {
            Destroy(loadedLevel);
            _level2IsPlay = true;
            loadedLevel = Instantiate(_level[1], _placementLevel, Quaternion.identity);
            print("Level 2 = true");
            _timerGame._level1 = false;
        }

        //Level 3 instantiate
        if (_timerGame._timeLeft == 0 && _timerGame._level2 == true)
        {
            Destroy(loadedLevel);
            _level3IsPlay = true;
            loadedLevel = Instantiate(_level[2], _placementLevel, Quaternion.identity);
            print("Level 3  = true");
            _timerGame._level2 = false;
        }*/
    }
}
