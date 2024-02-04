using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    #region Unity Public
    public GameObject PausePanel;
    public GameObject SettingsPanel;
    public GameObject GamePanel;
    public string MainScene;

    public SaveData Save;
    public LoadData Load;
    #endregion

    #region Unity Private

    #endregion

    public void Start()
    {
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           if (!PausePanel.activeInHierarchy) OpenPausePanel();
           else if (PausePanel.activeInHierarchy) ClosePausePanel();
        }
    }

    public void OpenPausePanel()
    {
        PausePanel.SetActive(true);
        SettingsPanel.SetActive(false);
        GamePanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void ClosePausePanel()
    {
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(false);
        GamePanel.SetActive(true);
        Time.timeScale = 1;
    }

    public void SaveState()
    {
        Save.SaveAllData();
        ClosePausePanel();
    }

    public void LoadState()
    {
        Load.LoadAllData();
        ClosePausePanel();
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(MainScene);

    }

    public void OpenSettings()
    {
        SettingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
    }
}