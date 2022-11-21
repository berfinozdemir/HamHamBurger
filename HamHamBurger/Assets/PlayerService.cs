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
            //Debug.Log("TABLE");
        }

    }
    public void FoodService(Collider other)
    {
        Table table = other.GetComponentInParent<Table>();
        //Debug.Log(table.GetOrderType());
        var order = table.order.food;
        Debug.Log(order);
        var food = GetComponentInChildren<Food>();
        if ( !order || !food.foodData )
            return;
        Debug.Log(food.foodData);
        if (!FoodController.Instance.isOrderServiced)
        {
            table.isOrderCame = true;
            table.OnOrderCame();
            //playerResource.GiveFoodToTable();// food);
            Debug.Log("order came");    
        }
    }
}
