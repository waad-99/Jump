using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpHeight = 1.5f; // ������ �����
    private bool isGrounded = false; // �� ������ ��� �����

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isGrounded)
        {
            transform.position += new Vector3(0, jumpHeight, 0);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isGrounded = true;
        }
    }
}
