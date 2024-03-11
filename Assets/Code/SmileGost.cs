using System.Collections; 
using UnityEngine;
using UnityEngine.UI;

public class SmileGost : MonoBehaviour
{
    [SerializeField]private Image Smile;
    private bool SmileActive;

    [SerializeField] Image BackGroundCamera;
    [SerializeField] GameObject FixButton;

    [SerializeField] private AudioSource BreakCamera;
    [SerializeField] private GameObject SmileSceamer;
    [SerializeField] private AudioSource HeartBit;
    private void Start()
    {
        Smile.color = new Color(1f, 1f, 1f, 0f);
        SmileActive = false;
    }
    private IEnumerator SmileScream()
    {
        yield return new WaitForSeconds(0.5f);
        if (SmileActive)
        {
            Smile.color += new Color(0f, 0f, 0f, 0.05f);
            if (Smile.color.a > 0.30f)
            {
                Smile.color = new Color(1f, 1f, 1f, 0f);
                SmileActive = false;
                SmileSceamer.SetActive(true);
                SmileSceamer.GetComponent<AudioSource>().Play();
                StartCoroutine(SmileCameraBreak());
            }
            else
            {
                StartCoroutine(SmileScream());
            }
        }
    }

    private IEnumerator SmileCameraBreak()
    {
        yield return new WaitForSeconds(2.1f);
        SmileSceamer.SetActive(false);
        UseCameraToNumber.CameraBroken[UseCameraToNumber.ActiveCameraNumber] = true;
        BackGroundCamera.color = new Color(1f, 1f, 1f, 1f);
        BreakCamera.Play();
        FixButton.SetActive(true);
        HeartBit.Play();
    }

    public void OnCameraEnter()
    {
        float RandomCreate = Random.value;
        if (RandomCreate > 0.8f)
        {
            Smile.color = new Color(1f, 1f, 1f, 0.05f);
            SmileActive = true;
            StartCoroutine(SmileScream());
        }
    }

    public void OnCameraExit() 
    {
        if (SmileActive) 
        {
            Smile.color = new Color(1f, 1f, 1f, 0f);
            SmileActive = false;
        }

    }

    public void OnCameraSwipe()
    {
        if (SmileActive)
        {
            Smile.color = new Color(1f, 1f, 1f, 0f);
            SmileActive = false;
            SmileSceamer.SetActive(true);
            SmileSceamer.GetComponent<AudioSource>().Play();
            StartCoroutine(SmileCameraBreak());
        }
    }


}
