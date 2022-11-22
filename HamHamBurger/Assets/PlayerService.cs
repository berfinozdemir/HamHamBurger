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
            FoodService(other.GetComponentInParent<Table>());
        }

    }
    public void FoodService(Table other)
    {
        var food = GetComponentInChildren<Food>();

        Debug.Log(other.order + " " + food.foodData);
        if (!food.foodData || food.foodData != other.order)
            return;
        //Debug.Log(food.foodData.foodType);
        //var table = other.GetComponentInParent<Table>();

        if (FoodController.Instance.isOrderServiced)
        {
            other.isOrderCame = true;
            other.OnOrderCame();
            playerResource.GiveFoodToTable();// food);
            Debug.Log("order came");

        }
        //Debug.Log(other.foodNo);
        
    }
}
