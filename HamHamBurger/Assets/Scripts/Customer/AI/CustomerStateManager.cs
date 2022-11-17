using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerStateManager : MonoBehaviour
{
    public BaseState currentState;
    public CameState CameState = new CameState();
    public WaitState WaitState = new WaitState();
    public WalkState WalkState = new WalkState();
    public EatState EatState = new EatState();
    public PayState PayState = new PayState();
    public LeaveState LeaveState = new LeaveState();
    public OrderState OrderState = new OrderState();

    private void Start()
    {
        currentState = CameState;
        currentState.EnterState(this);

    }
    public void SwitchState(BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdateState(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other, this);
    }
}
