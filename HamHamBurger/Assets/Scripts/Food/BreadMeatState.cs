using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadMeatState : BaseFoodState
{
    public override void EnterState(FoodStateManager stateManager)
    {
        //Debug.Log("bread-meat state");
        FoodController.Instance.SetFood(FoodType.BreadMeat);
        //stateManager.GetComponent<FoodController>().SetFood()
    }
    public override void UpdateState(FoodStateManager stateManager)
    {
    }
    public override void OnTriggerEnter(Collider other, FoodStateManager stateManager)
    {
        if (other.CompareTag("Tomato"))
            stateManager.SwitchState(stateManager.BurgerState);
        else if (other.CompareTag("TablePoint") && FoodController.Instance.currentFoodType == other.GetComponentInParent<Table>().GetOrderType())
        {
            stateManager.SwitchState(stateManager.NoneState);
            FoodController.Instance.isOrderServiced = true;
        }
        else if (other.CompareTag("Trash"))
            stateManager.SwitchState(stateManager.NoneState);
    }
}
