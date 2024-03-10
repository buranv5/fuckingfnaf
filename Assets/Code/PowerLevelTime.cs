using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PowerLevelTime : PowerScaler
{
    [SerializeField] private TMPro.TMP_Text NowTime;
    private int IntTime;

    [SerializeField] private TMPro.TMP_Text Level;
    private int ThenLevel;

    [SerializeField] private TMPro.TMP_Text PowerLeft;
    private float TimeForUseScale;

    [SerializeField] private GameObject WinScreen;
    [SerializeField] private Sprite[] UsageLevels = new Sprite[5];
    [SerializeField] private Image Usege;

    [SerializeField] private GameObject[] Lights = new GameObject[5];

    [SerializeField] private AudioSource PowerOff;

    private void Start()
    {
        StartCoroutine(GameTime());
        IntTime = -1;
        WinScreen.SetActive(false);
        StartCoroutine(UseEnergy());

        if (PlayerPrefs.HasKey("Level"))
        {
            ThenLevel = PlayerPrefs.GetInt("Level");
        }
        else
        {
            ThenLevel = 1;
        }
        Level.text = $"Night {ThenLevel}";
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
        PowerLeft.text = $"Power  left: {FPowerLeft}%";
    }

    private IEnumerator UseEnergy()
    {
        yield return new WaitForSeconds(TimeForUseScale);
        if (FPowerLeft > 0)
        {
            FPowerLeft -= 1;
            StartCoroutine(UseEnergy());
        }
        else
        {
            PowerOff.Play();
            for (int i = 0; i < Lights.Length; i++)
            {
                Lights[i].SetActive(false);
            }
            PowerUsing = 1;
        }

    }
    private IEnumerator GameTime()
    {
        yield return new WaitForSeconds(60f);
        IntTime += 1;
        NowTime.text = $"0{IntTime} AM";
        if (IntTime == 6)
        {
            ThenLevel += 1;
            PlayerPrefs.SetInt("Level", ThenLevel);
            PlayerPrefs.Save();
            WinScreen.SetActive(true);
            SceneManager.LoadScene("Menu");
            Time.timeScale = 0;

        }
        StartCoroutine(GameTime());
    }
}
