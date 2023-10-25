using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] ShakeCamera shake = null;
    [SerializeField] GameObject effect = null;
    Rigidbody2D rb2D = null;

    bool isJump = false;    // ジャンプしているか
    float jumpPower = 0;    // ジャンプ力

    float speed = 275.0f;     // Playerの移動速度

    int gravityChange = 0;  // 重力の変更
    public int GravityChange
    {
        get { return gravityChange; }
    }


    bool isDeath = false;   // Playerが死んでるか判定
    public bool IsDeath
    {
        get { return isDeath; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 5.0f;
        rb2D.velocity = new Vector2(speed * Time.deltaTime, rb2D.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDeath == true) return;
        if (rb2D.velocity.x <= 0)
        {
            Destroy();
        }

        GravitySwitch();
        Jump();
    }


    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(speed * Time.deltaTime, rb2D.velocity.y);
    }


    void GravitySwitch()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
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

    void Jump()
    {
        if (isJump == true) return;
        if (Input.GetKey(KeyCode.Space))
        {
            rb2D.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
    }

    void Destroy()
    {
        shake.BeginShake(0.25f, 0.1f);
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        GameObject.Find("GameController")?.GetComponent<GameController>()?.FailureGame();
        isDeath = true;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            rb2D.gravityScale = 5.0f;
            jumpPower = 800.0f * Time.deltaTime;
            isJump = false;
        }
        else if(other.gameObject.tag == "Ceiling")
        {
            rb2D.gravityScale = -5.0f;
            jumpPower = -800.0f * Time.deltaTime;
            isJump = false;
        }

        if(other.gameObject.tag == "TheWall")
        {
            Destroy();
        }
    }
}
