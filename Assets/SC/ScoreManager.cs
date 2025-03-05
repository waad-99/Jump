using UnityEngine;
using TMPro; // استيراد مكتبة TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // نص عرض المسافة المقطوعة
    public TextMeshProUGUI highScoreText; // نص عرض السكور السابق
    public Transform player; // مرجع إلى كائن اللاعب

    private float startY; // نقطة البداية للاعب
    private float highScore; // أعلى مسافة مقطوعة (السكور السابق)

    void Start()
    {
        if (player != null)
        {
            startY = player.position.y; // حفظ ارتفاع البداية
        }

        // تحميل السكور السابق من PlayerPrefs
        highScore = PlayerPrefs.GetFloat("HighScore", 0);

        // تحديث النصوص
        UpdateScore(0);
        UpdateHighScore();
    }

    void Update()
    {
        if (player != null)
        {
            float distance = player.position.y - startY; // حساب المسافة المقطوعة
            UpdateScore(distance);

            // إذا كانت المسافة الحالية أكبر من السكور السابق، قم بتحديث السكور السابق
            if (distance > highScore)
            {
                highScore = distance;
                PlayerPrefs.SetFloat("HighScore", highScore); // حفظ السكور السابق
                UpdateHighScore();
            }
        }
    }

    void UpdateScore(float distance)
    {
        scoreText.text = "Distance: " + Mathf.FloorToInt(distance) + " m"; // تحديث نص المسافة الحالية
    }

    void UpdateHighScore()
    {
        highScoreText.text = "High Score: " + Mathf.FloorToInt(highScore) + " m"; // تحديث نص السكور السابق
    }
}