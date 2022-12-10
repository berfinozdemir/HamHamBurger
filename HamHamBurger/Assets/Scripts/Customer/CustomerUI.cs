using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class CustomerUI : MonoBehaviour
{
    public Image timeImage;
    public Image filledTimeImage;
    public bool TimeOut;
    public static UnityAction OnTimeOut;
    private void Start()
    {
        CloseTimeImage();
    }
    public void OpenTimeImage()
    {
        timeImage.gameObject.SetActive(true);

    }
    public void CloseTimeImage()
    {
        filledTimeImage.fillAmount = 0;
        timeImage.gameObject.SetActive(false);
        isStop = true;
    }
    public void BeginTimer()
    {
        isStop = false;
        OpenTimeImage();
        TimeOut = false;
        filledTimeImage.fillAmount = 0;
        StartCoroutine(Timer(LevelManager.Instance.currentLevel.levelData.CustomerWaitTime));
    }
    bool isStop;
    IEnumerator Timer(float totalTime)
    {
        float currentTime=0;
        while (currentTime < totalTime)
        {
            if (!isStop)
                currentTime += Time.deltaTime;
            filledTimeImage.fillAmount = Mathf.InverseLerp(totalTime, 0, currentTime);

            yield return null;
        }
        TimeOut = true;
        GamePlayManager.Instance.OnGameOver();
        CloseTimeImage();
    }
}
