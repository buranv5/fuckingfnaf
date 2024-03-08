using UnityEngine;

public class DressMask : MonoBehaviour
{
    [SerializeField] private GameObject Mask;
    [SerializeField] private Canvas ToathZone;
    [SerializeField] private GameObject SaveButton;
    void Start()
    {
        Mask.SetActive(false);
        SaveButton.SetActive(false);
    }

    public void OnButtonClick()
    {
        if (!Mask.activeSelf)
        {
            Mask.SetActive(true);
            Mask.transform.localEulerAngles = new Vector3(0, 0, 0);
            ToathZone.planeDistance = 1;
            SaveButton.SetActive(true);
        }
        else 
        { 
            Mask.SetActive(false);
            Mask.transform.localEulerAngles = new Vector3(-90, 0, 0);
            ToathZone.planeDistance = 11;
            SaveButton.SetActive(false);
        }
    }
}
