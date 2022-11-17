using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : BaseState
{
    Customer customer;
    public override void EnterState(CustomerStateManager stateManager)
    {
        //Debug.Log("WALK STATE");
        customer = stateManager.gameObject.GetComponent<Customer>();
        customer.MoveTable();
    }
    
    public override void OnTriggerEnter(Collider other, CustomerStateManager stateManager)
    {
        if (other.CompareTag("WaitPoint"))
        {
            customer.Wait();
            
            stateManager.SwitchState(stateManager.OrderState);
            var table = other.gameObject.GetComponentInParent<Table>();
            table.isCustomerLeft = false;
            customer.table = table;
        }
    }
    public override void UpdateState(CustomerStateManager stateManager)
    {

    }
}
