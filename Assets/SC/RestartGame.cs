using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // وظيفة لإعادة تشغيل المشهد الحالي
    public void RestartScene()
    {
        // استئناف الوقت في اللعبة (في حالة إيقافه)
        Time.timeScale = 1f;

        // إعادة تحميل المشهد الحالي
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // وظيفة للعودة إلى القائمة الرئيسية (اختيارية)
    public void ReturnToMainMenu()
    {
        // استئناف الوقت في اللعبة (في حالة إيقافه)
        Time.timeScale = 1f;

        // تحميل مشهد القائمة الرئيسية (افترض أن مشهد القائمة الرئيسية له index 0)
        SceneManager.LoadScene(0);
    }

    // وظيفة للانتقال إلى مشهد معين (اختيارية)
    public void LoadSceneByName(string sceneName)
    {
        // استئناف الوقت في اللعبة (في حالة إيقافه)
        Time.timeScale = 1f;

        // تحميل المشهد المحدد
        SceneManager.LoadScene(sceneName);
    }

    // وظيفة للانتقال إلى مشهد معين باستخدام الـ index (اختيارية)
    public void LoadSceneByIndex(int sceneIndex)
    {
        // استئناف الوقت في اللعبة (في حالة إيقافه)
        Time.timeScale = 1f;

        // تحميل المشهد المحدد
        SceneManager.LoadScene(sceneIndex);
    }
}