using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorial : MonoBehaviour
{
    Rigidbody2D rb2D = null;


    bool isJump = false;    // �W�����v���Ă��邩
    float jumpPower = 0;    // �W�����v��
    int gravityChange = 0;  // �d�͂̕ύX

    public int GravityChange
    {
        get { return gravityChange; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        GameSoundManager.Instance.PlayBGM(GameSoundManager.BGMType.Title);

        Jump();
        GravitySwitch();
    }

    void Jump()
    {
#if UNITY_EDITOR
        if (isJump == true) return;
        if (Input.GetKey(KeyCode.Space))
        {
            GameSoundManager.Instance.PlaySE(GameSoundManager.SEType.Jump);

            rb2D.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }

#else
        if (isJump == true) return;
        Touch touch = Input.GetTouch(0);

        if (Input.mousePosition.x <= Screen.width / 2)
        {
            // �������^�b�v������
            if (touch.phase == TouchPhase.Began)
            {
                GameSoundManager.Instance.PlaySE(GameSoundManager.SEType.Jump);
                rb2D.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
                isJump = true;
            }
        }
#endif
    }


    void GravitySwitch()
    {

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameSoundManager.Instance.PlaySE(GameSoundManager.SEType.GravitySwitch);
            gravityChange++;
            if (gravityChange % 2 == 0)
            {
                rb2D.gravityScale = 1000.0f;
            }
            else if (gravityChange % 2 == 1)
            {
                rb2D.gravityScale = -1000.0f;
            }
        }
#else
        Touch touch = Input.GetTouch(0);

        if (Input.mousePosition.x >= Screen.width / 2)
        {
            // �E�����^�b�v������
            if (touch.phase == TouchPhase.Began)
            {
                GameSoundManager.Instance.PlaySE(GameSoundManager.SEType.GravitySwitch);
                gravityChange++;
                if (gravityChange % 2 == 0)
                {
                    rb2D.gravityScale = 1000.0f;
                }
                else if (gravityChange % 2 == 1)
                {
                    rb2D.gravityScale = -1000.0f;
                }
            }
        }
#endif
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            rb2D.gravityScale = 5.0f;
            jumpPower = 800.0f * Time.deltaTime;
            isJump = false;
        }
        else if (other.gameObject.tag == "Ceiling")
        {
            rb2D.gravityScale = -5.0f;
            jumpPower = -800.0f * Time.deltaTime;
            isJump = false;
        }
    }
}
