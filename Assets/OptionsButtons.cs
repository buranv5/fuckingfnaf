using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButtons : MonoBehaviour
{
    [SerializeField] private GameObject ButtonsInMenu;
    [SerializeField] private GameObject ButtonsInOptions;

    public void OnBackClick()
    {
        ButtonsInOptions.SetActive(false);
        ButtonsInMenu.SetActive(true);
    }
}
