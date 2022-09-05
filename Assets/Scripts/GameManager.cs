using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIManager uýmanager;
    private void Start()
    {
        CoinCalculator(0);
        Debug.Log(PlayerPrefs.GetInt("coin"));
    }

    private void CoinCalculator(int money)
    {
        if (PlayerPrefs.HasKey("coin"))
        {
            int oldScore = PlayerPrefs.GetInt("coin");
            PlayerPrefs.SetInt("coin", oldScore + money);
        }
        else
        {
            PlayerPrefs.SetInt("coin", 0);
        }
        uýmanager.CoinUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("FýnisLine"))
        {
            CoinCalculator(100);
            Debug.Log("Oyun bitti");
            uýmanager.DeathScreen();
        }
    }
}
