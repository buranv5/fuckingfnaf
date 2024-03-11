using System.Collections;
using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    [SerializeField] private GameObject Light;
    private float blinktime;
    void Start()
    {
        blinktime = 1f;
        StartCoroutine(Blink());
    }
    
    private IEnumerator Blink()
    {
        yield return new WaitForSeconds(blinktime);
        if (Light.activeSelf)
        {
            Light.SetActive(false);
        }
        else 
        { 
            Light.SetActive(true);
        }
        blinktime = Random.Range(0.01f, 3f);
        StartCoroutine(Blink());
    }
}
