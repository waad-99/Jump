using UnityEngine;
using System.Collections;

public class RectangleSpawner : MonoBehaviour
{
    public GameObject stableRectanglePrefab; // المستطيل الثابت
    public GameObject fallingRectanglePrefab; // المستطيل الذي يسقط
    public GameObject healthCubePrefab; // الكيوب الذي يمنح الصحة
    public GameObject firePrefab; // بريفاب النار
    public float spawnRate = 1.5f; // معدل ظهور المستطيلات
    public float ladderSpacingMin = 1.2f; // الحد الأدنى للمسافة الرأسية بين المستطيلات
    public float ladderSpacingMax = 1.8f; // الحد الأقصى للمسافة الرأسية بين المستطيلات
    public float stableMinX = -2f; // الحد الأدنى للموقع الأفقي للمستطيل الثابت
    public float stableMaxX = 2f; // الحد الأقصى للموقع الأفقي للمستطيل الثابت
    public float fireMinX = 3f; // الحد الأدنى للموقع الأفقي للنار
    public float fireMaxX = 5f; // الحد الأقصى للموقع الأفقي للنار
    public float initialY = 0f; // الموضع الرأسي الأولي
    public float healthCubeChance = 0.3f; // احتمال ظهور الكيوب (30%)
    public float fireSpeed = 5f; // سرعة النار

    private float lastSpawnTime = 0;
    private float lastYPosition = 0;
    private int spawnCount = 0; // عداد لتحديد نوع المستطيل

    void Start()
    {
        lastYPosition = initialY; // تعيين الموضع الرأسي الأولي
    }

    void Update()
    {
        if (Time.time - lastSpawnTime > spawnRate)
        {
            SpawnRectangle();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnRectangle()
    {
        // تحديد الموضع الأفقي للمستطيل بشكل عشوائي ضمن النطاق المحدد للمستطيلات
        float xPos = Random.Range(stableMinX, stableMaxX);

        // تحديد المسافة الرأسية بين المستطيلات
        float ladderSpacing = Random.Range(ladderSpacingMin, ladderSpacingMax);
        float yPos = lastYPosition + ladderSpacing;
        lastYPosition = yPos;

        // تحديد نوع المستطيل (ثابت أو ساقط)
        bool isStable = spawnCount == 0; // أول مستطيل يكون ثابتًا

        // زيادة العداد
        spawnCount++;

        // إعادة العداد إلى الصفر بعد 3 مستطيلات
        if (spawnCount >= 3)
        {
            spawnCount = 0;
        }

        // اختيار النوع المناسب من المستطيلات
        GameObject rectangleToSpawn = isStable ? stableRectanglePrefab : fallingRectanglePrefab;

        // إنشاء المستطيل في الموضع المحدد
        GameObject spawnedRectangle = Instantiate(rectangleToSpawn, new Vector3(xPos, yPos, 0), Quaternion.identity);

        // احتمال ظهور كيوب الصحة فوق المستطيل
        if (Random.value < healthCubeChance)
        {
            Vector3 healthCubePosition = new Vector3(xPos, yPos + 0.5f, 0); // ضع الكيوب فوق المستطيل
            Instantiate(healthCubePrefab, healthCubePosition, Quaternion.identity);
        }

        // الآن قم بإنشاء النار التي تخرج من المستطيل
        SpawnFire(yPos); // تمرير yPos للمكان الذي تخرج منه النار
    }

    // دالة لإنشاء النار
    void SpawnFire(float yPos)
    {
        // تحديد مكان خروج النار بشكل عشوائي ضمن النطاق المحدد للنار
        float fireExitX = Random.Range(fireMinX, fireMaxX);  // مكان الخروج على المحور الأفقي (من اليمين)
        float fireExitY = yPos + 2f; // مكان الخروج على المحور الرأسي (أعلى المستطيل)

        // وضع النار في الموضع الذي حددته
        Vector3 firePosition = new Vector3(fireExitX, fireExitY, 0);
        GameObject fireInstance = Instantiate(firePrefab, firePosition, Quaternion.Euler(0, 0, -90)); // تحديد الدوران هنا

        // تحريك النار باستخدام Rigidbody2D
        Rigidbody2D rb = fireInstance.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.left * fireSpeed; // تحرك النار نحو اليسار
        }

        // التحقق من مكان النار وإذا وصلت إلى الـ fireMaxX، نقوم بتدميرها
        StartCoroutine(DestroyFireWhenOutOfBounds(fireInstance));
    }

    // Coroutine للتحقق من مكان النار وتدميرها عندما تصل إلى الحد الأقصى
    private IEnumerator DestroyFireWhenOutOfBounds(GameObject fireInstance)
    {
        while (fireInstance != null)
        {
            // التحقق من موقع النار
            if (fireInstance.transform.position.x <= fireMaxX)
            {
                // إذا وصلت النار إلى الحد الأقصى، دمرها
                Destroy(fireInstance);
                yield break;
            }

            yield return null;
        }
    }
}
