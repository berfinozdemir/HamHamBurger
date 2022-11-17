using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WaitState : BaseState
{
    private CustomerUI customerUI;
    Customer customer;
    public override void EnterState(CustomerStateManager stateManager)
    {
        customer = stateManager.GetComponent<Customer>();
        customerUI = stateManager.GetComponent<CustomerUI>();
        customer.Wait();
        //customerUI.BeginTimer(DataManager.Instance.customerWaitTime);
        //Debug.Log("WAIT STATE");
    }
    public override void UpdateState(CustomerStateManager stateManager)
    {
        if(customerUI.TimeOut)
            stateManager.SwitchState(stateManager.LeaveState);

        if (TableManager.Instance.emptyTables.Count != 0)
        {
            customerUI.filledTimeImage.fillAmount = 0;
            stateManager.SwitchState(stateManager.WalkState);
        }
        
    }
    public override void OnTriggerEnter(Collider other, CustomerStateManager stateManager)
    {

    }

}
