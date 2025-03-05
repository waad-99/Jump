using UnityEngine;
using UnityEngine.UI;

public class GameStartController : MonoBehaviour
{
    public Button startGameButton;
    public GameObject startMenuUI;
    public GameObject gameUI;
    public GameObject background;
    public GameObject[] objectsToHideBeforeStart;
    public GameObject[] objectsToHideDuringGameplay;
    public GameObject fireSpawner; // ���� ����� �� ����� �����

    private void Start()
    {
        Time.timeScale = 0;

        if (gameUI != null) gameUI.SetActive(false);
        if (startMenuUI != null) startMenuUI.SetActive(true);
        if (background != null) background.SetActive(true);

        if (startGameButton != null)
            startGameButton.onClick.AddListener(StartGame);

        HideBeforeGameStart();

        if (fireSpawner != null)
            fireSpawner.SetActive(false); // ����� ����� ����� ��� ��� ������
    }

    private void StartGame()
    {
        Time.timeScale = 1;

        if (startMenuUI != null) startMenuUI.SetActive(false);
        if (gameUI != null) gameUI.SetActive(true);

        HideDuringGameplay();
        ShowHiddenObjects();

        if (fireSpawner != null)
            fireSpawner.SetActive(true); // ����� ����� ����� ����� �����
    }

    private void HideBeforeGameStart() => HideObjects(objectsToHideBeforeStart);
    private void HideDuringGameplay() => HideObjects(objectsToHideDuringGameplay);
    private void ShowHiddenObjects() => ShowObjects(objectsToHideBeforeStart);

    private void HideObjects(GameObject[] objects)
    {
        if (objects != null)
        {
            foreach (GameObject obj in objects)
                if (obj != null) obj.SetActive(false);
        }
    }

    private void ShowObjects(GameObject[] objects)
    {
        if (objects != null)
        {
            foreach (GameObject obj in objects)
                if (obj != null) obj.SetActive(true);
        }
    }
}
