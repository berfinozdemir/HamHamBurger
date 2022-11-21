using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoState : BaseFoodState
{
    public override void EnterState(FoodStateManager stateManager)
    {
        //Debug.Log("tomato state");
        FoodController.Instance.SetFood(FoodType.Tomato);
    }
    public override void UpdateState(FoodStateManager stateManager)
    {
    }
    public override void OnTriggerEnter(Collider other, FoodStateManager stateManager)
    {
        //if (other.CompareTag("Bread"))
        //    stateManager.SwitchState(stateManager.BreadTomatoState);
        //else if (other.CompareTag("Trash"))
        //    stateManager.SwitchState(stateManager.NoneState);
        if (other.CompareTag("Trash"))
            stateManager.SwitchState(stateManager.NoneState);
        if (other.CompareTag("Station"))
        {
            var type = other.GetComponentInChildren<Food>().foodData.foodType;
            switch (type)
            {
                case FoodType.Bread:
                    stateManager.SwitchState(stateManager.BreadTomatoState);
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
