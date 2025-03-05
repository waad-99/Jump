using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // ���� ��� ������
    public float smoothSpeed = 0.125f; // ���� ���� ��������
    public float yOffset = 2f; // ����� ���� ���� ���� �������� ��� ������

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newPosition = new Vector3(transform.position.x, player.position.y + yOffset, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed);
        }
    }
}
