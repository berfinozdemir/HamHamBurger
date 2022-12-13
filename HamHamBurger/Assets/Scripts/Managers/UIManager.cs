using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    public TextMeshProUGUI totalCurrency;
    public GameObject SuccessPanel;
    public GameObject GameOverPanel;
    public TextMeshProUGUI LevelText;
    public Button RetryButton;
    public Button NextButton;
    private void Start()
    {
        UpdateMoneyText();
        Subscribe();
        SuccessPanelEnabled(false);
        GameOverPanelEnabled(false);
        UpdateLevelText();
        
    }
    void OnRetryButtonClicked()
    {
        LevelManager.Instance.LoadLevel(false);
    }
    void OnNextButtonClicked()
    {
        LevelManager.Instance.LoadLevel(true);
    }
    public void Subscribe()
    {
        DataManager.OnCurrencyUpdate += UpdateCurrency;
        GamePlayManager.OnLevelMoneyUpdate += UpdateMoneyText;
        GamePlayManager.OnGameEnd += OpenSuccessUI;
        DataManager.OnLevelUpdate += UpdateLevelText;
        RetryButton.onClick.AddListener(OnRetryButtonClicked);
        NextButton.onClick.AddListener(OnNextButtonClicked);
    }
    public void OpenSuccessUI()
    {
        SuccessPanelEnabled(true);
        Time.timeScale = 0;
    }
    public void UpdateMoneyText()
    {
        moneyTxt.text = GamePlayManager.Instance.LevelMoney.ToString();
    }
    public void UpdateCurrency()
    {
        totalCurrency.text = DataManager.Money.ToString();
    }
    public void SuccessPanelEnabled(bool enabled)
    {
        SuccessPanel.SetActive(enabled);
    }
    public void GameOverPanelEnabled(bool enabled)
    {
        GameOverPanel.SetActive(enabled);
    }
    public void UpdateLevelText()
    {
        LevelText.text = "LEVEL " + DataManager.CurrentLevel.ToString();
    }
    private void Unsubscribe()
    {
        DataManager.OnCurrencyUpdate -= UpdateMoneyText;
        GamePlayManager.OnGameEnd -= OpenSuccessUI;
        DataManager.OnLevelUpdate -= UpdateLevelText;
        RetryButton.onClick.RemoveAllListeners();
        NextButton.onClick.RemoveAllListeners();
    }
    
    private void OnDisable()
    {
        Unsubscribe();
    }
}
