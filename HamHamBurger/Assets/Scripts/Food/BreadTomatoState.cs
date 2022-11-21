using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadTomatoState : BaseFoodState
{

    public override void EnterState(FoodStateManager stateManager)
    {
        //Debug.Log("bread-tomato state");
        FoodController.Instance.SetFood(FoodType.BreadTomato);
        //stateManager.GetComponent<FoodController>().SetFood()
    }
    public override void UpdateState(FoodStateManager stateManager)
    {
    }
    public override void OnTriggerEnter(Collider other, FoodStateManager stateManager)
    {
        //if (other.CompareTag("Meat"))
        //    stateManager.SwitchState(stateManager.BurgerState);
        //else if (other.CompareTag("Trash"))
        //    stateManager.SwitchState(stateManager.NoneState);
        if (other.CompareTag("Station"))
        {
            var type = other.GetComponentInChildren<Food>().foodData.foodType;
            switch (type)
            {
                case FoodType.Meat:
                    stateManager.SwitchState(stateManager.BurgerState);
                    break;
                case FoodType.None:
                    stateManager.SwitchState(stateManager.NoneState);
                    break;
                default:
                    break;
            }
        }
    }
}
