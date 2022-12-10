using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    //#region Singleton
    //public static OrderManager Instance;
    //private void Awake()
    //{
    //    if (Instance)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }
    //    Instance = this;
    //}
    //#endregion
    public List<FoodData> orders;

    public FoodData SelectRandomOrder()
    {
        int i = Random.Range(0, orders.Count - 1);
        return orders[i];
    }
}
