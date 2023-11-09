using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButton : MonoBehaviour
{
    string sceneName;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    // ƒ{ƒ^ƒ“UI‚ÅŽg‚¤ˆ×public
    public void OnClickRetryStage1Button()
    {
        StartCoroutine(Result(sceneName));
    }
    
    public void OnClickReturnButton()
    {
        StartCoroutine(Result("StageSelect"));
    }

    IEnumerator Result(string stageSelect)
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
