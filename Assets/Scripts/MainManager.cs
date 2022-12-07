using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    
    [SerializeField] private Options _settings = null;
    [SerializeField] private MainMenu _menu = null;
    private enum CurrentGameState { MainMenu = 0, Settings, Play };
    private CurrentGameState _gameState = CurrentGameState.MainMenu;
    public static MainManager singletonInstance = null;

    System.Action onKeyboardButtonPress = null;
    void Start()
    {
        if (singletonInstance == null)
        {
            singletonInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) == true)
        {
            if (_gameState == CurrentGameState.MainMenu)
            {
                Application.Quit();
            }
            else if (_gameState == CurrentGameState.Settings)
            {
                onEscapeFromSettings();
            }
            else
            {
                onEscapeFromPlay();
            }
        }
        if (Input.GetKeyUp(KeyCode.Tab) == true)
        {
            changeCurrentFocusOnButton();
        }
        if (Input.GetKeyUp(KeyCode.Return) == true)
        {
            if (onKeyboardButtonPress != null)
            {
                onKeyboardButtonPress();
            }
            else
            {
                Debug.LogWarning("No Focus on Button for Keyboard press");
            }
        }
    }
    private void changeCurrentFocusOnButton()
    {
        onKeyboardButtonPress = _menu.changeButtonsFocus();
    }

    public void onEscapeFromPlay()
    {
        _gameState = CurrentGameState.MainMenu;
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Play");
        UnityEngine.SceneManagement.SceneManager.SetActiveScene(
            UnityEngine.SceneManagement.SceneManager.GetSceneByName("Menu"));
        _menu.toggle(true);
    }
    public void onEscapeFromSettings()
    {
        _settings.toggle(false);
        _menu.toggle(true);
    }
    public void changeGameStateToPlay()
    {
        _gameState = CurrentGameState.Play;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Play", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
    public void changeGameStateToSettings()
    {
        _gameState = CurrentGameState.Settings;
        _menu.toggle(false);
        _settings.toggle(true);
    }
}
