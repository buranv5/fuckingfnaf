using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelTime : PowerScaler
{
    [SerializeField] private TMPro.TMP_Text NowTime;
    private int IntTime;
    [SerializeField] private TMPro.TMP_Text Level;
    [SerializeField] private TMPro.TMP_Text PowerLeft;
    private float FPowerLeft;
    private float TimeForUseScale;

    [SerializeField] private GameObject WinScreen;
    [SerializeField] private Sprite[] UsageLevels = new Sprite[5];
    [SerializeField] private Image Usege;

    private void Start()
    {
        StartCoroutine(GameTime());
        IntTime = -1;
        WinScreen.SetActive(false);
        FPowerLeft = 100;
        StartCoroutine(UseEnergy());
    }

    private void Update()
    {
        try 
        {
            Usege.sprite = UsageLevels[PowerUsing - 1];
        } 
        catch { }
        switch (PowerUsing) 
        {
            case 1: TimeForUseScale = 15f; break;
            case 2: TimeForUseScale = 8f; break;
            case 3: TimeForUseScale = 4f; break;
            case 4: TimeForUseScale = 2f; break;
            case 5: TimeForUseScale = 1f; break;
        }
    }

    private IEnumerator UseEnergy()
    {
        yield return new WaitForSeconds(TimeForUseScale);
        FPowerLeft -= 1;
        PowerLeft.text = $"Power  left: {FPowerLeft}%";
        StartCoroutine(UseEnergy());
    }
    private IEnumerator GameTime()
    {
        yield return new WaitForSeconds(60f);
        IntTime += 1;
        NowTime.text = $"0{IntTime} AM";
        if (IntTime == 6)
        { 
            WinScreen.SetActive(true);
            Time.timeScale = 0;
        }
        StartCoroutine(GameTime());
    }
}
