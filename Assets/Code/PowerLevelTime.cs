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
    private int UnlimitPower;

    [SerializeField] private GameObject WinScreen;
    [SerializeField] private Sprite[] UsageLevels = new Sprite[5];
    [SerializeField] private Image Usege;

    [SerializeField] private GameObject[] Lights = new GameObject[5];

    [SerializeField] private AudioSource PowerOff;
    [SerializeField] private GameObject PowerSmileGost;
    [SerializeField] private GameObject SmileScreamer;
    [SerializeField] private GameObject LossScreen;
    [SerializeField] private AudioSource MainDoor;

    private void Start()
    {
        StartCoroutine(GameTime());
        IntTime = -1;
        WinScreen.SetActive(false);
        if (PlayerPrefs.HasKey("UnlimitPower"))
        {
            UnlimitPower = PlayerPrefs.GetInt("UnlimitPower");
        }
        else
        {
            UnlimitPower = 0;
        }
        if (UnlimitPower == 0)
        {
            StartCoroutine(UseEnergy());
        }

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
            StartCoroutine(SmilePowerAtack());
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
            StartCoroutine(LoadMenu());
        }
        StartCoroutine(GameTime());
    }

    private IEnumerator LoadMenu() 
    {
        yield return new WaitForSeconds(11f);
        SceneManager.LoadScene("Menu");
    }

    private IEnumerator SmilePowerAtack() 
    {
        yield return new WaitForSeconds(15f);
        MainDoor.Play();
        yield return new WaitForSeconds(1f);
        PowerSmileGost.SetActive(true);
        yield return new WaitForSeconds(1f);
        PowerSmileGost.SetActive(false);
        MainDoor.Play();
        yield return new WaitForSeconds(1f);
        PowerSmileGost.transform.localPosition -= new Vector3(25, 0, 0);
        PowerSmileGost.SetActive(true);
        yield return new WaitForSeconds(1f);
        PowerSmileGost.SetActive(false);
        SmileScreamer.SetActive(true);
        SmileScreamer.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(5f);
        LossScreen.SetActive(true);
        LossScreen.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Menu");
    }
}
