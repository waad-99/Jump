using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public GameObject gameOverPanel; // áæÍÉ ÇáÎÓÇÑÉ ÇáÊí ÊÍÊæí Úáì ÒÑ ÅÚÇÏÉ ÇáÊÔÛíá

    void Start()
    {
        gameOverPanel.SetActive(false); // ÅÎİÇÁ áæÍÉ ÇáÎÓÇÑÉ ÚäÏ ÈÏÁ ÇááÚÈÉ
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true); // ÅÙåÇÑ áæÍÉ ÇáÎÓÇÑÉ ÚäÏ ÇáÎÓÇÑÉ
    }
}
