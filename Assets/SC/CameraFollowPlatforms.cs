using UnityEngine;

public class CameraFollowPlatforms : MonoBehaviour
{
    public float smoothSpeed = 0.2f; // ���� ���� ��������
    private Transform highestPlatform; // ����� ���� ����

    void LateUpdate()
    {
        FindHighestPlatform(); // ����� �� ���� ����

        if (highestPlatform != null)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, highestPlatform.position.y + 2f, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        }
    }

    void FindHighestPlatform()
    {
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform"); // ����� �� �� �������
        foreach (GameObject platform in platforms)
        {
            if (highestPlatform == null || platform.transform.position.y > highestPlatform.position.y)
            {
                highestPlatform = platform.transform;
            }
        }
    }
}
