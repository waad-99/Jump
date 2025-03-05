using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 10; // ���� ����� ���� ������ ������
    public float minX = -5f; // ���� ������ ��� ���� X
    public float maxX = 5f; // ���� ������ ��� ���� X

    void Start()
    {
        // ��� ������ �� ���� ������ ��� ���� X
        RandomizePosition();

        // ����� ������ ������ ��� �� ��� ������
        AddCubeComponents();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ �� �� ������ �� ���� ����� �������
        if (collision.CompareTag("Player"))
        {
            // ����� ��� ������
            HealthController playerHealth = collision.GetComponent<HealthController>();
            if (playerHealth != null)
            {
                playerHealth.IncreaseHealth(healthAmount);
                Debug.Log("Health increased by: " + healthAmount);

                // ����� ��� ������ �� ���� ������ ����
                RandomizePosition();
            }
        }
    }

    // ��� ������ �� ���� ������ ��� ���� X
    void RandomizePosition()
    {
        float randomX = Random.Range(minX, maxX); // ����� ���� ������ ��� ���� X
        transform.position = new Vector2(randomX, transform.position.y);
    }

    // ����� ������ ������
    void AddCubeComponents()
    {
        // ����� MeshRenderer ��� �� ��� �������
        if (GetComponent<MeshRenderer>() == null)
        {
            gameObject.AddComponent<MeshRenderer>();
        }

        // ����� BoxCollider ��� �� ��� �������
        if (GetComponent<BoxCollider>() == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }

        // ����� MeshFilter ��� �� ��� �������
        if (GetComponent<MeshFilter>() == null)
        {
            MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
            meshFilter.mesh = CreateCubeMesh(); // ����� ���� ������
        }
    }

    // ����� ���� ������
    Mesh CreateCubeMesh()
    {
        Mesh mesh = new Mesh();

        // ����� ���� ������
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

        // ����� ������ ������
        int[] triangles = new int[]
        {
            0, 2, 1, 0, 3, 2, // ����� �������
            4, 5, 6, 4, 6, 7, // ����� ������
            0, 1, 5, 0, 5, 4, // ����� ������
            2, 3, 7, 2, 7, 6, // ����� ������
            0, 4, 7, 0, 7, 3, // ����� ������
            1, 2, 6, 1, 6, 5  // ����� ������
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
}