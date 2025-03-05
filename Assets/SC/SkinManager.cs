using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public Sprite[] skins; // „’›Ê›…  Õ ÊÌ ⁄·Ï «·”ﬂ‰«  «·„ «Õ…
    public Image ballPreview; // ’Ê—… ·⁄—÷ «·”ﬂ‰ «·„Œ «—
    public Button startGameButton; // “— ·»œ¡ «··⁄»…
    public Button nextSkinButton; // “— ··«‰ ﬁ«· ≈·Ï «·”ﬂ‰ «· «·Ì
    public Button previousSkinButton; // “— ··«‰ ﬁ«· ≈·Ï «·”ﬂ‰ «·”«»ﬁ
    public Button backToMenuButton; // “— ··⁄Êœ… ≈·Ï Ê«ÃÂ… «Œ Ì«— «·”ﬂ‰
    public GameObject skinSelectionUI; // Ê«ÃÂ… «Œ Ì«— «·”ﬂ‰
    public GameObject gameUI; // Ê«ÃÂ… «··⁄»…
    public SpriteRenderer ballSpriteRenderer; // SpriteRenderer ··ﬂ—… ›Ì «··⁄»…

    private int selectedSkinIndex = 0; // «·›Â—” «·Õ«·Ì ··”ﬂ‰ «·„Œ «—

    void Start()
    {
        // ⁄—÷ «·”ﬂ‰ «·√Ê· «› —«÷Ì«
        UpdateBallPreview();

        // —»ÿ «·√“—«— »«·ÊŸ«∆›
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

        // ≈Œ›«¡ Ê«ÃÂ… «··⁄»… ⁄‰œ «·»œ¡
        if (gameUI != null)
        {
            gameUI.SetActive(false);
        }

        // ≈ŸÂ«— Ê«ÃÂ… «Œ Ì«— «·”ﬂ‰ ⁄‰œ «·»œ¡
        if (skinSelectionUI != null)
        {
            skinSelectionUI.SetActive(true);
        }
    }

    //  €ÌÌ— «·”ﬂ‰ ≈·Ï «· «·Ì
    public void NextSkin()
    {
        selectedSkinIndex = (selectedSkinIndex + 1) % skins.Length;
        UpdateBallPreview();
    }

    //  €ÌÌ— «·”ﬂ‰ ≈·Ï «·”«»ﬁ
    public void PreviousSkin()
    {
        selectedSkinIndex = (selectedSkinIndex - 1 + skins.Length) % skins.Length;
        UpdateBallPreview();
    }

    //  ÕœÌÀ ’Ê—… «·⁄—÷ ··”ﬂ‰ «·„Œ «—
    void UpdateBallPreview()
    {
        if (ballPreview != null && skins.Length > 0)
        {
            ballPreview.sprite = skins[selectedSkinIndex];
        }
    }

    // »œ¡ «··⁄»… „⁄ «·”ﬂ‰ «·„Œ «—
    void StartGame()
    {
        //  ÿ»Ìﬁ «·”ﬂ‰ «·„Œ «— ⁄·Ï «·ﬂ—…
        if (ballSpriteRenderer != null && skins.Length > selectedSkinIndex)
        {
            ballSpriteRenderer.sprite = skins[selectedSkinIndex];
        }

        // ≈Œ›«¡ Ê«ÃÂ… «Œ Ì«— «·”ﬂ‰
        if (skinSelectionUI != null)
        {
            skinSelectionUI.SetActive(false);
        }

        // ≈ŸÂ«— Ê«ÃÂ… «··⁄»…
        if (gameUI != null)
        {
            gameUI.SetActive(true);
        }
    }

    // «·⁄Êœ… ≈·Ï Ê«ÃÂ… «Œ Ì«— «·”ﬂ‰
    void BackToMenu()
    {
        // ≈Œ›«¡ Ê«ÃÂ… «··⁄»…
        if (gameUI != null)
        {
            gameUI.SetActive(false);
        }

        // ≈ŸÂ«— Ê«ÃÂ… «Œ Ì«— «·”ﬂ‰
        if (skinSelectionUI != null)
        {
            skinSelectionUI.SetActive(true);
        }
    }
}