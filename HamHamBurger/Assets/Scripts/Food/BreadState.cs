using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadState : BaseFoodState
{
    public override void EnterState(FoodStateManager stateManager)
    {
        FoodController.Instance.SetFood(FoodType.Bread);
        //Debug.Log("bread state");

    }
    public override void UpdateState(FoodStateManager stateManager)
    {
    }
    public override void OnTriggerEnter(Collider other, FoodStateManager stateManager)
    {
        if (other.CompareTag("Meat"))
            stateManager.SwitchState(stateManager.BreadMeatState);
        else if (other.CompareTag("Tomato"))
            stateManager.SwitchState(stateManager.BreadTomatoState);
        else if (other.CompareTag("Trash"))
            stateManager.SwitchState(stateManager.NoneState);
    }
}
