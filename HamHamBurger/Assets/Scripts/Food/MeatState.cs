using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatState : BaseFoodState
{
    public override void EnterState(FoodStateManager stateManager)
    {
        //Debug.Log("meat state");
        FoodController.Instance.SetFood(FoodType.Meat);
        //stateManager.GetComponent<FoodController>().SetFood()
    }
    public override void UpdateState(FoodStateManager stateManager)
    {
    }
    public override void OnTriggerEnter(Collider other, FoodStateManager stateManager)
    {
        //if (other.CompareTag("Bread"))
        //    stateManager.SwitchState(stateManager.BreadMeatState);
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
                    stateManager.SwitchState(stateManager.BreadMeatState);
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
