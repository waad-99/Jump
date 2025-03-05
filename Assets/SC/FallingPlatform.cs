using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 2f; // ����� ���� ���� ���� ������ ��� �� ����
    public float damageRate = 5f; // ���� ����� ���� ����� ������ �� �����
    private bool playerOnPlatform = false;
    private float timeOnPlatform = 0f;
    private Rigidbody2D rb;
    private HealthController playerHealth; // ���� ��� HealthController ����� �������

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // ����� ������ ����� ��� ���� ��� ������
    }

    void Update()
    {
        if (playerOnPlatform)
        {
            timeOnPlatform += Time.deltaTime;

            // ����� ��� ������ ��������
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageRate * Time.deltaTime);
            }

            // ��� ���� ������ ��� ������ ����� �������
            if (timeOnPlatform >= fallDelay)
            {
                rb.isKinematic = false; // ����� �������� ����� ������
                rb.gravityScale = 1;
                Destroy(gameObject, 2f); // ��� ������ ��� 2 �����
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            playerHealth = collision.gameObject.GetComponent<HealthController>(); // ������ ��� HealthController ����� �������
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
            timeOnPlatform = 0f; // ����� ��� ������ ��� ���� ������ ������
            playerHealth = null; // ����� ������ ��� HealthController
        }
    }
}