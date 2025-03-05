using UnityEngine;

public class LadderSpawner : MonoBehaviour
{
    public GameObject ladderPrefab; // Prefab «·Œ«’ »«·”·„
    public GameObject climbableLadderPrefab; // Prefab «·Œ«’ »«·”·„ «·ﬁ«»· ·· ”·ﬁ
    public float spawnRate = 1.5f; // „⁄œ·  Ê·Ìœ «·”·«·„
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
        float xPos = Random.Range(-2f, 2f); //  ÕœÌœ „Êﬁ⁄ X ⁄‘Ê«∆Ì ··”·„
        float yPos = lastYPosition + Random.Range(1.2f, 1.8f); // Ã⁄· «·”·„ ÌŸÂ— ›Êﬁ «·”«»ﬁ
        lastYPosition = yPos;

        // ‰Œ «— ⁄‘Ê«∆Ì« „« ≈–« ﬂ«‰ «·”·„ ﬁ«»·« ·· ”·ﬁ √„ ·«
        bool isClimbable = Random.value > 0.5f; // 50% ›—’… √‰ ÌﬂÊ‰ «·”·„ ﬁ«»·« ·· ”·ﬁ

        GameObject ladderToSpawn = isClimbable ? climbableLadderPrefab : ladderPrefab;

        Instantiate(ladderToSpawn, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }
}
