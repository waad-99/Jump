using UnityEngine;

public class ApplySkin : MonoBehaviour
{
    public Sprite[] skins; // ������ ����� ��� ������� ������� (��� �� ���� ������ ���� �������� �� SkinManager)

    void Start()
    {
        // ������ ��� ����� ������� �� PlayerPrefs
        int selectedSkinIndex = PlayerPrefs.GetInt("SelectedSkinIndex", 0);

        // ����� ����� ��� �����
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