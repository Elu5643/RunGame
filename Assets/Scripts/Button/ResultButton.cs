using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButton : MonoBehaviour
{
    [SerializeField] AudioClip clickSE = null;
    AudioSource audioSource = null;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // ƒ{ƒ^ƒ“UI‚ÅŽg‚¤ˆ×public
    public void OnClickRetryStage1Button()
    {
        StartCoroutine(Result("Stage1"));
    }
    
    public void OnClickReturnButton()
    {
        StartCoroutine(Result("StageSelect"));
    }

    IEnumerator Result(string stageSelect)
    {
        audioSource.PlayOneShot(clickSE);
        GameSceneManager.Instance.FadeOut();
        while (GameSceneManager.Instance.IsFadeOut)
        {
            yield return null;
        }
        SceneManager.LoadScene(stageSelect);
    }
}
