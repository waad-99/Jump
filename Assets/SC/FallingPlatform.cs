using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 2f; // ÇáãÏÉ ÇáÊí ÊÈŞì İíåÇ ÇáãäÕÉ ŞÈá Ãä ÊÓŞØ
    public float damageRate = 5f; // ãÚÏá ÇáÖÑÑ ÇáĞí íÓÈÈå ÇááÇÚÈ ßá ËÇäíÉ
    private bool playerOnPlatform = false;
    private float timeOnPlatform = 0f;
    private Rigidbody2D rb;
    private HealthController playerHealth; // ãÑÌÚ Åáì HealthController ÇáÎÇÕ ÈÇááÇÚÈ

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // ÅÈŞÇÁ ÇáãäÕÉ ËÇÈÊÉ ÍÊì íÍíä æŞÊ ÓŞæØåÇ
    }

    void Update()
    {
        if (playerOnPlatform)
        {
            timeOnPlatform += Time.deltaTime;

            // ÅäŞÇÕ ÕÍÉ ÇááÇÚÈ ÊÏÑíÌíÇğ
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageRate * Time.deltaTime);
            }

            // ÈÏÁ ÓŞæØ ÇáãäÕÉ ÈÚÏ ÇäŞÖÇÁ ÇáãÏÉ ÇáãÍÏÏÉ
            if (timeOnPlatform >= fallDelay)
            {
                rb.isKinematic = false; // ÊİÚíá ÇáÌÇĞÈíÉ áÓŞæØ ÇáãäÕÉ
                rb.gravityScale = 1;
                Destroy(gameObject, 2f); // ÍĞİ ÇáãäÕÉ ÈÚÏ 2 ËÇäíÉ
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            playerHealth = collision.gameObject.GetComponent<HealthController>(); // ÇáÍÕæá Úáì HealthController ÇáÎÇÕ ÈÇááÇÚÈ
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
            timeOnPlatform = 0f; // ÅÚÇÏÉ ÖÈØ ÇáÚÏÇÏ ÅĞÇ ÛÇÏÑ ÇááÇÚÈ ÇáãäÕÉ
            playerHealth = null; // ÅÒÇáÉ ÇáãÑÌÚ Åáì HealthController
        }
    }
}