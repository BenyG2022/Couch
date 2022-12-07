using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button _buttonBack = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onBack() => MainManager.singletonInstance.onEscapeFromSettings();
    public void toggle(bool toggle)
    {
        this.gameObject.SetActive(toggle);
    }
}
