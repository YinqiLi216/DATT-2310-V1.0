using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    // 要转换的门对象（初始处于激活状态）
    public GameObject door;
    // 镜子对象（初始应设置为不激活）
    public GameObject mirror;
    // 交互按键
    public KeyCode interactionKey = KeyCode.E;

    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if(playerInRange && Input.GetKeyDown(interactionKey))
        {
            // 当玩家在触发区域且按下E后，将门隐藏，镜子显示
            if(door != null)
            {
                door.SetActive(false);
            }
            if(mirror != null)
            {
                mirror.SetActive(true);
            }
            // 如果该交互只需要触发一次，可以禁用本脚本或者销毁触发器物体
            Destroy(gameObject);
        }
    }
}