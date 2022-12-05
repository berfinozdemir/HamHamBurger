using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    //public static NavMesh Instance;
    //private void Awake()
    //{
    //    if (Instance)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }
    //    Instance = this;
    //}
    public List<NavMeshSurface> surfaces;
    public void UpdateNavmesh()
    {
        foreach (var item in surfaces)
        {
            item.BuildNavMesh();
        }
        Debug.Log("updated");
    }
    
    void LateUpdate()
    {
       // UpdateNavmesh();
    } 
}
