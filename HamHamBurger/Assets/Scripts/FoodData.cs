using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Data", menuName = "FoodData")]
public class FoodData : ScriptableObject
{
    public int FoodNo;
    public GameObject foodPrefab;
    public float CookTime;
    public string FoodName;
    public FoodType foodType;
}
