using UnityEngine;
using UnityEngine.UI;

public class UseCameraToNumber : MonoBehaviour
{
    [SerializeField] private Sprite[] CameraSprites = new Sprite[10];
    [SerializeField] private Image[] CameraIcons = new Image[10];
    [SerializeField] private Sprite CameraOn;
    [SerializeField] private Sprite CameraOff;
    [SerializeField] private Image ActiveCamera;

    public void OnIconClick(Image IconClick)
    {
        for (int i = 0; i < CameraIcons.Length; i++)
        {
           CameraIcons[i].sprite = CameraOff; 
        }
        IconClick.sprite = CameraOn;
        for (int i = 0; i < CameraSprites.Length; i++)
        {
            if (CameraIcons[i].sprite == CameraOn) 
            {
                ActiveCamera.sprite = CameraSprites[i];
            }
        }
    }
}
