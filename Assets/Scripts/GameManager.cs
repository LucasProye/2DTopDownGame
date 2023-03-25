using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TimerGame _timerGame;
    [SerializeField] private GameObject _level1;
    [SerializeField] private GameObject _level2;
    [SerializeField] private GameObject _level3;

    private void Start()
    {
        Instantiate(_level1, transform.position, quaternion.identity);
    }

    private void Update()
    {
        
    }


}
