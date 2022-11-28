using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerState : BaseFoodState
{
    public override void EnterState(FoodStateManager stateManager)
    {
        FoodController.Instance.SetFood(FoodType.Burger);
    }
    public override void UpdateState(FoodStateManager stateManager)
    {
    }
    public override void OnTriggerEnter(Collider other, FoodStateManager stateManager)
    {
        if (other.CompareTag("TablePoint") )
        {
            if (FoodController.Instance.isOrderServiced || FoodController.Instance.currentFoodType != other.GetComponentInParent<Table>().GetOrderType().foodType)
                return;
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
