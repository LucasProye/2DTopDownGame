using UnityEngine;

public class GameSave : MonoBehaviour
{
    public static GameSave instance { private set; get; }
    [Header ("Player Life")]
    public int _life = 0;
    public int _lifeMax = 6;
    public int _lifeMin = 0;
    [Header ("ScoreCoins")]
    public int _score = 0;

    private void Awake()
    {
        _life = 6;
    }

    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        _score = 0;
    }
}
