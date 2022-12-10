using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public static int Money
    {
        get => PlayerPrefs.GetInt("Money", 0);
        set
        {
            PlayerPrefs.SetInt("Money", value);

            OnCurrencyUpdate?.Invoke();
        }
    }
    public float OrderTime = 2f;
    //public float CustomerCameTime = 10f;
    //public float CustomerWaitTime = 5f;
    public static UnityAction OnCurrencyUpdate;
    public void GetPayment(int price)
    {
        Money += price;
        OnCurrencyUpdate?.Invoke();
    }
    public static UnityAction OnLevelUpdate;
    public static int CurrentLevel
    {
        get => PlayerPrefs.GetInt("CurrentLevel", 1);
        set
        {
            PlayerPrefs.SetInt("CurrentLevel", value);

            OnLevelUpdate?.Invoke();
        }
    }
}
