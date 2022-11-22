using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerState : BaseFoodState
{
    public override void EnterState(FoodStateManager stateManager)
    {
        FoodController.Instance.SetFood(FoodType.Burger);
        //Debug.Log("buregr sttae");
    }
    public override void UpdateState(FoodStateManager stateManager)
    {
    }
    public override void OnTriggerEnter(Collider other, FoodStateManager stateManager)
    {
        if (other.CompareTag("TablePoint") && FoodController.Instance.currentFoodType == other.GetComponentInParent<Table>().GetOrderType().foodType)
        {
            FoodController.Instance.isOrderServiced = true;
            stateManager.SwitchState(stateManager.NoneState);
        }
        if (other.CompareTag("Trash"))
            stateManager.SwitchState(stateManager.NoneState);

        if (other.CompareTag("Station"))
        {
            var type = other.GetComponentInChildren<Food>().foodData.foodType;
            switch (type)
            {
                case FoodType.None:
                    stateManager.SwitchState(stateManager.NoneState);
                    break;
                default:
                    break;
            }
        }
    }
}
