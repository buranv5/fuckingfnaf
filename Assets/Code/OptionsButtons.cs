using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButtons : MonoBehaviour
{
    [SerializeField] private GameObject ButtonsInMenu;
    [SerializeField] private GameObject ButtonsInOptions;
    [SerializeField] private AudioSource Click;

    [SerializeField] private TMPro.TMP_Text SwichText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("UnlimitPower"))
        {
            if (PlayerPrefs.GetInt("UnlimitPower") == 1)
            {
                SwichText.text = "On";
            }
            else
            {
                SwichText.text = "Off";
            }
        }
        else
        {
            SwichText.text = "Off";
        }
    }
    public void OnBackClick()
    {
        Click.Play();
        ButtonsInOptions.SetActive(false);
        ButtonsInMenu.SetActive(true);
    }

    public void OnUnlimitPowerClick()
    {
        Click.Play();
        if (SwichText.text == "Off")
        {
            SwichText.text = "On";
            PlayerPrefs.SetInt("UnlimitPower", 1);
            PlayerPrefs.Save();
        }
        else
        {
            SwichText.text = "Off";
            PlayerPrefs.SetInt("UnlimitPower", 0);
            PlayerPrefs.Save();
        }
    }
}
