using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GameSave : MonoBehaviour
{
    public static GameSave instance { private set; get; }

    [Header ("Player Life")]
    public int _life = 0;
    public int _lifeMax = 6;
    public int _lifeMin = 0;

    [Header ("ScoreCoins")]
    public int _score = 0;


    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        _life = 6;
        _score = 0;
    }
}
