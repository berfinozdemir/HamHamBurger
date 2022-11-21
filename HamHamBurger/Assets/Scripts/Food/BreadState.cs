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
        if (other.CompareTag("Trash"))
            stateManager.SwitchState(stateManager.NoneState);
        if (other.CompareTag("Station"))
        {
            var type = other.GetComponentInChildren<Food>().foodData.foodType;
            switch (type)
            {
                case FoodType.Meat:
                    stateManager.SwitchState(stateManager.BreadMeatState);
                    break;
                case FoodType.Tomato:
                    stateManager.SwitchState(stateManager.BreadTomatoState);
                    break;
                case FoodType.None:
                    stateManager.SwitchState(stateManager.NoneState);
                    break;
                default:
                    break;
            }
        }
        //if (other.CompareTag("Meat"))
        //    stateManager.SwitchState(stateManager.BreadMeatState);
        //else if (other.CompareTag("Tomato"))
        //    stateManager.SwitchState(stateManager.BreadTomatoState);
        //else if (other.CompareTag("Trash"))
        //    stateManager.SwitchState(stateManager.NoneState);
    }
}
