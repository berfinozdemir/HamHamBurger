using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public NavMeshAgent agent;
    public Table table;
    public AnimatorController animatorController;
    public FoodData order;
    CustomerUI customerUI;
    public CustomerManager _customerManager;
    OrderManager orderManager;
    private void Awake()
    {
        _customerManager = GetComponentInParent<CustomerManager>();
        agent = GetComponent<NavMeshAgent>();
        animatorController = GetComponentInChildren<AnimatorController>();
        customerUI = GetComponent<CustomerUI>();
        orderManager = _customerManager.orderManager;
        
    }
    public void Wait()
    {
        animatorController.PlayIdle();
    }
    public void LookTable()
    {
        transform.LookAt(table.transform);
    }
    public void MoveTable()
    {
        agent.SetDestination(TableManager.Instance.AddCustomerToTable(this));
        animatorController.PlayWalkAnimation(agent.velocity.magnitude);

    }
    public void MoveTarget(Vector3 position)
    {
        agent.SetDestination(position);
        animatorController.PlayWalkAnimation(agent.velocity.magnitude);
    }
    public void GetOut()
    {
        agent.SetDestination(_customerManager.door.position);
        table.isEmpty = true;
        table.isOrderCame = false;
        TableManager.Instance.UpdateEmptyTables();
    }
    public void Leave()
    {
        MoveTarget(_customerManager.outside.position);
        //agent.SetDestination(CustomerManager.Instance.outside.position);
        customerUI.CloseTimeImage();
        //Debug.Log("closed");
        table.CustomerLeft();
        table.isEmpty = true;
        table.isOrderCame = false;
        TableManager.Instance.UpdateEmptyTables();
    }
    private IEnumerator coroutine;
    public void OrderFood()
    {
        coroutine = WaitAndOrder(DataManager.Instance.OrderTime);
        StartCoroutine(coroutine);
    }
    private IEnumerator WaitAndOrder(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        order = orderManager.SelectRandomOrder();
        table.order = order;
        table.OnOrderSet(order);
        customerUI.BeginTimer();
        isOrdered = true;
    }
    public bool isOrdered;
    public void PayFood()
    {
        GamePlayManager.Instance.GetPayment(order.price);
    }
}
