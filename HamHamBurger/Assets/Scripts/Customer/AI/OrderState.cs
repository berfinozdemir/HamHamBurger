using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderState : BaseState
{
    Customer customer;
    CustomerUI customerUI;
    public override void EnterState(CustomerStateManager stateManager)
    {
        //Debug.Log("order STATE");
        customer = stateManager.GetComponent<Customer>();
        customerUI = customer.GetComponent<CustomerUI>();
        customer.OrderFood();

    }
    public override void UpdateState(CustomerStateManager stateManager)
    {
        if (customerUI.TimeOut)
            stateManager.SwitchState(stateManager.LeaveState);

        if (stateManager.GetComponent<Customer>().table.isOrderCame)
        {
            customerUI.filledTimeImage.fillAmount = 0;
            
            stateManager.SwitchState(stateManager.EatState);
        }

    }
    public override void OnTriggerEnter(Collider other, CustomerStateManager stateManager)
    {

    }
}
