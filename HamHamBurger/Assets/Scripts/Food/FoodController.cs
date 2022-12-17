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
    public List<GameObject> foodPrefabs;
    public List<Food> foods;
    public Food currentFood;
    public Transform foodPoint;
    public FoodType currentFoodType;
    public bool isOrderServiced;
    private void Start()
    {
        foreach (var item in foodPrefabs)
        {
            var food = Instantiate(item, foodPoint.position, Quaternion.identity, this.transform);
            food.transform.localScale = Vector3.zero;
            foods.Add(food.GetComponent<Food>());
        }
    }
    public void SetFood(FoodType foodType)
    {
            if (currentFood)
                currentFood.transform.localScale=Vector3.zero;
        currentFoodType = foodType;

        foreach (var item in foods)
        {
            if(item.foodData.foodType == foodType)
            {
                item.transform.localScale = Vector3.one;
                currentFood = item;
            }
        }


        //switch (foodType)
        //{
        //    case FoodType.None:
        //        currentFood = Instantiate(foodPrefabs[0], foodPoint.position, Quaternion.identity, this.transform);
        //        break;
        //    case FoodType.Bread:
        //        currentFood = Instantiate(foodPrefabs[1], foodPoint.position, Quaternion.identity, this.transform);
        //        break;
        //    case FoodType.Meat:
        //        currentFood = Instantiate(foodPrefabs[2], foodPoint.position, Quaternion.identity, this.transform);
        //        break;
        //    case FoodType.Tomato:
        //        currentFood = Instantiate(foodPrefabs[3], foodPoint.position, Quaternion.identity, this.transform);
        //        break;
        //    case FoodType.BreadMeat:
        //        currentFood = Instantiate(foodPrefabs[4], foodPoint.position, Quaternion.identity, this.transform);
        //        break;
        //    case FoodType.Burger:
        //        currentFood = Instantiate(foodPrefabs[5], foodPoint.position, Quaternion.identity, this.transform);
        //        break;
        //    case FoodType.BreadTomato:
        //        currentFood = Instantiate(foodPrefabs[6], foodPoint.position, Quaternion.identity, this.transform);
        //        break;
        //    default:
        //        break;
        //}
    }

    

}
