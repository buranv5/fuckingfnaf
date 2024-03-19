using UnityEngine;
using UnityEngine.EventSystems;

public class DoorOpenClose : PowerScaler, IPointerClickHandler
{
    [SerializeField] private GameObject UpDoor;
    [SerializeField] private GameObject DownDoor;
    [SerializeField] private AudioSource Door;
    public bool IsOpen;
    void Start()
    {
        IsOpen = true;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (FPowerLeft > 0) 
        {
            if (IsOpen)
            {
                UpDoor.transform.position -= new Vector3(0, 5, 0);
                DownDoor.transform.position += new Vector3(0, 5, 0);
                IsOpen = false;
                PowerUsing += 1;
                Door.Play();
            }
            else
            {
                UpDoor.transform.position += new Vector3(0, 5, 0);
                DownDoor.transform.position -= new Vector3(0, 5, 0);
                IsOpen = true;
                PowerUsing -= 1;
                Door.Play();
            }
        }
    }
}
