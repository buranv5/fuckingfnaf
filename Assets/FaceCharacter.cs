using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaceCharacter : MonoBehaviour
{
    [SerializeField] private GameObject FaceCharCam6;
    [SerializeField] private GameObject FaceCharInRoom;
    [SerializeField] private GameObject FaceCharScreamer;
    [SerializeField] private GameObject LossScreen;
    [SerializeField] private AudioSource MainDoor;

    [SerializeField] private GameObject CameraCanvas;

    private bool IsAway = true;

    public void Start()
    {
        StartCoroutine(WaitHour());
    }
    public IEnumerator WaitHour()
    {
        yield return new WaitForSeconds(50f);
        if (PowerLevelTime.ThenLevel > 2)
        {
            float RandomCreate = Random.value;
            if (RandomCreate > 0f && IsAway)
            {
                IsAway = false;
                StartCoroutine(FaceRun());
                MainDoor.Play();
            }
            if (UseCameraToNumber.ActiveCameraNumber + 1 == 6 && !IsAway)
            {
                FaceCharCam6.SetActive(true);
            }
            else
            {
                FaceCharCam6.SetActive(false);
            }
        }
        StartCoroutine(WaitHour());
    }

    private IEnumerator FaceRun()
    {
        yield return new WaitForSeconds(1f);
        MainDoor.Play();
        FaceCharCam6.SetActive(false);
        FaceCharInRoom.SetActive(true);
        yield return new WaitForSeconds(2f);
        if (DressMask.IsDressed == true)
        {
            yield return new WaitForSeconds(2f);
            MainDoor.Play();
            FaceCharInRoom.SetActive(false);
            IsAway = true;
        }
        else 
        {
            CameraCanvas.SetActive(false);
            FaceCharScreamer.SetActive(true);
            FaceCharScreamer.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1f);
            LossScreen.SetActive(true);
            LossScreen.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("Menu");
        }
    }
}
