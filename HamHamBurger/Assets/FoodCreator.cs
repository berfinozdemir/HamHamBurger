using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCreator : MonoBehaviour
{
    public GameObject FoodPrefab;
    public Transform FoodPoint;
    private void Start()
    {
        CreateFood();
    }

    public void CreateFood()
    {
        var food = Instantiate(FoodPrefab, FoodPoint.position, Quaternion.identity, this.transform);
        
    }
}
