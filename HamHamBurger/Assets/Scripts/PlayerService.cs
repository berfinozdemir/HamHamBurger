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
        if (other.CompareTag("TablePoint"))
        {
            Table table = other.GetComponentInParent<Table>();
            if (table.isCustomerLeft)
                return;
            FoodService(table);
        }
    }
    public void FoodService(Table other)
    {
        //Debug.Log(other.isCustomerLeft + " iscustomerleft");
        var food = GetComponentInChildren<Food>();
        if (!food.foodData || food.foodData != other.order)
            return;
        //if (FoodController.Instance.isOrderServiced || FoodController.Instance.currentFoodType != other.GetComponentInParent<Table>().GetOrderType().foodType)
        //    return;
        if (FoodController.Instance.isOrderServiced)
        {
            other.isOrderCame = true;
            other.OnOrderCame();
            playerResource.GiveFoodToTable();
            FoodController.Instance.isOrderServiced = false;
        }
    }
}
