using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public GameObject gameOverPanel; // ���� ������� ���� ����� ��� �� ����� �������

    void Start()
    {
        gameOverPanel.SetActive(false); // ����� ���� ������� ��� ��� ������
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true); // ����� ���� ������� ��� �������
    }
}
