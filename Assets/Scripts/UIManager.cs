using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image effectImage;
    private int effectController = 0;
    [SerializeField] Text coin_text;

    // ------DeathScreen------ //
    [SerializeField] GameObject Deathscreen;
    [SerializeField] GameObject comlated;
    [SerializeField] GameObject RadialShine;
    [SerializeField] GameObject coinImage;
    [SerializeField] GameObject RewardedButton;
    [SerializeField] GameObject Nothanks;
    private bool RadialShineBool = false;
    // ------DeathScreen------ //

    // ------Button------ //
    [SerializeField] Animator LayoutAnimator;
    [SerializeField] GameObject SettingOpen;
    [SerializeField] GameObject SettingClose;
    [SerializeField] GameObject sound_on;
    [SerializeField] GameObject sound_off;
    [SerializeField] GameObject haptic_on;
    [SerializeField] GameObject haptic_off;
    [SerializeField] GameObject IAP;
    [SerializeField] GameObject Info;
    [SerializeField] GameObject noAds;
    [SerializeField] GameObject Shop;
    // ------Button------ //

    [SerializeField] GameObject Hand;
    [SerializeField] GameObject Touch;

    [SerializeField] GameObject Restart_Button;

    // ------Button------ //

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        if (PlayerPrefs.HasKey("vibration") == false)
        {
            PlayerPrefs.SetInt("vibration", 1);
        }

        CoinUpdate();
    }

    private void Update()
    {
        if (RadialShineBool == true)
        {
            RadialShine.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -10 * Time.deltaTime));
        }       
    }

    public void FirstTouchDedication()
    {
        Hand.gameObject.SetActive(false);
        Touch.gameObject.SetActive(false);

        Shop.gameObject.SetActive(false);
        noAds.gameObject.SetActive(false);

        SettingOpen.gameObject.SetActive(false);
        SettingClose.gameObject.SetActive(false);
        sound_on.gameObject.SetActive(false);
        sound_off.gameObject.SetActive(false);
        haptic_on.gameObject.SetActive(false);
        haptic_off.gameObject.SetActive(false);
        IAP.gameObject.SetActive(false);
        Info.gameObject.SetActive(false);
    }

    public void RestartButton()
    {
        Restart_Button.SetActive(true);
    }

    public void RestartScene()
    {
        Variables.FirstTouch = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CoinUpdate()
    {
        coin_text.text = PlayerPrefs.GetInt("coin").ToString();
    }

    public void SettingsOpen()  
    {
        SettingOpen.SetActive(false);
        SettingClose.SetActive(true);
        LayoutAnimator.SetTrigger("Setting_open");

        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            sound_off.SetActive(false);
            sound_on.SetActive(true);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_on.SetActive(false);
            sound_off.SetActive(true);
            AudioListener.volume = 0;
        }

        if (PlayerPrefs.GetInt("vibration") == 2)
        {
            haptic_off.SetActive(true);
            haptic_on.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("vibration") == 1)
        {
            haptic_on.SetActive(true);
            haptic_off.SetActive(false);
        }
    }
    public void SettingsClose()
    {
        SettingOpen.SetActive(true);
        SettingClose.SetActive(false);
        LayoutAnimator.SetTrigger("Setting_close");
    }

    public void SoundOn()
    {
        sound_on.SetActive(false);
        sound_off.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }
    public void SoundOff()
    {
        sound_off.SetActive(false);
        sound_on.SetActive(true);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }
    public void HapticOn()
    {
        haptic_on.SetActive(false);
        haptic_off.SetActive(true);
        PlayerPrefs.SetInt("vibration", 2);
    }
    public void HapticOff()
    {
        haptic_off.SetActive(false);
        haptic_on.SetActive(true);
        PlayerPrefs.SetInt("vibration", 1);
    }

    public void DeathScreen()
    {
        StartCoroutine("FinishLaunch");
    }

    public IEnumerator FinishLaunch()
    {
        RadialShineBool = true;
        Deathscreen.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        comlated.SetActive(true);
        yield return new WaitForSecondsRealtime(1.3f);
        RadialShine.SetActive(true);
        yield return new WaitForSecondsRealtime(1.3f);
        coinImage.SetActive(true);
        RewardedButton.SetActive(true);
        yield return new WaitForSecondsRealtime(1.9f);
        Nothanks.SetActive(true);
    }

    public void PrivacyAndPolicy()
    {
        Application.OpenURL("https://ieeexplore.ieee.org/abstract/document/6298891");
    }
    public void TermOfUs()
    {
        Application.OpenURL("https://ieeexplore.ieee.org/abstract/document/6298891");
    }

    // ------Button------ //
    public IEnumerator WhiteEffect()
    {
        effectImage.gameObject.SetActive(true);
        while (effectController == 0)
        {
            yield return new WaitForSeconds(0.01f);
            effectImage.color += new Color(0, 0, 0, 0.1f);
            if (effectImage.color == new Color(effectImage.color.r, effectImage.color.g, effectImage.color.b,1))
            {
                effectController = 1;
            }                 
        }

        while (effectController == 1)
        {
            yield return new WaitForSeconds(0.01f);
            effectImage.color -= new Color(0, 0, 0, 0.1f);
            if (effectImage.color == new Color(effectImage.color.r, effectImage.color.g, effectImage.color.b, 0))
            {
                effectController = 2;
            }
        }
        if (effectController == 2)
        {
            Debug.Log("effect bitti");
        }
    }
}
