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
    public OrderData order;
    CustomerUI customerUI;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animatorController = GetComponentInChildren<AnimatorController>();
        customerUI = GetComponent<CustomerUI>();
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
        agent.SetDestination(TableManager.Instance.AddCustomerToTable());
        animatorController.PlayWalkAnimation(agent.velocity.magnitude);

    }
    public void MoveTarget(Vector3 position)
    {
        agent.SetDestination(position);
        animatorController.PlayWalkAnimation(agent.velocity.magnitude);
    }
    public void GetOut()
    {
        agent.SetDestination(CustomerManager.Instance.door.position);
        table.isEmpty = true;
        table.isOrderCame = false;
        TableManager.Instance.UpdateEmptyTables();
    }
    public void Leave()
    {
        MoveTarget(CustomerManager.Instance.outside.position);
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
        order = OrderManager.Instance.SelectRandomOrder();
        table.order = order;
        Debug.Log(table.order + " " + order);
        table.OnOrderSet(order);
        customerUI.BeginTimer();
        isOrdered = true;
    }
    public bool isOrdered;
    public void PayFood()
    {
        DataManager.Instance.GetPayment(order.Price);
    }
}
