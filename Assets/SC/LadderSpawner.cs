using UnityEngine;

public class LadderSpawner : MonoBehaviour
{
    public GameObject ladderPrefab; // Prefab ����� ������
    public GameObject climbableLadderPrefab; // Prefab ����� ������ ������ ������
    public float spawnRate = 1.5f; // ���� ����� �������
    private float lastSpawnTime = 0;
    private float lastYPosition = 0;

    void Update()
    {
        if (Time.time - lastSpawnTime > spawnRate)
        {
            SpawnLadder();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnLadder()
    {
        float xPos = Random.Range(-2f, 2f); // ����� ���� X ������ �����
        float yPos = lastYPosition + Random.Range(1.2f, 1.8f); // ��� ����� ���� ��� ������
        lastYPosition = yPos;

        // ����� �������� �� ��� ��� ����� ������ ������ �� ��
        bool isClimbable = Random.value > 0.5f; // 50% ���� �� ���� ����� ������ ������

        GameObject ladderToSpawn = isClimbable ? climbableLadderPrefab : ladderPrefab;

        Instantiate(ladderToSpawn, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }
}
