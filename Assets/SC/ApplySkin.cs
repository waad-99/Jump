using UnityEngine;

public class ApplySkin : MonoBehaviour
{
    public Sprite[] skins; // ãÕÝæÝÉ ÊÍÊæí Úáì ÇáÓßäÇÊ ÇáãÊÇÍÉ (íÌÈ Ãä Êßæä ãØÇÈÞÉ áÊáß ÇáãæÌæÏÉ Ýí SkinManager)

    void Start()
    {
        // ÇáÍÕæá Úáì ÇáÓßä ÇáãÎÊÇÑ ãä PlayerPrefs
        int selectedSkinIndex = PlayerPrefs.GetInt("SelectedSkinIndex", 0);

        // ÊØÈíÞ ÇáÓßä Úáì ÇáßÑÉ
        if (skins.Length > selectedSkinIndex)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = skins[selectedSkinIndex];
            }
        }
    }
}