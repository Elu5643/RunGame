using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{
    [SerializeField] Text resultText = null;
    [SerializeField] Text pleaseText = null;


    // �v���C���[���Ŏ��S�����ۂɂ��̊֐����Ă�
    public void FailureGame()
    {
        StartCoroutine(Result("GameOver"));
    }

    // �v���C���[���ŃN���A�����ۂɂ��̊֐����Ă�
    public void ClearGame()
    {
        StartCoroutine(Result("Clear"));
    }


    IEnumerator Result(string message)
    {
        resultText.text = message;
        pleaseText.enabled = true;
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        SceneManager.LoadScene("StageSelect");
    }
}
