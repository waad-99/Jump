using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public float health = 100f; // صحة اللاعب
    public Slider healthSlider; // شريط الصحة
    public GameObject gameOverCanvas; // Canvas لعرض شاشة Game Over
    public Button restartButton; // زر الإعادة

    void Start()
    {
        // ضبط قيمة الشريط على الصحة القصوى عند بدء اللعبة
        if (healthSlider != null)
        {
            healthSlider.maxValue = health;
            healthSlider.value = health;
        }

        // إخفاء شاشة Game Over عند بدء اللعبة
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }

        // ربط زر الإعادة بالوظيفة RestartGame
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
    }

    void Update()
    {
        // التحقق من خروج اللاعب من إطار الكاميرا
        if (!IsPlayerVisible())
        {
            Die(); // موت اللاعب إذا خرج من إطار الكاميرا
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health);

        // تحديث قيمة الـ Slider
        if (healthSlider != null)
        {
            healthSlider.value = health;
        }

        // التحقق من موت اللاعب
        if (health <= 0)
        {
            Die();
        }
    }

    // زيادة صحة اللاعب
    public void IncreaseHealth(int amount)
    {
        health += amount;
        health = Mathf.Min(health, healthSlider.maxValue); // التأكد من أن الصحة لا تتجاوز الحد الأقصى

        // تحديث قيمة الـ Slider
        if (healthSlider != null)
        {
            healthSlider.value = health;
        }

        Debug.Log("Health increased by: " + amount + ". Current health: " + health);
    }

    void Die()
    {
        Debug.Log("Player Died!");
        GameOver(); // استدعاء وظيفة GameOver عند موت اللاعب
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

    // التحقق من وجود اللاعب داخل إطار الكاميرا
    bool IsPlayerVisible()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
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