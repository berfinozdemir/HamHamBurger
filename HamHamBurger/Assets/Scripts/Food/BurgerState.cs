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
        if (other.CompareTag("TablePoint") && FoodController.Instance.currentFoodType == other.GetComponentInParent<Table>().GetOrderType())
        {
            stateManager.SwitchState(stateManager.NoneState);
            FoodController.Instance.isOrderServiced = true;
        }
        else if (other.CompareTag("Trash"))
            stateManager.SwitchState(stateManager.NoneState);

    }
}
