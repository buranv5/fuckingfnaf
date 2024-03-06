using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;

public class LightOnOff : PowerScaler, IPointerClickHandler
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
            PowerUsing += 1;
        }
        else 
        {
            _Light.SetActive(false);
            PowerUsing -= 1;
        }
    }
}
