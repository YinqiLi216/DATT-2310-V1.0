using UnityEngine;

public class AlleyEventManager : MonoBehaviour
{
    // 用于防止同一事件重复触发的标志
    private bool hasTriggered430 = false;
    private bool hasTriggered345 = false;
    private bool hasTriggered230 = false;
    private bool hasTriggered130 = false;
    private bool hasTriggered045 = false;
    private bool hasTriggered015 = false;
    private bool hasTriggered000 = false;

    // 引用对话系统和场景元素的对象，可在 Inspector 中拖入
    public TextPresentor dialoguePanel;
    public GameObject keyObject;
    public GameObject neonSign;
    public GameObject mirrorObject;

    // 各阶段对话文本
    [TextArea] public string[] lines_Stage545; // 进入小巷时
    [TextArea] public string[] lines_Stage430; // 倒计时 4:30（270秒）
    [TextArea] public string[] lines_Stage345; // 倒计时 3:45（225秒）
    [TextArea] public string[] lines_Stage230; // 倒计时 2:30（150秒）
    [TextArea] public string[] lines_Stage130; // 倒计时 1:30（90秒）
    [TextArea] public string[] lines_Stage045; // 倒计时 0:45（45秒）
    [TextArea] public string[] lines_Stage015; // 倒计时 0:15（15秒）
    [TextArea] public string[] lines_Stage000; // 倒计时 0:00（事件终点）

    void Start()
    {
        // 初始化时隐藏一些场景元素
        if (keyObject != null)
            keyObject.SetActive(false);
        if (neonSign != null)
            neonSign.SetActive(false);
        if (mirrorObject != null)
            mirrorObject.SetActive(false);

        // 进入场景时显示第一段对话
        if (dialoguePanel != null)
        {
            dialoguePanel.lines = lines_Stage545;
            dialoguePanel.HidePanel(false);
        }
    }

    void Update()
    {
        // 使用全局计时器的剩余时间
        float remaining = Timer.globalRemainTime; // 或者 Timer.Instance.getRemainingTime();

        // 根据 remaining 值来判断触发不同事件
        if (remaining <= 270f && !hasTriggered430)
        {
            hasTriggered430 = true;
            TriggerEvent(lines_Stage430);
            // 可在此激活 neonSign 之类的元素
            if(neonSign != null)
                neonSign.SetActive(true);
        }

        if (remaining <= 225f && !hasTriggered345)
        {
            hasTriggered345 = true;
            TriggerEvent(lines_Stage345);
        }

        if (remaining <= 150f && !hasTriggered230)
        {
            hasTriggered230 = true;
            TriggerEvent(lines_Stage230);
            // 出现钥匙
            if(keyObject != null)
                keyObject.SetActive(true);
        }

        if (remaining <= 90f && !hasTriggered130)
        {
            hasTriggered130 = true;
            TriggerEvent(lines_Stage130);
        }

        if (remaining <= 45f && !hasTriggered045)
        {
            hasTriggered045 = true;
            TriggerEvent(lines_Stage045);
        }

        if (remaining <= 15f && !hasTriggered015)
        {
            hasTriggered015 = true;
            TriggerEvent(lines_Stage015);
        }

        if (remaining <= 0f && !hasTriggered000)
        {
            hasTriggered000 = true;
            TriggerEvent(lines_Stage000);
            if (mirrorObject != null)
                mirrorObject.SetActive(true);
            // 这里可以添加镜子碎裂动画或其他特效
        }
    }

    // 简单的事件触发方法
    void TriggerEvent(string[] dialogueLines)
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.lines = dialogueLines;
            dialoguePanel.HidePanel(false);
        }
    }
}