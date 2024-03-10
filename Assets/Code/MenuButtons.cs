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

    [SerializeField] private AudioSource Click;

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
        Click.Play();
        SceneManager.LoadScene("MainRoom");
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.Save();
    }

    public void OnContinueClick()
    {
        Click.Play();
        SceneManager.LoadScene("MainRoom");
    }

    public void OnExitClick()
    {
        Click.Play();
        Application.Quit();
    }

    public void OnOptionsClick()
    {
        Click.Play();
        ButtonsInMenu.SetActive(false);
        ButtonsInOptions.SetActive(true);
    }
}
