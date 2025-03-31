using UnityEngine;

public class VisibilityController : MonoBehaviour
{
    // 如果设置为 true，物体将在开始时自动隐藏
    public bool hideOnStart = true;

    void Start()
    {
        if (hideOnStart)
        {
            gameObject.SetActive(false);
        }
    }

    // 通过外部调用显示物体
    public void ShowObject()
    {
        gameObject.SetActive(true);
    }

    // 通过外部调用隐藏物体
    public void HideObject()
    {
        gameObject.SetActive(false);
    }
}
