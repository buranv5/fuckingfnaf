using UnityEngine;
using UnityEngine.EventSystems;

public class CheckCamera : PowerScaler, IPointerClickHandler
{
    [SerializeField] private GameObject CameraCanvas;
    [SerializeField] private GameObject MaskButton;

    [SerializeField] private AudioSource TabletOn;
    [SerializeField] private AudioSource MainLight;
    [SerializeField] private AudioSource WorkCamera;
    void Start()
    {
        CameraCanvas.SetActive(false);
        MaskButton.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (FPowerLeft > 0)
        {
            TabletOn.Play();
            MainLight.Stop();
            CameraCanvas.SetActive(true);
            PowerUsing += 1;
            MaskButton.SetActive(false);
            WorkCamera.Play();
        }
    }


    public void OnClick()
    {
        TabletOn.Play();
        MainLight.Play();
        WorkCamera.Stop();
        CameraCanvas.SetActive(false);
        PowerUsing -= 1;
        MaskButton.SetActive(true);
    }
}