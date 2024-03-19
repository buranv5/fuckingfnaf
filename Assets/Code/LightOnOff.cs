using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;

public class LightOnOff : PowerScaler, IPointerClickHandler
{
    [SerializeField] private GameObject _Light;

    public bool IsOn = false;
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
                IsOn = true;
                PowerUsing += 1;
            }
            else
            {
                _Light.SetActive(false);
                IsOn=false;
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

    public void FlashLightSouns()
    {
        AudioSource Click = GetComponent<AudioSource>();
        Click.Play();
    }
}
