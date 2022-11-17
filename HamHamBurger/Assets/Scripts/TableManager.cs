using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Table[] tables;
    public List<Table> emptyTables;

    private void Start()
    {
        tables = GetComponentsInChildren<Table>();
        UpdateEmptyTables();
    }
    public Vector3 AddCustomerToTable()
    {
        Vector3 position = emptyTables[0].waitPoint.position;
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
}
