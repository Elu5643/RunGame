using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Drawing;

public class GameController : MonoBehaviour
{
    [SerializeField] Text resultText = null;
    [SerializeField] Canvas resultButton = null;

    [SerializeField] GameObject bgmObject;
    AudioSource bgm;
    void Start()
    {
        bgm = bgmObject.GetComponent<AudioSource>();
    }

    // �v���C���[���Ŏ��S�����ۂɂ��̊֐����Ă�
    public void FailureGame()
    {
        resultText.color = new UnityEngine.Color(255, 0, 0, 255);
        StartCoroutine(Result("GameOver"));
    }

    // �v���C���[���ŃN���A�����ۂɂ��̊֐����Ă�
    public void ClearGame()
    {
        resultText.color = new UnityEngine.Color(0, 255, 0, 255);
        StartCoroutine(Result("  Clear "));
    }


    IEnumerator Result(string message)
    {
        resultText.text = message;
        resultButton.enabled = true;
        bgm.Stop();
        yield break;
    }
}
