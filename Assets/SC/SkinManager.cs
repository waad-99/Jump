using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public Sprite[] skins; // ������ ����� ��� ������� �������
    public Image ballPreview; // ���� ���� ����� �������
    public Button startGameButton; // �� ���� ������
    public Button nextSkinButton; // �� �������� ��� ����� ������
    public Button previousSkinButton; // �� �������� ��� ����� ������
    public Button backToMenuButton; // �� ������ ��� ����� ������ �����
    public GameObject skinSelectionUI; // ����� ������ �����
    public GameObject gameUI; // ����� ������
    public SpriteRenderer ballSpriteRenderer; // SpriteRenderer ����� �� ������

    private int selectedSkinIndex = 0; // ������ ������ ����� �������

    void Start()
    {
        // ��� ����� ����� ���������
        UpdateBallPreview();

        // ��� ������� ��������
        if (startGameButton != null)
        {
            startGameButton.onClick.AddListener(StartGame);
        }

        if (nextSkinButton != null)
        {
            nextSkinButton.onClick.AddListener(NextSkin);
        }

        if (previousSkinButton != null)
        {
            previousSkinButton.onClick.AddListener(PreviousSkin);
        }

        if (backToMenuButton != null)
        {
            backToMenuButton.onClick.AddListener(BackToMenu);
        }

        // ����� ����� ������ ��� �����
        if (gameUI != null)
        {
            gameUI.SetActive(false);
        }

        // ����� ����� ������ ����� ��� �����
        if (skinSelectionUI != null)
        {
            skinSelectionUI.SetActive(true);
        }
    }

    // ����� ����� ��� ������
    public void NextSkin()
    {
        selectedSkinIndex = (selectedSkinIndex + 1) % skins.Length;
        UpdateBallPreview();
    }

    // ����� ����� ��� ������
    public void PreviousSkin()
    {
        selectedSkinIndex = (selectedSkinIndex - 1 + skins.Length) % skins.Length;
        UpdateBallPreview();
    }

    // ����� ���� ����� ����� �������
    void UpdateBallPreview()
    {
        if (ballPreview != null && skins.Length > 0)
        {
            ballPreview.sprite = skins[selectedSkinIndex];
        }
    }

    // ��� ������ �� ����� �������
    void StartGame()
    {
        // ����� ����� ������� ��� �����
        if (ballSpriteRenderer != null && skins.Length > selectedSkinIndex)
        {
            ballSpriteRenderer.sprite = skins[selectedSkinIndex];
        }

        // ����� ����� ������ �����
        if (skinSelectionUI != null)
        {
            skinSelectionUI.SetActive(false);
        }

        // ����� ����� ������
        if (gameUI != null)
        {
            gameUI.SetActive(true);
        }
    }

    // ������ ��� ����� ������ �����
    void BackToMenu()
    {
        // ����� ����� ������
        if (gameUI != null)
        {
            gameUI.SetActive(false);
        }

        // ����� ����� ������ �����
        if (skinSelectionUI != null)
        {
            skinSelectionUI.SetActive(true);
        }
    }
}