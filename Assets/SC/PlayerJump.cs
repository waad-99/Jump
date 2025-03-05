using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour
{
    public Button jumpButton; // زر القفز
    public Rigidbody2D rb; // Rigidbody2D الخاص باللاعب
    public float jumpForce = 7f; // قوة القفز
    public float moveSpeed = 5f; // سرعة الحركة الجانبية

    private bool isGrounded; // هل اللاعب على الأرض؟

    // إضافة المتغيرات الجديدة
    public ParticleSystem jumpEffectPrefab;  // Prefab لتأثير الجسيمات عند القفز
    public AudioClip jumpSound;        // الصوت الذي يصدر عند النقز
    private AudioSource audioSource;   // مصدر الصوت

    void Start()
    {
        // ربط زر القفز بالوظيفة Jump
        if (jumpButton != null)
        {
            jumpButton.onClick.AddListener(Jump);
        }

        // افترض أن اللاعب على الأرض عند البدء
        isGrounded = true;

        // الحصول على الـ AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // التحقق من القفز باستخدام لوحة المفاتيح (اختياري)
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        // التحقق من القفز باستخدام اللمس
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // الحصول على اللمسة الأولى
            if (touch.phase == TouchPhase.Began && isGrounded) // إذا كانت اللمسة بدأت واللاعب على الأرض
            {
                Jump();
            }
        }

        // التحكم بحركة الكرة يمينًا ويسارًا بناءً على إمالة الجوال
        float moveInput = Input.acceleration.x; // الحصول على إمالة الجوال (قيمة بين -1 و1)
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y); // تطبيق الحركة الجانبية
    }

    void Jump()
    {
        if (isGrounded)
        {
            // تطبيق قوة القفز
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // اللاعب لم يعد على الأرض

            // تشغيل تأثير الجسيمات عند نفس مكان اللاعب
            if (jumpEffectPrefab != null)
            {
                // إنشاء الجسيمات عند موقع اللاعب
                ParticleSystem effect = Instantiate(jumpEffectPrefab, transform.position, Quaternion.identity);
                effect.Play(); // تشغيل الجسيمات
                Destroy(effect.gameObject, effect.main.duration); // تدمير الجسيمات بعد انتهاء التأثير
            }

            // تشغيل الصوت
            if (audioSource != null && jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound); // تشغيل صوت القفز
            }
        }
    }

    // تفعيل حركة اللاعب
    public void EnableMovement()
    {
        enabled = true; // تفعيل السكربت
    }

    // تعطيل حركة اللاعب
    public void DisableMovement()
    {
        enabled = false; // تعطيل السكربت
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // التحقق من أن اللاعب على الأرض أو منصة
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true; // اللاعب على الأرض
        }
    }

    // عند تفعيل الكائن
    private void OnEnable()
    {
        isGrounded = true; // افترض أن اللاعب على الأرض عند التفعيل
    }

    // عند تعطيل الكائن
    private void OnDisable()
    {
        isGrounded = false; // افترض أن اللاعب ليس على الأرض عند التعطيل
    }
}
