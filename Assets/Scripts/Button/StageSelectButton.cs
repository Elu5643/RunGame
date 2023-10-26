using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    // ボタンUIで使う為public
    public void OnClickStage1Button()
    {
        StartCoroutine(StageSelect("Stage1"));
    }

    public void OnClickBackMenuButton()
    {
        StartCoroutine(StageSelect("TitleScene"));
    }

    IEnumerator StageSelect(string stageSelect)
    {
        GameSceneManager.Instance.FadeOut();
        while (GameSceneManager.Instance.IsFadeOut)
        {
            yield return null;
        }
        SceneManager.LoadScene(stageSelect);
    }
}
