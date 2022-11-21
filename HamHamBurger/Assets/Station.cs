using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    public Transform playerPoint;
    //public GameObject foodPrefab;
    //public Transform foodPoint;
    public bool isFoodCooked;
    FoodData foodData;
    public GameObject Food;
    private void Awake()
    {
    }
    void Start()
    {
        
        foodData = Food.GetComponentInChildren<Food>().foodData;
        StartCoroutine(WaitCook());
    }
    public IEnumerator WaitCook()
    {
        yield return new WaitForSeconds(foodData.CookTime);
        CookFood();
    }
    public void CookFood()
    {
        Food.SetActive(true);
        //Instantiate(foodPrefab, foodPoint);
        isFoodCooked = true;
    }
    public void FoodTaken()
    {
        Food.SetActive(false);
        isFoodCooked = false;
        StartCoroutine(WaitCook());
    }

}
