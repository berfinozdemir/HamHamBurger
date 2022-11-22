using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourceHolder : MonoBehaviour
{
    public List<Food> foods;
    public Transform foodStack;
    public bool isHandEmpty;
    FoodStateManager foodStateManager;
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Station" )
        {
            var station = other.GetComponent<Station>();
            var food = station.GetComponentInChildren<Food>();
            if (!food)
                return;
            station.FoodTaken();
            AddNewFood(food);
            isHandEmpty = false;
        //    Debug.Log("trigged");
        }
        
    }
    public void AddNewFood(Food food)
    {
        foods.Add(food);
        
        //food.transform.parent = foodStack;
    }
    public void GiveFoodToTable()//Food food)
    {
        //if (foods.Count == 0)
        isHandEmpty = true;
    }
    //public void CleanResources()
    //{
    //    foreach (var item in foods)
    //    {
    //        Destroy(item.gameObject);
    //    }
    //        foods.Clear();
    //        isHandEmpty = true;
    //}
}
