using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    public List<GameObject> levels;
    private GameObject currentLevel;
    private int levelIndex;
    public void LoadLevel(bool isSuccess)
    {
        if (isSuccess)
            levelIndex++;
        if (currentLevel)
            Destroy(currentLevel);
        currentLevel = Instantiate(levels[levelIndex % levels.Count]);
    }
    
}
