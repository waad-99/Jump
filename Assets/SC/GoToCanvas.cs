using UnityEngine;
using UnityEngine.UI;

public class GoToCanvas : MonoBehaviour
{
    public Button goToCanvasButton; // ���� ���� ���� ����� ����
    public GameObject targetCanvas; // ������� ���� ���� �������� ����

    void Start()
    {
        // ��� ���� �������� GoToTargetCanvas
        if (goToCanvasButton != null)
        {
            goToCanvasButton.onClick.AddListener(GoToTargetCanvas);
        }
    }

    // �������� ��� ������� ������
    void GoToTargetCanvas()
    {
        if (targetCanvas != null)
        {
            // ����� ���� ��������� ������ (�������)
            HideAllCanvases();

            // ����� ������� ������
            targetCanvas.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Target Canvas is not assigned!");
        }
    }

    // ����� ���� ��������� (�������)
    void HideAllCanvases()
    {
        // ����� ����� ���� ��������� ��� ��������
        // ����:
        // GameObject[] allCanvases = GameObject.FindGameObjectsWithTag("Canvas");
        // foreach (GameObject canvas in allCanvases)
        // {
        //     canvas.SetActive(false);
        // }
    }
}