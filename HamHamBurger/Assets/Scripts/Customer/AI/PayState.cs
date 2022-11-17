using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayState : BaseState
{
    private Customer customer;
    public override void EnterState(CustomerStateManager stateManager)
    {
        //Debug.Log("PAY STATE");
        customer = stateManager.GetComponent<Customer>();
        customer.PayFood();
        //customer.GetOut();
        stateManager.SwitchState(stateManager.LeaveState);
    }
    public override void OnTriggerEnter(Collider other, CustomerStateManager stateManager)
    {
     
    }
    public override void UpdateState(CustomerStateManager stateManager)
    {
        
    }
}
