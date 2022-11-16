using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public VariableJoystick joystick;
    AnimatorController _animatorController;
    public NavMeshAgent agent;
    public float Speed;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _animatorController = GetComponentInChildren<AnimatorController>();
    }

    void Update()
    {
        if (!joystick)
            return;
        Vector3 move = new Vector3(joystick.Direction.x * Speed * Time.deltaTime, 0, joystick.Direction.y * Speed * Time.deltaTime);
        agent.Move(move);
        agent.SetDestination(transform.position + move);
        if (move == Vector3.zero)
            _animatorController.PlayIdle();
        else
        _animatorController.PlayWalkAnimation(agent.velocity.magnitude);
    }

    
}
