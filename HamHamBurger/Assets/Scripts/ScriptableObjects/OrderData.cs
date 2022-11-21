using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order Data", menuName = "OrderData")]
public class OrderData : ScriptableObject
{
    public int OrderNo;
    public Sprite orderImage;
    public FoodData food;
    public int Price;
    public FoodType foodType;
}
