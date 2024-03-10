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
                FemaleGosts[ActiveGost].SetActive(true);
                StartCoroutine(GostAtack());
            }
        }
    }
    public void OnCameraSwipe()
    {
        if (UseCameraToNumber.ActiveCameraNumber + 1 == GostIn && !GostDestroy)
        {
            FemaleGosts[ActiveGost].SetActive(true);
            StartCoroutine(GostAtack());
        }
        else
        {
            GostDestroy = true;
        }
    }

    public void OnCameraExit()
    {
        if (!GostDestroy)
        {
            GostDestroy = true;
        }
    }

    public IEnumerator GostAtack()
    {
        yield return new WaitForSeconds(4f);
        if (UseCameraToNumber.ActiveCameraNumber + 1 == GostIn && !GostDestroy)
        {
            switch (ActiveGost)
            { 
                case 0: 
                Debug.Log("BOOOO3");
                //screamer
                break; 
                case 1:
                    Debug.Log("BOOOO5");
                    //screamer
                break; 
                case 2:
                    Debug.Log("BOOOO8");
                    //screamer
                break;
                case 3:
                    Debug.Log("BOOOO10");
                    //screamer
                break; 
            }
            GostDestroy = true;
            FemaleGosts[ActiveGost].SetActive(false);
            UseCameraToNumber.CameraBroken[UseCameraToNumber.ActiveCameraNumber] = true;
            BackGroundCamera.color = new Color(1f, 1f, 1f, 1f);
            BreakCamera.Play();
            FixButton.SetActive(true);
        }
    }



}
