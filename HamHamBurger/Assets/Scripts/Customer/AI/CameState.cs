using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameState : BaseState
{
    Customer customer;
    public override void EnterState(CustomerStateManager stateManager)
    {
        //Debug.Log("CAME STATE");
        customer = stateManager.GetComponent<Customer>();
        //customer.Wait();
    }
    public override void UpdateState(CustomerStateManager stateManager)
    {
        if (TableManager.Instance.emptyTables.Count != 0)
        {
            stateManager.SwitchState(stateManager.WalkState);
        }
        else
        {
            stateManager.SwitchState(stateManager.WaitState);
        }
    }
    public override void OnTriggerEnter(Collider other, CustomerStateManager stateManager)
    {

    }
}
