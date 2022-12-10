using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{

    #region  Singleton
    public static UIManager Instance;
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
    public TextMeshProUGUI moneyTxt;
    public GameObject SuccessPanel;
    public GameObject GameOverPanel;
    public TextMeshProUGUI LevelText;
    private void Start()
    {
        UpdateMoneyText();
        Subscribe();
        CloseSuccessPanel();
        CloseGameOverPanel();
    }
    public void Subscribe()
    {
        DataManager.OnCurrencyUpdate += UpdateMoneyText;
        GamePlayManager.OnGameEnd += OpenSuccessUI;
    }
    public void OpenSuccessUI()
    {
        OpenSuccessPanel();
        Time.timeScale = 0;
    }
    public void UpdateMoneyText()
    {
        moneyTxt.text = DataManager.Money.ToString();
    }
    public void OpenSuccessPanel()
    {
        SuccessPanel.SetActive(true);
    }
    public void CloseSuccessPanel()
    {
        SuccessPanel.SetActive(false);
    }
    public void OpenGameOverPanel()
    {
        GameOverPanel.SetActive(true);
    }
    public void CloseGameOverPanel()
    {
        GameOverPanel.SetActive(false);
    }
    private void Unsubscribe()
    {
        DataManager.OnCurrencyUpdate -= UpdateMoneyText;
        GamePlayManager.OnGameEnd -= OpenSuccessUI;
    }
    public void UpdateLevelText()
    {
        LevelText.text = "LEVEL " + DataManager.CurrentLevel.ToString();
    }
    private void OnDisable()
    {
        Unsubscribe();
    }
}
