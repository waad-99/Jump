using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 10; // ßãíÉ ÇáÕÍÉ ÇáÊí íÖíİåÇ ÇáßÇÆä
    public float minX = -5f; // ÇáÍÏ ÇáÃÏäì Úáì ãÍæÑ X
    public float maxX = 5f; // ÇáÍÏ ÇáÃŞÕì Úáì ãÍæÑ X

    void Start()
    {
        // æÖÚ ÇáßÇÆä İí ãæŞÚ ÚÔæÇÆí Úáì ãÍæÑ X
        RandomizePosition();

        // ÅÖÇİÉ ãßæäÇÊ ÇáßíæÈ ÅĞÇ áã Êßä ãæÌæÏÉ
        AddCubeComponents();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // ÇáÊÍŞŞ ãä Ãä ÇááÇÚÈ åæ ÇáĞí ÇÕØÏã ÈÇáßÇÆä
        if (collision.CompareTag("Player"))
        {
            // ÒíÇÏÉ ÕÍÉ ÇááÇÚÈ
            HealthController playerHealth = collision.GetComponent<HealthController>();
            if (playerHealth != null)
            {
                playerHealth.IncreaseHealth(healthAmount);
                Debug.Log("Health increased by: " + healthAmount);

                // ÅÚÇÏÉ æÖÚ ÇáßÇÆä İí ãæŞÚ ÚÔæÇÆí ÌÏíÏ
                RandomizePosition();
            }
        }
    }

    // æÖÚ ÇáßÇÆä İí ãæŞÚ ÚÔæÇÆí Úáì ãÍæÑ X
    void RandomizePosition()
    {
        float randomX = Random.Range(minX, maxX); // ÊæáíÏ ãæŞÚ ÚÔæÇÆí Úáì ãÍæÑ X
        transform.position = new Vector2(randomX, transform.position.y);
    }

    // ÅÖÇİÉ ãßæäÇÊ ÇáßíæÈ
    void AddCubeComponents()
    {
        // ÅÖÇİÉ MeshRenderer ÅĞÇ áã íßä ãæÌæÏğÇ
        if (GetComponent<MeshRenderer>() == null)
        {
            gameObject.AddComponent<MeshRenderer>();
        }

        // ÅÖÇİÉ BoxCollider ÅĞÇ áã íßä ãæÌæÏğÇ
        if (GetComponent<BoxCollider>() == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }

        // ÅÖÇİÉ MeshFilter ÅĞÇ áã íßä ãæÌæÏğÇ
        if (GetComponent<MeshFilter>() == null)
        {
            MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
            meshFilter.mesh = CreateCubeMesh(); // ÅäÔÇÁ ÔÈßÉ ÇáßíæÈ
        }
    }

    // ÅäÔÇÁ ÔÈßÉ ÇáßíæÈ
    Mesh CreateCubeMesh()
    {
        Mesh mesh = new Mesh();

        // ÊÚÑíİ ÑÄæÓ ÇáßíæÈ
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f)
        };

        // ÊÚÑíİ ãËáËÇÊ ÇáßíæÈ
        int[] triangles = new int[]
        {
            0, 2, 1, 0, 3, 2, // ÇáæÌå ÇáÃãÇãí
            4, 5, 6, 4, 6, 7, // ÇáæÌå ÇáÎáİí
            0, 1, 5, 0, 5, 4, // ÇáæÌå ÇáÓİáí
            2, 3, 7, 2, 7, 6, // ÇáæÌå ÇáÚáæí
            0, 4, 7, 0, 7, 3, // ÇáæÌå ÇáÃíÓÑ
            1, 2, 6, 1, 6, 5  // ÇáæÌå ÇáÃíãä
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
}