using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject stablePlatformPrefab; // ���� �����
    public GameObject fallingPlatformPrefab; // ���� ���� ��� ��� ����
    public float spawnRate = 1.5f; // ���� ����� �������
    public float platformSpacingMin = 1.5f; // ���� ������ ������� ��� �������
    public float platformSpacingMax = 2.5f; // ���� ������ ������� ��� �������

    private float lastSpawnTime = 0;
    private float lastYPosition = 0;
    private int spawnCount = 0; // ���� ������ ��� ��� ����� ���� �����

    void Update()
    {
        if (Time.time - lastSpawnTime > spawnRate)
        {
            SpawnPlatform();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnPlatform()
    {
        float xPos = Random.Range(-2f, 2f); // ����� ���� X ������ ������
        float yPos = lastYPosition + Random.Range(platformSpacingMin, platformSpacingMax); // ��� �� ���� ���� ��� ������� ������ �����
        lastYPosition = yPos;

        // ����� ��� ������ ���� ���� �������
        bool isStable = spawnCount == 0; // �� ���� ���� ���� �����

        // ����� ������
        spawnCount++;

        // ��� �� 3 ����ʡ ��� ����� ����� ������ ���� ��� ���� ����� ������
        if (spawnCount >= 3)
        {
            spawnCount = 0;
        }

        // ����� ��� ������ ���� ���� �������
        GameObject platformToSpawn = isStable ? stablePlatformPrefab : fallingPlatformPrefab;

        // ����� ������ �� ������ ������
        GameObject spawnedPlatform = Instantiate(platformToSpawn, new Vector3(xPos, yPos, 0), Quaternion.identity);

        // ��� ���� ������ �� ����� ���� ���ء ��� ��� ����� ������
        if (!isStable)
        {
            FallingPlatform fallingPlatformScript = spawnedPlatform.AddComponent<FallingPlatform>();
            fallingPlatformScript.fallDelay = 2f; // ����� ���� ������� ������ ��� �� ����
        }
    }
}
