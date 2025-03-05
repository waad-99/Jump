using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject gameOverCanvas; // Canvas لعرض شاشة Game Over

    void Update()
    {
        // التحقق من سقوط اللاعب خارج الشاشة
        if (transform.position.y < Camera.main.transform.position.y - 6f)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // عرض شاشة Game Over
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }

        // إيقاف الوقت في اللعبة
        Time.timeScale = 0f;
    }

    // وظيفة لإعادة تشغيل اللعبة
    public void RestartGame()
    {
        // استئناف الوقت في اللعبة
        Time.timeScale = 1f;

        // إعادة تحميل المشهد الحالي
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // وظيفة للعودة إلى القائمة الرئيسية (اختيارية)
    public void ReturnToMainMenu()
    {
        // استئناف الوقت في اللعبة
        Time.timeScale = 1f;

        // تحميل مشهد القائمة الرئيسية (افترض أن مشهد القائمة الرئيسية له index 0)
        SceneManager.LoadScene(0);
    }
}