using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FixCamera : MonoBehaviour
{
    [SerializeField] Image BackGroundCamera;

    [SerializeField] private GameObject FixText;
    private float FixTime = 3f;
    private bool ButtonDown = false;

    [SerializeField] private AudioSource Fix;
    [SerializeField] private AudioSource BreakCamera;
    [SerializeField] private AudioSource WorkCamera;
    public IEnumerator Fixing()
    {
        yield return new WaitForSeconds(0.01f);
        FixText.SetActive(true);
        FixText.GetComponent<TMPro.TMP_Text>().text = $"Fixing ... {FixTime}";
        FixTime -= 0.01f;
        if (FixTime <= 0)
        {
            FixText.SetActive(false);
            UseCameraToNumber.CameraBroken[UseCameraToNumber.ActiveCameraNumber] = false;
            BackGroundCamera.color = new Color(1f, 1f, 1f, 0.08f);
            gameObject.SetActive(false);
            FixTime = 3f;
            FixText.GetComponent<TMPro.TMP_Text>().text = $"Fixing ... {FixTime}";
            BreakCamera.Stop();
            WorkCamera.Play();
        }
        else
        {
            if (ButtonDown)
            {
                StartCoroutine(Fixing());
            }
        }
    }

    public void OnFixing()
    {
        Fix.Play();
        StartCoroutine(Fixing());
        ButtonDown = true;
    }

    public void OnStop()
    {
        FixTime = 3f;
        FixText.SetActive(false);
        ButtonDown = false;
    }
}
