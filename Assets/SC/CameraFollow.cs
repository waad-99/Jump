using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // ãÑÌÚ Åáì ÇááÇÚÈ
    public float smoothSpeed = 0.125f; // ÓÑÚÉ ÍÑßÉ ÇáßÇãíÑÇ
    public float yOffset = 2f; // ÊÚæíÖ ÈÓíØ ÈÍíË ÊÈŞì ÇáßÇãíÑÇ İæŞ ÇááÇÚÈ

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newPosition = new Vector3(transform.position.x, player.position.y + yOffset, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed);
        }
    }
}
