using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button _buttonPlay = null;
    [SerializeField] private UnityEngine.UI.Button _buttonSettings = null;
    [SerializeField] private UnityEngine.UI.Button _buttonQuit = null;
    [SerializeField] private Camera _menuCamera = null;
    private enum ButtonFocus { Play=0,Settings,Quit };
    private ButtonFocus _buttonFocus = ButtonFocus.Play;

    public void onButtonPlay()
    {
        toggle(false);
        MainManager.singletonInstance.changeGameStateToPlay();
    }
    public void onButtonSettings()
    {
        MainManager.singletonInstance.changeGameStateToSettings();
    }
    public void onButtonQuit()
    {
        Application.Quit();
    }
    public void toggle(bool toggle)
    {
        _menuCamera.gameObject.SetActive(toggle);
        this.gameObject.SetActive(toggle);
    }
    public System.Action changeButtonsFocus()
    {
        if(_buttonFocus == ButtonFocus.Play )
        {
            changeFocus(ButtonFocus.Settings);
            highlightButton(_buttonSettings);
            return onButtonSettings;
        }
        else if(_buttonFocus == ButtonFocus.Settings)
        {
            changeFocus(ButtonFocus.Quit);
            highlightButton(_buttonQuit);
            return onButtonQuit;
        }
        else if(_buttonFocus == ButtonFocus.Quit)
        {
            changeFocus(ButtonFocus.Play);
            highlightButton(_buttonPlay);
            return onButtonPlay; 
        }
        else
        {
            return null;
        }
    }
    private void changeFocus(ButtonFocus focus)
    {
        _buttonFocus = focus;
    }
    private void highlightButton(UnityEngine.UI.Button button)
    {
        turnHighligtButtonOff(_buttonQuit);
        turnHighligtButtonOff(_buttonPlay);
        turnHighligtButtonOff(_buttonSettings);
        var colors = button.colors;
        colors.normalColor = Color.yellow;
        button.colors = colors;
    }
    private void turnHighligtButtonOff(UnityEngine.UI.Button button)
    {
        var colors = button.colors;
        colors.normalColor = Color.grey;
        button.colors = colors;
    }
}
