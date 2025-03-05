using UnityEngine;

public class ThrowFireball : MonoBehaviour
{
    public GameObject fireballPrefab; // كائن كرة النار
    public Transform throwPoint; // نقطة الإطلاق
    public float throwSpeed = 5f; // سرعة كرة النار
    public float damage = 10f; // مقدار الضرر
    public float spawnInterval = 2f; // الفترة بين كل كرة نار
    public float minY = -2f, maxY = 2f; // حدود التغيير العشوائي لموضع Y

    void Start()
    {
        if (fireballPrefab == null || throwPoint == null)
        {
            Debug.LogError("⚠️ تأكد من تعيين fireballPrefab و throwPoint في الـ Inspector!");
            return;
        }

        // استدعاء دالة الإطلاق بشكل متكرر
        InvokeRepeating(nameof(ShootFireball), 1f, spawnInterval);
    }

    void ShootFireball()
    {
        // تحديد موضع الإطلاق عشوائيًا على المحور Y
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(throwPoint.position.x, randomY, throwPoint.position.z);

        // إنشاء كرة النار مع ضبط دورانها إلى -90 درجة على المحور Z
        GameObject fireball = Instantiate(fireballPrefab, spawnPosition, Quaternion.Euler(0, 0, -90));

        // التأكد من أن كرة النار لديها Rigidbody2D
        if (fireball.GetComponent<Rigidbody2D>() == null)
        {
            fireball.AddComponent<Rigidbody2D>().gravityScale = 0; // منع السقوط
        }

        // التأكد من أن كرة النار لديها Collider2D
        if (fireball.GetComponent<Collider2D>() == null)
        {
            fireball.AddComponent<BoxCollider2D>().isTrigger = true;
        }

        // إضافة سلوك الحركة إلى كرة النار
        FireballBehavior fireballBehavior = fireball.AddComponent<FireballBehavior>();
        fireballBehavior.Initialize(throwSpeed, damage);
    }
}

// كود سلوك كرة النار
public class FireballBehavior : MonoBehaviour
{
    private float speed;
    private float damage;

    // تهيئة سرعة الضرر
    public void Initialize(float moveSpeed, float dmg)
    {
        speed = moveSpeed;
        damage = dmg;
    }

    void Update()
    {
        // تحريك كرة النار على المحور X (من اليمين إلى اليسار)
        transform.position += Vector3.left * speed * Time.deltaTime;  // حركة من اليمين لليسار
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthController playerHealth = collision.GetComponent<HealthController>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }

        // تدمير كرة النار بعد الاصطدام
        Destroy(gameObject);
    }
}