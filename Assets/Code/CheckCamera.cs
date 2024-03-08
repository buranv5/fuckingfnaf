using UnityEngine;
using UnityEngine.EventSystems;

public class CheckCamera : PowerScaler, IPointerClickHandler
{
    [SerializeField] private GameObject CameraCanvas;
    [SerializeField] private GameObject MaskButton;
    void Start()
    {
        CameraCanvas.SetActive(false);
        MaskButton.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (FPowerLeft > 0)
        {
            CameraCanvas.SetActive(true);
            PowerUsing += 1;
            MaskButton.SetActive(false);
        }
    }


    public void OnClick()
    {
        CameraCanvas.SetActive(false);
        PowerUsing -= 1;
        MaskButton.SetActive(true);
    }
}