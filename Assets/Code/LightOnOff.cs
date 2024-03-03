using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;

public class LightOnOff : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _Light;
    void Start()
    {
        _Light.SetActive(false);
    }

    [System.Obsolete]
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_Light.active == false)
        {
            _Light.SetActive(true);
        }
        else 
        {
            _Light.SetActive(false);
        }
    }
}
