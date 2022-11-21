using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GamePlayManager : MonoBehaviour
{

    #region Singleton
    public static GamePlayManager Instance;
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
    public GameObject customerPrefab;
    int customerCount = 0;
    public static UnityAction OnGameEnd;

    private IEnumerator coroutine;
    void Start()
    {
        //LoadGame();
        CustomerManager.Instance.AddNewCustomer();
        customerCount++;
        coroutine = WaitAndSpawn(DataManager.Instance.CustomerCameTime);
        StartCoroutine(coroutine);
    }

    IEnumerator WaitAndSpawn(float waitTime)
    {
        while (customerCount < DataManager.Instance.customerCount)
        {
            yield return new WaitForSeconds(waitTime);
            CustomerManager.Instance.AddNewCustomer();
            customerCount++;
        }
    }
    public bool IsGameEnd()
    {
        bool gameEnd = false;
        if (customerCount == DataManager.Instance.customerCount && CustomerManager.Instance.customers.Count == 0)
        {
            gameEnd = true;
            OnGameEnd?.Invoke();
        }
        return gameEnd;
    }
    public void OnGameSuccess()
    {
        Time.timeScale = 0;
        // LevelManager.Instance.OnGameSuccess();
    }
    public void OnGameOver()
    {
        UIManager.Instance.OpenGameOverPanel();
        Time.timeScale = 0;
    }
    public void LoadGame()
    {
        UIManager.Instance.CloseGameOverPanel();
        UIManager.Instance.CloseSuccessPanel();
        Time.timeScale = 1;
        LevelManager.Instance.LoadLevel(true);
    }
}
