using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    #region Singleton
    public static FoodController Instance;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

    }
    #endregion
    public List<GameObject> foods;
    public GameObject currentFood;
    public Transform foodPoint;
    public FoodType currentFoodType;
    public bool isOrderServiced;
    public void SetFood(FoodType foodType)
    {
        if (currentFood)
            if (currentFood.activeInHierarchy) currentFood=null ;
        currentFoodType = foodType;

        switch (foodType)
        {
            case FoodType.None:
                currentFood = Instantiate(foods[0], foodPoint.position, Quaternion.identity, this.transform);
                break;
            case FoodType.Bread:
                currentFood = Instantiate(foods[1], foodPoint.position, Quaternion.identity, this.transform);
                break;
            case FoodType.Meat:
                currentFood = Instantiate(foods[2], foodPoint.position, Quaternion.identity, this.transform);
                break;
            case FoodType.Tomato:
                currentFood = Instantiate(foods[3], foodPoint.position, Quaternion.identity, this.transform);
                break;
            case FoodType.BreadMeat:
                currentFood = Instantiate(foods[4], foodPoint.position, Quaternion.identity, this.transform);
                break;
            case FoodType.Burger:
                currentFood = Instantiate(foods[5], foodPoint.position, Quaternion.identity, this.transform);
                break;
            case FoodType.BreadTomato:
                currentFood = Instantiate(foods[6], foodPoint.position, Quaternion.identity, this.transform);
                break;
            default:
                break;
        }
    }

    

}
