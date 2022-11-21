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
    public FoodType foodType;
    public Image orderImg;
    public bool isOrderCame;
    public bool isCustomerLeft;
    TableUI tableUI;
    private void Start()
    {
        tableUI = GetComponentInParent<TableUI>();
        CloseOrderImage();
    }
    public void OnOrderSet(OrderData order)
    {
        var selectedOrderSprite = order.orderImage;
        OpenOrderImage(selectedOrderSprite);
    }
    public void OnOrderCame()
    {
        CloseOrderImage();
    }
    public void CustomerLeft()
    {
        isCustomerLeft = true;
        CloseOrderImage();
    }
    public FoodType GetOrderType()
    {
        if (!order)
            return FoodType.None;
        return order.foodType;
    }
    public void CloseOrderImage()
    {
        orderImg.enabled = false;
    }
    public void OpenOrderImage(Sprite sprite)
    {
        orderImg.enabled = true;
        orderImg.sprite = sprite;
    }
}
