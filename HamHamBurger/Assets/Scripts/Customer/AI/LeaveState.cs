using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveState : BaseState
{
    Customer customer;
    public override void EnterState(CustomerStateManager stateManager)
    {
        //Debug.Log("leave STATE");
        customer = stateManager.GetComponent<Customer>();
        customer.Leave();
    }
    public override void OnTriggerEnter(Collider other, CustomerStateManager stateManager)
    {
        if (other.CompareTag("Outside"))
        {
            customer._customerManager.RemoveCustomer(customer);
            GamePlayManager.Instance.IsGameEnd();
        }

    }
    public override void UpdateState(CustomerStateManager stateManager)
    {
       

    }
}
