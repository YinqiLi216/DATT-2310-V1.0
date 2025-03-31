using System;
using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed, direction0, faceDirection0;
    public Boolean rightCommand, leftCommand, sitting;
    private GameObject panel, black;
    private Rigidbody2D rigidBody;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Boolean gameover, gameoverTrigger;
    private int runningFactor;
    void Start()
    {
        if (GameObject.Find("MainDialoguePanel") != null)
        {
            panel = GameObject.Find("MainDialoguePanel");
        }
        if (GameObject.Find("Black") != null)
        {
            black = GameObject.Find("Black");
        }
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        faceDirection0 = 1;
        direction0 = 1;
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        Boolean running = Input.GetKey(KeyCode.LeftShift);
        runningFactor = running ? 2 : 1;
        spriteRenderer.color = sitting ? new Color(1, 1, 1, 0) : Color.white;
    }

    void FixedUpdate()
    {
        Vector2 velocity = rigidBody.linearVelocity;

        if (panel.GetComponent<TextPresentor>().IsHidden() && !IsGameOver())
        {
            float horizontal = sitting ? 0 : Input.GetAxis("Horizontal");

            if (leftCommand)
            {
                velocity.x = (Mathf.Max(horizontal, 0) - 1) * runningFactor * moveSpeed;
            }
            else if (rightCommand)
            {
                velocity.x = (Mathf.Min(horizontal, 0) + 1) * runningFactor * moveSpeed;
            }
            else
            {
                velocity.x = horizontal * runningFactor * moveSpeed;
            }

            rigidBody.linearVelocity = velocity;

            anim.SetBool("walking", Mathf.Abs(velocity.x) > 0);
        }
        else
        {
            velocity.x = 0;
            rigidBody.linearVelocity = velocity;
        }

        direction0 = velocity.x > 0 ? 1 : (velocity.x < 0 ? -1 : direction0);
        faceDirection0 += 0.2f * direction0;
        faceDirection0 = Math.Min(1, Math.Max(-1, faceDirection0));

        transform.localScale = new Vector3(faceDirection0, 1, 1);

        //��Ϸʧ��
        if (gameover && !gameoverTrigger) {
            gameoverTrigger = true;
            anim.SetBool("hit", true);
            black.GetComponent<BlackCoverScript>().turnAlpha = false;
            Invoke("ReloadScene", 3f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Danger")) { 
            gameover = true;
        }
        if (collision.gameObject.CompareTag("Teleporter"))
        {
            SceneManager.LoadScene(collision.gameObject.GetComponent<SceneTeleporter>().sceneName);
        }
        if (collision.gameObject.CompareTag("PlatformEdge"))
        {
            rigidBody.linearVelocity = new Vector3(-10, 0, 0);
        }

    }

    public Boolean IsGameOver() {
        return gameover;
    }

    // 新接口：根据方向和持续时间执行强制移动
    public void ForceMove(string direction, float duration)
    {
        // 先停止现有的移动命令，防止叠加
        StopMovingCommand();

        // 根据传入的方向设置强制移动
        if (direction == "right")
        {
            rightCommand = true;
        }
        else if (direction == "left")
        {
            leftCommand = true;
        }

        // 启动协程，duration 秒后停止强制移动
        StartCoroutine(StopForcedMovementAfter(duration));
    }

    // 协程：等待指定时间后停止强制移动
    private IEnumerator StopForcedMovementAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        StopMovingCommand();
    }

    public void StopMovingCommand()
    {
        rightCommand = false;
        leftCommand = false;
    }

    public Boolean HasMovingCommand() {
        return leftCommand || rightCommand;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
