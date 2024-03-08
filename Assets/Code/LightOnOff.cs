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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (FPowerLeft > 0) 
        {
            if (!_Light.activeSelf)
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

    public void OnButtonClick()
    {
        if (FPowerLeft > 0)
        {
            if (!_Light.activeSelf)
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
}
