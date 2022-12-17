using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stash : MonoBehaviour
{
    public Transform StashParent;
    public List<Food> CollectedObjects = new List<Food>();
    public void AddStash(Food food)
    {
        food.Collect(StashParent);
        CollectedObjects.Add(food);
        //stashable.CollectStashable();
    }
}
