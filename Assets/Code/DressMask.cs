using UnityEngine;

public class DressMask : MonoBehaviour
{
    [SerializeField] private GameObject Mask;
    [SerializeField] private Canvas ToathZone;
    [SerializeField] private GameObject SaveButton;

    [SerializeField] private AudioSource OnMaskSound;

    static public bool IsDressed;
    void Start()
    {
        Mask.SetActive(false);
        SaveButton.SetActive(false);
    }

    public void OnButtonClick()
    {
        if (PowerScaler.FPowerLeft > 0)
        {
            if (!Mask.activeSelf)
            {
                Mask.SetActive(true);
                Mask.transform.localEulerAngles = new Vector3(0, 0, 0);
                ToathZone.planeDistance = 1;
                SaveButton.SetActive(true);
                OnMaskSound.Play();
                IsDressed = true;
            }
            else
            {
                OnMaskSound.Stop();
                Mask.SetActive(false);
                Mask.transform.localEulerAngles = new Vector3(-90, 0, 0);
                ToathZone.planeDistance = 11;
                SaveButton.SetActive(false);
                IsDressed = false;
            }
        }
    }
}
