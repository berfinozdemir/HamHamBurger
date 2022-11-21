using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodStateManager : MonoBehaviour
{
    public BaseFoodState currentState;
    public NoneState NoneState = new NoneState();
    public BreadState BreadState = new BreadState();
    public MeatState MeatState = new MeatState();
    public TomatoState TomatoState = new TomatoState();
    public BurgerState BurgerState = new BurgerState();
    public BreadMeatState BreadMeatState = new BreadMeatState();
    public BreadTomatoState BreadTomatoState = new BreadTomatoState();

    private FoodController foodController;


    private void Start()
    {
        currentState = NoneState;
        currentState.EnterState(this);
        
        foodController = GetComponent<FoodController>();
    }
    private void Update()
    {
        currentState.UpdateState(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other, this);

    }
    public void SwitchState(BaseFoodState state)
    {
        currentState = state;
        //currentFoodData = foodData;
        //foodController.SetFood(foodData);
        state.EnterState(this);
    }
    
}
