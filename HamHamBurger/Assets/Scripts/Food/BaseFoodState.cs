using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFoodState
{
    //public abstract FoodData foodData;
    public abstract void EnterState(FoodStateManager stateManager);
    public abstract void UpdateState(FoodStateManager stateManager);
    public abstract void OnTriggerEnter(Collider other, FoodStateManager stateManager);
}
