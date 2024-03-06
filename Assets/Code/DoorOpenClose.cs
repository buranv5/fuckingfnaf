using UnityEngine;
using UnityEngine.EventSystems;

public class DoorOpenClose : PowerScaler, IPointerClickHandler
{
    [SerializeField] private GameObject UpDoor;
    [SerializeField] private GameObject DownDoor;
    private bool IsOpen;
    void Start()
    {
        IsOpen = true;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsOpen)
        {
            UpDoor.transform.position -= new Vector3(0, 5, 0);
            DownDoor.transform.position += new Vector3(0, 5, 0);
            IsOpen = false;
            PowerUsing += 1;
        }
        else
        {
            UpDoor.transform.position += new Vector3(0, 5, 0);
            DownDoor.transform.position -= new Vector3(0, 5, 0);
            IsOpen = true;
            PowerUsing -= 1;
        }
    }
}
