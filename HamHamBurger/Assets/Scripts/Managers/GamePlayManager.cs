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
    public int customerCount = 0;
    public static UnityAction OnGameEnd;
    private IEnumerator coroutine;
    void Start()
    {
        //LoadGame();
        
    }
    public void StartCreateCustomers()
    {
        CustomerManager.Instance.AddNewCustomer();
        customerCount++;
        coroutine = WaitAndSpawn(LevelManager.Instance.currentLevel.levelData.CustomerWaitTime);
        StartCoroutine(coroutine);
    }
    IEnumerator WaitAndSpawn(float waitTime)
    {
        while (customerCount < LevelManager.Instance.currentLevel.levelData.CustomerCount)
        {
            yield return new WaitForSeconds(waitTime);
            CustomerManager.Instance.AddNewCustomer();
            customerCount++;
        }
    }
    public bool IsGameEnd()
    {
        bool gameEnd = false;
        if (customerCount == LevelManager.Instance.currentLevel.levelData.CustomerCount && CustomerManager.Instance.customers.Count == 0)
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
    }
    public void LoadGame()
    {
        UIManager.Instance.CloseGameOverPanel();
        UIManager.Instance.CloseSuccessPanel();
        Time.timeScale = 1;
        LevelManager.Instance.LoadLevel(true);
    }
}
