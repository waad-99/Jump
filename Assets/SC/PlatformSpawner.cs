using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject stablePlatformPrefab; // „‰’… À«» …
    public GameObject fallingPlatformPrefab; // „‰’…  ”ﬁÿ »⁄œ Êﬁ  „⁄Ì‰
    public float spawnRate = 1.5f; // „⁄œ·  Ê·Ìœ «·„‰’« 
    public float platformSpacingMin = 1.5f; // «·Õœ «·√œ‰Ï ··„”«›… »Ì‰ «·„‰’« 
    public float platformSpacingMax = 2.5f; // «·Õœ «·√ﬁ’Ï ··„”«›… »Ì‰ «·„‰’« 

    private float lastSpawnTime = 0;
    private float lastYPosition = 0;
    private int spawnCount = 0; // ⁄œ«œ · ÕœÌœ „ Ï Ì „ ≈‰‘«¡ „‰’… À«» …

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
        float xPos = Random.Range(-2f, 2f); //  ÕœÌœ „Êﬁ⁄ X ⁄‘Ê«∆Ì ··„‰’…
        float yPos = lastYPosition + Random.Range(platformSpacingMin, platformSpacingMax); // Ã⁄· ﬂ· „‰’…  ŸÂ— ›Êﬁ «·”«»ﬁ… »„”«›… „⁄Ì‰…
        lastYPosition = yPos;

        //  ÕœÌœ ‰Ê⁄ «·„‰’… «· Ì ”Ì „ ≈‰‘«ƒÂ«
        bool isStable = spawnCount == 0; // ﬂ· „‰’… √Ê·Ï  ﬂÊ‰ À«» …

        // “Ì«œ… «·⁄œ«œ
        spawnCount++;

        // »⁄œ ﬂ· 3 „‰’« ° Ì „ ≈⁄«œ…  ⁄ÌÌ‰ «·⁄œ«œ ·Ã⁄· √Ê· „‰’… À«» … „Ãœœ«
        if (spawnCount >= 3)
        {
            spawnCount = 0;
        }

        //  ÕœÌœ ‰Ê⁄ «·„‰’… «· Ì ”Ì „ ≈‰‘«ƒÂ«
        GameObject platformToSpawn = isStable ? stablePlatformPrefab : fallingPlatformPrefab;

        // ≈‰‘«¡ «·„‰’… ›Ì «·„ﬂ«‰ «·„Õœœ
        GameObject spawnedPlatform = Instantiate(platformToSpawn, new Vector3(xPos, yPos, 0), Quaternion.identity);

        // ≈–« ﬂ«‰  «·„‰’… „‰ «·‰Ê⁄ «·–Ì Ì”ﬁÿ° √÷› ·Â« ”ﬂ—»  «·”ﬁÊÿ
        if (!isStable)
        {
            FallingPlatform fallingPlatformScript = spawnedPlatform.AddComponent<FallingPlatform>();
            fallingPlatformScript.fallDelay = 2f; // «·„œ… «· Ì  ‰ Ÿ—Â« «·„‰’… ﬁ»· √‰  ”ﬁÿ
        }
    }
}
