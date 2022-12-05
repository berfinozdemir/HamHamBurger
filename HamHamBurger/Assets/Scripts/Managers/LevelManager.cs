using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    public static LevelManager Instance;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        LoadLevel(false);
    }
    #endregion
    public List<NavMeshSurface> surafecs;
    public List<GameObject> levels;
    public Level currentLevel;
    private int levelIndex;
    private LevelData CurrentLevelData;
    public void LoadLevel(bool isSuccess)
    {
        if (isSuccess)
            levelIndex++;
        if (currentLevel)
        {
            Destroy(currentLevel.gameObject);

        }
        var level = Instantiate(levels[levelIndex % levels.Count]);
        currentLevel = level.GetComponent<Level>();
        TableManager.Instance.CreateTables();
        GamePlayManager.Instance.StartCreateCustomers();
        //CurrentLevelData = currentLevel.GetComponent<Level>().levelData;
        Time.timeScale = 1f;
        UIManager.Instance.CloseGameOverPanel();
        UIManager.Instance.CloseSuccessPanel();
          
    }
    void Start()
    {

    }
}
