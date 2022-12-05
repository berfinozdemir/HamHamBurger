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
    public GameObject currentLevel;
    private int levelIndex;
    public void LoadLevel(bool isSuccess)
    {
        if (isSuccess)
            levelIndex++;
        if (currentLevel)
            Destroy(currentLevel);
        currentLevel = Instantiate(levels[levelIndex % levels.Count]);
        Time.timeScale = 1f;
        UIManager.Instance.CloseGameOverPanel();
        UIManager.Instance.CloseSuccessPanel();
        //NavMesh.Instance.UpdateNavmesh();
          
    }
    void Start()
    {
        //NavMesh.Instance.UpdateNavmesh();
    }
}
