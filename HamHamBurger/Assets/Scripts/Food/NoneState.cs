using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneState : BaseFoodState
{
    public override void EnterState(FoodStateManager stateManager)
    {
        FoodController.Instance.SetFood(FoodType.None);
    }
    public override void UpdateState(FoodStateManager stateManager)
    {
    }
    public override void OnTriggerEnter(Collider other, FoodStateManager stateManager)
    {
        if(other.CompareTag("Trash"))
            stateManager.SwitchState(stateManager.NoneState);
        if (other.CompareTag("Station"))
        {
            var type = other.GetComponentInChildren<Food>().foodData.foodType;
            switch (type)
            {
                case FoodType.Bread:
                    stateManager.SwitchState(stateManager.BreadState);
                    break;
                case FoodType.Meat:
                    stateManager.SwitchState(stateManager.MeatState);
                    break;
                case FoodType.Tomato:
                    stateManager.SwitchState(stateManager.TomatoState);
                    break;
                default:
                    break;
            }
        }
    //        stateManager.SwitchState();
    //    if (other.CompareTag("Bread"))
    //        stateManager.SwitchState(stateManager.BreadState);
    //    else if (other.CompareTag("Meat"))
    //        stateManager.SwitchState(stateManager.MeatState);
    //    else if (other.CompareTag("Tomato"))
    //        stateManager.SwitchState(stateManager.TomatoState);
    }
}
