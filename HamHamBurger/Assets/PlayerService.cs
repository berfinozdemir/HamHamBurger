using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : MonoBehaviour
{

    PlayerResourceHolder playerResource;
    private void Start()
    {
        playerResource = GetComponent<PlayerResourceHolder>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TablePoint")/* && !other.GetComponentInParent<Table>().isCustomerLeft*/)
        {
            FoodService(other);
        }

    }
    public void FoodService(Collider other)
    {
        Table table = other.GetComponentInParent<Table>();
        var order = table.order.food;
        //var food = GetComponentInChildren<Food>().;
        //if (order==null || !food.foodData )
        //    return;
        if (FoodController.Instance.isOrderServiced)
        {
            table.isOrderCame = true;
            table.OnOrderCame();
            //playerResource.GiveFoodToTable();// food);
            Debug.Log("order came");
        }
    }
}
