using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    public bool isEmpty;
    public Transform waitPoint;
    public Transform playerPoint;
    public FoodData order;
    public Image orderImg;
    public bool isOrderCame;
    public bool isCustomerLeft;
    private void Start()
    {
        CloseOrderImage();
    }
    public void OnOrderSet(FoodData order)
    {
        var selectedOrderSprite = order.foodSprite;
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
    public FoodData GetOrderType()
    {
        return order;
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
