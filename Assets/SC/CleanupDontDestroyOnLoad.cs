using UnityEngine;

public class CleanupDontDestroyOnLoad : MonoBehaviour
{
    void Start()
    {
        // ÇáÈÍË Úä ßÇÆä [Debug Updater] İí DontDestroyOnLoad æÍĞİå ÅĞÇ ßÇä ãæÌæÏğÇ
        GameObject debugUpdater = GameObject.Find("[Debug Updater]");
        if (debugUpdater != null)
        {
            Destroy(debugUpdater);
        }
    }
}
