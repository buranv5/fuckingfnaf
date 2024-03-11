using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FemaleGost : MonoBehaviour
{
    [SerializeField] private GameObject[] FemaleGosts = new GameObject[4];
    private int ActiveGost;
    private int GostIn;

    [SerializeField] Image BackGroundCamera;
    [SerializeField] GameObject FixButton;

    [SerializeField] private AudioSource BreakCamera;
    private bool GostDestroy = true;

    [SerializeField] private AudioSource GostHere;
    [SerializeField] private GameObject FemaleGostScreamer;
    [SerializeField] private AudioSource HeartBit;
    public void OnCameraEnter()
    {
        float RandomCreate = Random.value;
        if (RandomCreate > 0.6f && GostDestroy)
        {
            ActiveGost = Random.Range(0, FemaleGosts.Length);
            switch (ActiveGost)
            { case 0: GostIn = 3; break; case 1: GostIn = 5; break; case 2: GostIn = 8; break; case 3: GostIn = 10; break; }
            GostDestroy = false;
            if (UseCameraToNumber.ActiveCameraNumber + 1 == GostIn && !GostDestroy)
            {
                GostHere.Play();
                FemaleGosts[ActiveGost].SetActive(true);
                StartCoroutine(GostAtack());
            }
        }
    }
    public void OnCameraSwipe()
    {
        if (UseCameraToNumber.ActiveCameraNumber + 1 == GostIn && !GostDestroy)
        {
            GostHere.Play();
            FemaleGosts[ActiveGost].SetActive(true);
            StartCoroutine(GostAtack());
        }
        else
        {
            GostDestroy = true;
            FemaleGosts[ActiveGost].SetActive(false);
        }
    }

    public void OnCameraExit()
    {
        if (!GostDestroy)
        {
            GostDestroy = true;
            FemaleGosts[ActiveGost].SetActive(false);
        }
    }

    public IEnumerator GostAtack()
    {
        yield return new WaitForSeconds(4f);
        if (UseCameraToNumber.ActiveCameraNumber + 1 == GostIn && !GostDestroy)
        {
            GostDestroy = true;
            FemaleGosts[ActiveGost].SetActive(false);
            FemaleGostScreamer.SetActive(true);
            FemaleGostScreamer.GetComponent<AudioSource>().Play();
            StartCoroutine(FemaleGostCameraBreak());
        }
    }

    public IEnumerator FemaleGostCameraBreak()
    {
        yield return new WaitForSeconds(4f);
        FemaleGostScreamer.SetActive(false);
        UseCameraToNumber.CameraBroken[UseCameraToNumber.ActiveCameraNumber] = true;
        BackGroundCamera.color = new Color(1f, 1f, 1f, 1f);
        BreakCamera.Play();
        FixButton.SetActive(true);
        HeartBit.Play();
    }

}
