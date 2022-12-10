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
    }
    #endregion
    private void Start()
    {
        //LoadLevel(false);

    }
    private DataManager _dataManager;
    public List<GameObject> levels;
    public Level currentLevel;
    public static UnityAction OnLevelUpdate;
    public void LoadLevel(bool isSuccess)
    {
        if (isSuccess)
            DataManager.CurrentLevel++;
        if (currentLevel)
            Destroy(currentLevel.gameObject);

        var level = Instantiate(levels[(DataManager.CurrentLevel-1)% levels.Count]);
        currentLevel = level.GetComponent<Level>();
        OnLevelUpdate?.Invoke();
    }

}
