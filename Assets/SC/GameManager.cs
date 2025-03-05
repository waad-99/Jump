using UnityEngine;
using System.Diagnostics; // نحتاجها فقط للكمبيوتر

public class GameManager : MonoBehaviour
{
    public void RestartGame()
    {
        UnityEngine.Debug.Log("🔄 إغلاق وإعادة تشغيل التطبيق...");

#if UNITY_ANDROID || UNITY_IOS
            // إعادة تشغيل المشهد على الهواتف المحمولة
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        
#elif UNITY_STANDALONE
            // إغلاق اللعبة على الكمبيوتر
            Application.Quit();
        
            // ⚠️ إعادة تشغيل التطبيق تلقائيًا قد لا تعمل في كل الأجهزة بسبب قيود الأمان
            Process.Start(Application.dataPath.Replace("_Data", ".exe")); 
        
#endif
    }
}
