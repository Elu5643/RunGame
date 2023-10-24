using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2D;

    float speed = 5.0f;     // Playerの移動速度
    int gravityChange = 0;  // 重力の変更
    bool isJump = false;    // ジャンプしているか
    float jumpPower = 0;    // ジャンプ力

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        GravityChange();
        Jump();

        //if(rb2D.velocity.x <= 1)
        //{
        //    Destroy(gameObject);
        //}
    }
    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
    }


    void GravityChange()
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
            rb2D.velocity = Vector3.zero;
            rb2D.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
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
    }
}
