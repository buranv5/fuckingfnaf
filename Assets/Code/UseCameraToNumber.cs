using UnityEngine;
using UnityEngine.UI;

public class UseCameraToNumber : MonoBehaviour
{
    [SerializeField] private Sprite[] CameraSprites = new Sprite[10];
    [SerializeField] private Image[] CameraIcons = new Image[10];
    [SerializeField] private Sprite CameraOn;
    [SerializeField] private Sprite CameraOff;
    [SerializeField] private Image ActiveCamera;
    static public int ActiveCameraNumber;

    [SerializeField] Image BackGroundCamera;
    static public bool[] CameraBroken = new bool[10];
    [SerializeField] GameObject FixButton;

    [SerializeField] private AudioSource CameraSwipe;
    [SerializeField] private AudioSource BreakCamera;
    [SerializeField] private AudioSource WorkCamera;
    private void Start()
    {
        for (int i = 0; i < CameraBroken.Length; i++)
        {
            CameraBroken[i] = false;
        }
        FixButton.SetActive(false);
    }
    public void OnIconClick(Image IconClick)
    {
        CameraSwipe.Play();
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
                ActiveCameraNumber = i;
                if (CameraBroken[i] == true)
                {
                    BreakCamera.Play();
                    WorkCamera.Stop();
                    BackGroundCamera.color = new Color(1f, 1f, 1f, 1f);
                    FixButton.SetActive(true);  
                }
                else
                {
                    BreakCamera.Stop();
                    WorkCamera.Play();
                    BackGroundCamera.color = new Color(1f, 1f, 1f, 0.08f);
                    FixButton.SetActive(false);
                }    
            }
        }
    }
}
