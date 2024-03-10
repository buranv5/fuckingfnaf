using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButtons : MonoBehaviour
{
    [SerializeField] private GameObject ButtonsInMenu;
    [SerializeField] private GameObject ButtonsInOptions;
    [SerializeField] private AudioSource Click;

    public void OnBackClick()
    {
        Click.Play();
        ButtonsInOptions.SetActive(false);
        ButtonsInMenu.SetActive(true);
    }
}
