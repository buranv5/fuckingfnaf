using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text LevelText;
    private int ThenLevel;

    [SerializeField] private GameObject ButtonsInMenu;
    [SerializeField] private GameObject ButtonsInOptions;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            ThenLevel = PlayerPrefs.GetInt("Level");
        }
        else 
        {
            ThenLevel = 1;
        }
        LevelText.text = $"Night {ThenLevel}";
        ButtonsInOptions.SetActive(false);
    }
    public void OnNewGameClick() 
    {
        SceneManager.LoadScene("MainRoom");
        PlayerPrefs.SetInt("Level", ThenLevel);
        PlayerPrefs.Save();
    }

    public void OnContinueClick()
    {
        SceneManager.LoadScene("MainRoom");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    public void OnOptionsClick()
    {
        ButtonsInMenu.SetActive(false);
        ButtonsInOptions.SetActive(true);
    }
}
