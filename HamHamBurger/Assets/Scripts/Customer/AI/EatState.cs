using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatState : BaseState
{
    Customer customer;
    public override void EnterState(CustomerStateManager stateManager)
    {
        //Debug.Log("EAT STATE");
        customer = stateManager.GetComponent<Customer>();
        customer.LookTable();

        customer.Wait();
        stateManager.SwitchState(stateManager.PayState);
    }
    public override void UpdateState(CustomerStateManager stateManager)
    {
        
    }
    public override void OnTriggerEnter(Collider other, CustomerStateManager stateManager)
    {

    }
    
}
