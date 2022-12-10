using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    //#region Singleton
    //public static CustomerManager Instance;
    //private void Awake()
    //{
    //    if (Instance)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }
    //    Instance = this;
    //}
    //#endregion 
    public GameObject customerPrefab;
    public Transform door;
    public Transform outside;

    public List<Customer> customers;
    TableManager _tableManager;

    private void Start()
    {
        _tableManager = TableManager.Instance;
    }
    public void AddNewCustomer()
    {
        Vector3 pos = door.position;
        if (customers.Count >= TableManager.Instance.tables.Count)
        {
            pos.z += 10f *(customers.Count - TableManager.Instance.tables.Count) ;
        }
        var customer = Instantiate(customerPrefab, pos ,Quaternion.identity,this.transform);
        customers.Add(customer.GetComponent<Customer>());
    }
    public void RemoveCustomer(Customer customer)
    {
        customers.Remove(customer);
        Destroy(customer.gameObject);
    }
    
    
    
}
