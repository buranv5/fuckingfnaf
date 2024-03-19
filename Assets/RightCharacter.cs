using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RightCharacter : MonoBehaviour
{
    [SerializeField] private GameObject[] RightSprites = new GameObject[6];
    [SerializeField] private GameObject RightCharInWindow;
    [SerializeField] private GameObject RightCharInDoor;
    [SerializeField] private GameObject RightCharScreamer;
    [SerializeField] private GameObject LossScreen;
    [SerializeField] private AudioSource RightRoom;
    [SerializeField] private GameObject RightDoor;

    [SerializeField] private GameObject CameraCanvas;

    [SerializeField] private GameObject RightLight;

    private int CharPosition;
    private int CharNumber;
    private bool InRoom = false;

    public void Start()
    {
        CharNumber = 0;
        CharPosition = 1;
        StartCoroutine(GoInCamera());
    }
    public IEnumerator GoInCamera()
    {
        yield return new WaitForSeconds(5f);
        float RandomCreate = Random.value;
        if (RandomCreate > 0f && !InRoom)
        {
            RightRoom.Play();
            RandomCreate = Random.value;
            if (RandomCreate > 0.3f)
            {
                if (CharNumber == 5)
                {
                    InRoom = true; 
                    RightSprites[CharNumber].SetActive(false);
                    CharNumber = 0;
                    StartCoroutine(RightCharAtack());
                    RightRoom.Play();
                }
                else
                {
                    RightSprites[CharNumber].SetActive(false);
                    CharNumber += 1;
                    RightRoom.Play();
                }
            }
            else
            {
                if (CharNumber > 0)
                {
                    RightSprites[CharNumber].SetActive(false);
                    CharNumber -= 1;
                    RightRoom.Play();
                }
            }
            switch (CharNumber)
            {
                case 0: CharPosition = 1; break;
                case 1: CharPosition = 2; break;
                case 2: CharPosition = 3; break;
                case 3: CharPosition = 5; break;
                case 4: CharPosition = 7; break;
                case 5: CharPosition = 10; break;
            }
        }
        if (UseCameraToNumber.ActiveCameraNumber + 1 == CharPosition && !InRoom)
        {
            RightSprites[CharNumber].SetActive(true);
        }
        else
        {
            RightSprites[CharNumber].SetActive(false);
        }
        StartCoroutine(GoInCamera());
    }

    public void OnCameraSwipe()
    {
        if (UseCameraToNumber.ActiveCameraNumber + 1 == CharPosition && !InRoom)
        {
            RightSprites[CharNumber].SetActive(true);
        }
        else
        {
            RightSprites[CharNumber].SetActive(false);
        }
    }

    private IEnumerator RightCharAtack()
    {
        yield return new WaitForSeconds(1f);
        RightCharInDoor.SetActive(true);
        yield return new WaitForSeconds(2f);
        if (RightDoor.GetComponent<DoorOpenClose>().IsOpen == false)
        {
            yield return new WaitForSeconds(2f);
            RightRoom.Play();
            RightCharInDoor.SetActive(false);
            RightCharInWindow.SetActive(true);
            if (RightLight.GetComponent<LightOnOff>().IsOn == true)
            {
                InRoom = false;
            }
            else 
            {
                StartCoroutine(RightCharAtack());
            }
        }
        else
        {
            CameraCanvas.SetActive(false);
            RightCharScreamer.SetActive(true);
            RightCharScreamer.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1f);
            LossScreen.SetActive(true);
            LossScreen.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("Menu");
        }
    }
}
