using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorOpenClose : MonoBehaviour, IPointerClickHandler
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
        }
        else
        {
            UpDoor.transform.position += new Vector3(0, 5, 0);
            DownDoor.transform.position -= new Vector3(0, 5, 0);
            IsOpen = true;
        }
    }
}
