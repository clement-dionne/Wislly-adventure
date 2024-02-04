using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    #region Unity Public
    public string GameScene;
    public GameObject SettingsPanel;
    public GameObject MainPanel;
    #endregion

    #region Unity Private

    #endregion

    public void Start()
    {
        SettingsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void OpenSettingsPanel()
    {
        SettingsPanel.SetActive(true);
        MainPanel.SetActive(false);
    }
    
    public void CloseSettingsPanel()
    {
        SettingsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
