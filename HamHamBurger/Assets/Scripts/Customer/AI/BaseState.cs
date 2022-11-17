using UnityEngine;

public abstract class BaseState
{
    public abstract void EnterState(CustomerStateManager stateManager);
    public abstract void UpdateState(CustomerStateManager stateManager);
    public abstract void OnTriggerEnter(Collider other, CustomerStateManager stateManager);
}

