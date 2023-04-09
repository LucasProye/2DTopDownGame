using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private GameSave _gameSave;

    private void Start()
    {
        _gameSave = GameSave.instance;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        _gameSave._life = 6;
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
				        Application.Quit();
        #endif
    }
}
