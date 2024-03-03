using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class HeadSpin : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject Camera;
    private float sensitivity = 1f;
    private bool Push = false;
    private float FingerPlaseX;
    private float FingerPlaseY;

    public void Start()
    {

 
    }

    public void Update()
    {
        if (Push) 
        {
            if (FingerPlaseX > Screen.width / 2 && Camera.transform.eulerAngles.y < 120)
            {
                Camera.transform.Rotate(0, sensitivity, 0); 
            }
            else if (FingerPlaseX < Screen.width / 2 && Camera.transform.eulerAngles.y > 60)
            {
                Camera.transform.Rotate(0, -sensitivity, 0);
            }


        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Push = true;
        FingerPlaseX = eventData.position.x;
        FingerPlaseY = eventData.position.y;
    }

    public void OnPointerUp(PointerEventData eventData) 
    {
        Push = false;
    }
}
