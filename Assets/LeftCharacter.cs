using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeftCharacter : MonoBehaviour
{
    [SerializeField] private GameObject[] LeftSprites = new GameObject[4];
    [SerializeField] private GameObject LeftCharInWindow;
    [SerializeField] private GameObject LeftCharInDoor;
    [SerializeField] private GameObject LeftCharScreamer;
    [SerializeField] private GameObject LossScreen;
    [SerializeField] private AudioSource LeftRoom;
    [SerializeField] private GameObject LeftDoor;

    [SerializeField] private GameObject CameraCanvas;

    [SerializeField] private GameObject LeftLight;
    [SerializeField] private AudioSource LeftWindowScare;
    [SerializeField] private AudioSource LeftDoorPunth;

    private int CharPosition;
    private int CharNumber;
    private bool InRoom = false;

    public void Start()
    {
        CharNumber = 0;
        CharPosition = 0;
        if (PowerLevelTime.ThenLevel > 1)
        {
            CharPosition = 1;
            LeftSprites[CharNumber].SetActive(true);
            StartCoroutine(GoInCamera());
        }
    }
    public IEnumerator GoInCamera()
    {
            yield return new WaitForSeconds(20f);
            float RandomCreate = Random.value;
            if (RandomCreate > 0.2f && !InRoom)
            {
                LeftRoom.Play();
                RandomCreate = Random.value;
                if (RandomCreate > 0.3f)
                {
                    if (CharNumber == 3)
                    {
                        InRoom = true;
                        LeftSprites[CharNumber].SetActive(false);
                        CharNumber = 1;
                        StartCoroutine(LeftCharAtack());
                        LeftRoom.Play();
                    }
                    else
                    {
                        LeftSprites[CharNumber].SetActive(false);
                        CharNumber += 1;
                        LeftRoom.Play();
                    }
                }
                else
                {
                    if (CharNumber > 0)
                    {
                        LeftSprites[CharNumber].SetActive(false);
                        CharNumber -= 1;
                        LeftRoom.Play();
                    }
                }
                switch (CharNumber)
                {
                    case 0: CharPosition = 1; break;
                    case 1: CharPosition = 4; break;
                    case 2: CharPosition = 8; break;
                    case 3: CharPosition = 9; break;
                }
            }
            if (UseCameraToNumber.ActiveCameraNumber + 1 == CharPosition && !InRoom)
            {
                LeftSprites[CharNumber].SetActive(true);
            }
            else
            {
                LeftSprites[CharNumber].SetActive(false);
            }
            StartCoroutine(GoInCamera());
    }

    public void OnCameraSwipe()
    {
        if (UseCameraToNumber.ActiveCameraNumber + 1 == CharPosition && !InRoom)
        {
            LeftSprites[CharNumber].SetActive(true);
        }
        else
        {
            LeftSprites[CharNumber].SetActive(false);
        }
    }

    private IEnumerator LeftCharAtack()
    {
        yield return new WaitForSeconds(2f);
        LeftCharInWindow.SetActive(false);
        LeftCharInDoor.SetActive(true);
        yield return new WaitForSeconds(2f);
        if (LeftDoor.GetComponent<DoorOpenClose>().IsOpen == false)
        {
            LeftDoorPunth.Play();
            yield return new WaitForSeconds(2f);
            LeftCharInDoor.SetActive(false);
            LeftCharInWindow.SetActive(true);
            if (LeftLight.GetComponent<LightOnOff>().IsOn == true)
            {
                LeftWindowScare.Play();
                yield return new WaitForSeconds(1f);
                LeftCharInWindow.SetActive(false);
                InRoom = false;
            }
            else
            {
                StartCoroutine(LeftCharAtack());
            }
        }
        else
        {
            CameraCanvas.SetActive(false);
            LeftCharScreamer.SetActive(true);
            LeftCharScreamer.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(3f);
            LossScreen.SetActive(true);
            LossScreen.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("Menu");
        }
    }
}
