using UnityEngine;
using UnityEngine.UI;

public class GoToCanvas : MonoBehaviour
{
    public Button goToCanvasButton; // «·“— «·–Ì ”Ì „ «·÷€ÿ ⁄·ÌÂ
    public GameObject targetCanvas; // «·ﬂ«‰›” «·–Ì  —Ìœ «·«‰ ﬁ«· ≈·ÌÂ

    void Start()
    {
        // —»ÿ «·“— »«·ÊŸÌ›… GoToTargetCanvas
        if (goToCanvasButton != null)
        {
            goToCanvasButton.onClick.AddListener(GoToTargetCanvas);
        }
    }

    // «·«‰ ﬁ«· ≈·Ï «·ﬂ«‰›” «·„Õœœ
    void GoToTargetCanvas()
    {
        if (targetCanvas != null)
        {
            // ≈Œ›«¡ Ã„Ì⁄ «·ﬂ«‰›”«  «·√Œ—Ï («Œ Ì«—Ì)
            HideAllCanvases();

            // ≈ŸÂ«— «·ﬂ«‰›” «·„Õœœ
            targetCanvas.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Target Canvas is not assigned!");
        }
    }

    // ≈Œ›«¡ Ã„Ì⁄ «·ﬂ«‰›”«  («Œ Ì«—Ì)
    void HideAllCanvases()
    {
        // Ì„ﬂ‰ﬂ ≈÷«›… Ã„Ì⁄ «·ﬂ«‰›”«  Â‰« ·≈Œ›«∆Â«
        // „À«·:
        // GameObject[] allCanvases = GameObject.FindGameObjectsWithTag("Canvas");
        // foreach (GameObject canvas in allCanvases)
        // {
        //     canvas.SetActive(false);
        // }
    }
}