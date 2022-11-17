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
    //public float BurgerCookTime;// {get => Food.foodData };
    //public float CokeCookTime;
    //public float ChipsCookTime;
    public float OrderTime = 2f;
    public float CustomerCameTime = 10f;
    public int customerCount = 2;
    public float customerWaitTime = 5f;
    //public float money;
    public static UnityAction OnCurrencyUpdate;

    //public void Subsrice()
    //{
    //    OnMoneyUpdate += GetPayment();
    //}
    public void GetPayment(int price)
    {
        Money += price;
        OnCurrencyUpdate?.Invoke();
        //Debug.Log(Money);
    }
}
