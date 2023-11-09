using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{

    void Start()
    {
        GameSoundManager.Instance.PlayBGM(GameSoundManager.BGMType.StageSelect);
    }

    // ƒ{ƒ^ƒ“UI‚ÅŽg‚¤ˆ×public
    public void OnClickStage1Button()
    {
        StartCoroutine(StageSelect("Stage1"));
    }
    
    public void OnClickStage2Button()
    {
        StartCoroutine(StageSelect("Stage2"));
    }

    public void OnClickBackMenuButton()
    {
        StartCoroutine(StageSelect("TitleScene"));
    }

    IEnumerator StageSelect(string stageSelect)
    {
        GameSoundManager.Instance.PlaySE(GameSoundManager.SEType.Click);
        GameSceneManager.Instance.FadeOut();
        while (GameSceneManager.Instance.IsFadeOut)
        {
            yield return null;
        }
        SceneManager.LoadScene(stageSelect);
    }
}
