using System.Collections;
using UnityEngine;

public class Gost : MonoBehaviour
{
    [SerializeField] private GameObject[] Gosts = new GameObject[3];
    private int ActiveGost;
    private int GostIn;
    private bool GostDestroy = true;

    public void OnGostClick()
    {
        Gosts[ActiveGost].SetActive(false);
        GostDestroy = true;
    }

    public void OnCameraEnter()
    {
        float RandomCreate = Random.value;
        if (RandomCreate > 0.9f && GostDestroy)
        {
            ActiveGost = Random.Range(0, Gosts.Length);
            switch (ActiveGost) 
            { case 0: GostIn = 2; break; case 1: GostIn = 4; break; case 2: GostIn = 7; break; }
            GostDestroy = false;
        }
        if (UseCameraToNumber.ActiveCameraNumber + 1 == GostIn && !GostDestroy)
        {
            Gosts[ActiveGost].SetActive(true);
            StartCoroutine(GostAtack());
        }
    }
    public void OnCameraSwipe() 
    {
        if (UseCameraToNumber.ActiveCameraNumber + 1 == GostIn && !GostDestroy)
        {
            Gosts[ActiveGost].SetActive(true);
            StartCoroutine(GostAtack());
        }
        else
        {
            Gosts[ActiveGost].SetActive(false);
        }
    }

    public IEnumerator GostAtack() 
    {
        yield return new WaitForSeconds(8f);
        if (!GostDestroy)
        {
            Gosts[ActiveGost].SetActive(false);
            GostDestroy = true;
            PowerScaler.FPowerLeft -= 20f;
        }
    }
}
