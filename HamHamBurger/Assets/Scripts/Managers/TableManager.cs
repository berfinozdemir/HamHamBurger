using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class TableManager : MonoBehaviour
{
    public static TableManager Instance;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public List<Table> tables;
    public List<Table> emptyTables;
    public GameObject TablePrefab;
    public TableUI TableUI;
    public Transform[] tablePoints;
    public NavMeshSurface navMeshSurface;
    private void Start()
    {
        CreateTables();
        UpdateEmptyTables();
        TableUI = GetComponent<TableUI>();
    }
    public Vector3 AddCustomerToTable(Customer customer)
    {
        Vector3 position = emptyTables[0].waitPoint.position;
        customer.table = emptyTables[0];
        emptyTables[0].isEmpty = false;
        emptyTables.RemoveAt(0);
        UpdateEmptyTables();
        

        return position;
    }
    public void UpdateEmptyTables()
    {
        emptyTables.Clear();
        foreach (var item in tables)
        {
            if (item.isEmpty)
                emptyTables.Add(item);
        }
    }
    public void CreateTables()
    {
        for (int i = 0; i < DataManager.Instance.tableCount; i++)
        {
            var table = Instantiate(TablePrefab, tablePoints[i].position,Quaternion.identity,this.transform);
            tables.Add(table.GetComponent<Table>());
            table.GetComponent<Table>().CloseOrderImage();
        }
        //NavMesh.Instance.UpdateNavmesh();
        navMeshSurface.BuildNavMesh();
    }
}
