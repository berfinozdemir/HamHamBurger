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
        Subscribe();
    }
    #endregion
    public GameObject customerPrefab;
    public int customerCount = 0;
    public static UnityAction OnGameEnd;
    private IEnumerator coroutine;
    public CustomerManager _customerManager;
    void Start()
    {
        //LoadGame();
        
    }
    void Subscribe()
    {
        LevelManager.OnLevelUpdate += OnNewLevelLoad;
    }
    void Unsubscribe()
    {
        LevelManager.OnLevelUpdate -= OnNewLevelLoad;
    }
    public void StartCreateCustomers()
    {
        _customerManager.AddNewCustomer();
        customerCount++;
        coroutine = WaitAndSpawn(LevelManager.Instance.currentLevel.levelData.CustomerWaitTime);
        StartCoroutine(coroutine);
    }
    IEnumerator WaitAndSpawn(float waitTime)
    {
        while (customerCount < LevelManager.Instance.currentLevel.levelData.CustomerCount)
        {
            yield return new WaitForSeconds(waitTime);
            _customerManager.AddNewCustomer();
            customerCount++;
        }
    }
    public bool IsGameEnd()
    {
        bool gameEnd = false;
        if (customerCount == LevelManager.Instance.currentLevel.levelData.CustomerCount && _customerManager.customers.Count == 0)
        {
            gameEnd = true;
            OnGameEnd?.Invoke();
            customerCount = 0;
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
        //LevelManager.Instance.LoadLevel(false);
    }
    public void OnNewLevelLoad()
    {
        UIManager.Instance.CloseGameOverPanel();
        UIManager.Instance.CloseSuccessPanel();
        TableManager.Instance.CreateTables();
        StartCreateCustomers();
        Time.timeScale = 1;
    }
    private void OnDisable()
    {
        Unsubscribe();
    }
}
