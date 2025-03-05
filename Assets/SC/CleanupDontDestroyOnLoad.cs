using UnityEngine;

public class CleanupDontDestroyOnLoad : MonoBehaviour
{
    void Start()
    {
        // ����� �� ���� [Debug Updater] �� DontDestroyOnLoad ����� ��� ��� �������
        GameObject debugUpdater = GameObject.Find("[Debug Updater]");
        if (debugUpdater != null)
        {
            Destroy(debugUpdater);
        }
    }
}
