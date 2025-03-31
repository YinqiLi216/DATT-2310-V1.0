using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class QuitGame : MonoBehaviour
{
    // 这个方法将会在点击按钮时被调用
    public void Quit()
    {
        // 在 Editor 中退出播放模式
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        // 在构建后的游戏中退出游戏
        Application.Quit();
        #endif
    }
}