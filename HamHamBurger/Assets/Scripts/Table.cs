using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    public bool isEmpty;

    public Transform waitPoint;
    public Transform playerPoint;

    public OrderData order;
    public Image orderImg;
    public bool isOrderCame;
    public bool isCustomerLeft;
    TableUI tableUI;
    private void Start()
    {
        tableUI = GetComponentInParent<TableUI>();
    }
    public void OnOrderSet(OrderData order)
    {
        var selectedOrderSprite = order.orderImage;
        tableUI.OpenOrderImage(orderImg, selectedOrderSprite);
    }
    public void OnOrderCame()
    {
        tableUI.CloseOrderImage(orderImg);
    }
    public void CustomerLeft()
    {
        isCustomerLeft = true;
        tableUI.CloseOrderImage(orderImg);
    }
    public FoodType GetOrderType()
    {
        Debug.Log(order.foodType);
        return order.foodType;
    }
}
