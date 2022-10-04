using UnityEngine;
using TMPro;

public class TextGoldViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPlayerGold;// 플레이어 골드 텍스트.
    [SerializeField] private PlayerGold playerGold;// 플레이어 골드 정보.

    private void Update()
    {
        textPlayerGold.text = playerGold.CurrentGold.ToString();
    }
}
